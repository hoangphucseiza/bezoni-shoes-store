using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Product.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Product.Voucher).NotEmpty().WithMessage("Voucher is required")
                .GreaterThanOrEqualTo(0).WithMessage("Voucher must be greater than or equal to 0")
                .Must(x => x <= 100).WithMessage("Voucher must be less than or equal to 100");
            RuleFor(x => x.Product.Price).NotEmpty().WithMessage("Price is required")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0");
            RuleFor(x => x.Product.CategoryID).NotEmpty().WithMessage("Category is required");
        }
    }
}
