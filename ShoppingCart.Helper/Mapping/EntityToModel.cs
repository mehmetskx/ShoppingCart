using AutoMapper;
using ShoppingCart.Data.Entities;
using ShoppingCart.Helper.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Helper.Mapping
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            #region EntityToDataTransferObject
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
          //  CreateMap<List<Product>, List<ProductDTO>>();
            #endregion

            #region DataTransferObjectToEntity
            CreateMap<ProductDTO, Product>();
            CreateMap<CategoryDTO, Category>();
            //CreateMap<List<ProductDTO>, List<Product>>();
            #endregion

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<ProductDTO>, List<Product>>();
                cfg.CreateMap<List<Product>, List<ProductDTO>>();
            });
        }
    }
}
