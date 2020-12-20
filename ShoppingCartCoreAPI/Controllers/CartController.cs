using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Business.Infrastructure;
using ShoppingCart.Data.Entities;
using ShoppingCart.Helper.DTOModels;
using ShoppingCart.Helper.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IValidator<ProductDTO> _productDTOValidator;
        private readonly ICartManager _cartManager;
        private readonly IMapper _mapper;
        public CartController(ICartManager cartManager,
               IValidator<ProductDTO> productDTOValidator,
               IMapper mapper)
        {
            _productDTOValidator = productDTOValidator;
            _cartManager = cartManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart(BasketDTO basket)
        {
            List<ProductDTO> productsInBasket = basket.Products;

            var modelToEntity = _mapper.Map<List<ProductDTO>, List<Product>>(productsInBasket);
            await _cartManager.AddProductToCart(modelToEntity);

            return Created(string.Empty, "Success");
        }

    }
}
