using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateItem
{
    public class UpdateItemValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemValidator()
        {
            RuleFor(x => x.Item.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Item.Image).NotEmpty().WithMessage("Image is required");
            RuleFor(x => x.Item.Color).NotEmpty().WithMessage("Color is required");
            RuleFor(x => x.Item.Size).NotEmpty().WithMessage("Size is required");
            RuleFor(x => x.Item.Quantity).NotEmpty().WithMessage("Quantity is required")
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0");
            RuleFor(x => x.Item.ProductID).NotEmpty().WithMessage("ProductID is required");
        }
    }
}
