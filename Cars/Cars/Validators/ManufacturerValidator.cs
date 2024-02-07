using FluentValidation;
using Cars.Models.User;

namespace Cars.Validators
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(x => x.ManufacturerId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
