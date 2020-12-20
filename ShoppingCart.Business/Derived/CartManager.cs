using AutoMapper;
using FluentValidation;
using ShoppingCart.Business.Infrastructure;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Infrastructure;
using ShoppingCart.Helper.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Derived
{
    public class CartManager : ICartManager
    {
        private readonly IValidator<ProductDTO> _productDTOValidator;
        private readonly IUnitOfWork _unitOfWork;

        public CartManager(IValidator<ProductDTO> productDTOValidator,
            IUnitOfWork unitOfWork)
        {
            _productDTOValidator = productDTOValidator;
            _unitOfWork = unitOfWork;
        }

        public async Task AddProductToCart(List<Product> products)
        {
            try
            {
                // Normal use: find userId from user token
                int userId = 1;
                ShoppingCart.Data.Entities.ShoppingCart userShoppingCart;

                userShoppingCart = await GetShoppingCartByUserId(userId);

                if (userShoppingCart == null)
                    userShoppingCart = await CreateShoppingCartForUser(userId);

                await CreateShoppingCartDetail(products, userShoppingCart);

                int createOperation = await _unitOfWork.CommitAsync();

                if (createOperation < 0)
                    throw new Exception("Basket could not be created");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Handled By My Custom Exception Middleware and Logged (ShoppingCart.Helper > MiddleWare)");
                throw;
            }
        }

        private async Task<ShoppingCart.Data.Entities.ShoppingCart> GetShoppingCartByUserId(int userId)
        {
            return await _unitOfWork.ShoppingCart.GetUserShoppingCartByUserIdAsync(userId);
        }

        private async Task<ShoppingCart.Data.Entities.ShoppingCart> CreateShoppingCartForUser(int userId)
        {
            ShoppingCart.Data.Entities.ShoppingCart shoppingCart = new Data.Entities.ShoppingCart()
            {
                CreatedDate = DateTime.Now,
                CreatedBy = userId,
                IsActive = true
            };

            await _unitOfWork.ShoppingCart.AddAsync(shoppingCart);
            await _unitOfWork.CommitAsync();
            return shoppingCart;
        }

        private async Task CreateShoppingCartDetail(List<Product> products, ShoppingCart.Data.Entities.ShoppingCart shoppingCart)
        {
            var groupedProduct = products.GroupBy(x => x.Id).Select(x => new ShoppingCartDetail
            {
                Quantity = x.Count(),
                CreatedDate = DateTime.Now,
                IsActive = true,
                ShoppingCartId = shoppingCart.Id,
                ProductId = x.FirstOrDefault().Id
            }).ToList();

            await _unitOfWork.ShoppingCartDetail.AddRangeAsync(groupedProduct);

        }

    }
}
