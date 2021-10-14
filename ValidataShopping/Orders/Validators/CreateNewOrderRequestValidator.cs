using FluentValidation;
using ValidataShopping.API.Orders.Requests;

namespace ValidataShopping.API.Orders.Validators
{
    public class CreateNewOrderRequestValidator : AbstractValidator<CreateNewOrderRequest>
    {
        public CreateNewOrderRequestValidator()
        {
            RuleFor(x => x.OrderName).NotNull().NotEmpty().WithMessage("OrderName must not be empty.");
        }
    }
}
