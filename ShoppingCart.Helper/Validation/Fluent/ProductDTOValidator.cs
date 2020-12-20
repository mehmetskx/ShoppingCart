using FluentValidation;
using ShoppingCart.Helper.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Helper.Validation.Fluent
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Id).Must(id => id > 0).OnFailure(x => throw new ArgumentException("Id could not be null"));
            RuleFor(x => x.CategoryId).Must(categoryId => categoryId > 0).OnFailure(x => throw new ArgumentException("CategoryId could not be null"));
            RuleFor(x => x.Name).NotNull().OnFailure(x => throw new ArgumentException("Name could not be null"));
        }
    }
}
