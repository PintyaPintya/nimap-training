using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    private readonly ApplicationDbContext _context;

    public ProductDtoValidator(ApplicationDbContext context)
    {
        _context = context;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required")
            .Length(3,100).WithMessage("Product name must be between 3 and 100 characters.")
            .MustAsync(BeUniqueNameAsync).WithMessage("Product name must be unique.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(p => p.CategoryId)
            .MustAsync(CategoryExistsAsync).WithMessage("Category does not exist.");

        RuleFor(p => p.Discount)
            .InclusiveBetween(0,50).WithMessage("Discount must be between 0 and 50%.")
            .MustAsync(IsValidDiscountBasedOnRuleAsync).WithMessage("Discount is not valid for the given product price.");
    }

    private async Task<bool> BeUniqueNameAsync(string productName, CancellationToken cancellationToken)
    {
        return !await _context.Products.AnyAsync(p => p.Name == productName, cancellationToken);
    }

    private async Task<bool> CategoryExistsAsync(int categoryId, CancellationToken cancellationToken)
    {
        return await _context.Categories.AnyAsync(c => c.CategoryId == categoryId, cancellationToken);
    }

    private async Task<bool> IsValidDiscountBasedOnRuleAsync(ProductDto productDto, decimal discount, CancellationToken cancellationToken)
    {
        var discountRule = await _context.DiscountRules
                            .Where(rule => productDto.Price >= rule.MinimumPrice)
                            .OrderByDescending(rule => (double)rule.MinimumPrice)
                            .FirstOrDefaultAsync();
        
        if(discountRule == null) return false;

        return discount <= discountRule.MaximumDiscount;
    }
}
