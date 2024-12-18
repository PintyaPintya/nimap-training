using FluentValidation;
using WebApiPractice.Models;

namespace WebApiPractice.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product Name is required")
            .Length(3,50).WithMessage("Product name must be between 3 and 50 characters");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(p => p.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative");

        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Category Id is required");

        
    }
}
