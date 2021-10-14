using FluentValidation;
using ValidataShopping.API.Orders.Requests;

namespace ValidataShopping.API.Orders.Validators
{
    public class AddNewOrderProductRequestValidator : AbstractValidator<AddNewOrderProductRequest>
    {
        public AddNewOrderProductRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .NotNull()
                .WithMessage("ProductId must not be null.");
        }
    }
}
