using FluentValidation;
using PosTerminalApi.Resources;

namespace PosTerminalApi.Validators
{
    public class SaveProductResourceValidator : AbstractValidator<SaveProductResource>
    {
        public SaveProductResourceValidator()
        {
            RuleFor(m => m.CodeName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(m => m.UnitPrice)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("'Unit Price' must be greater than 0.");
            RuleFor(m => m.DiscountQtyBase)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("'Discount Quantity' must be greater than 0.");
            RuleFor(m => m.UnitDiscount)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("'Unit Discount Price' must be greater than 0.");
        }
    }
}
