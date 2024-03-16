using FluentValidation;

namespace UserExperience.Models.Validations
{


    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(a => a.UserName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(5)
                ;
            RuleFor(a => a.Email).EmailAddress();
        }
    }

}
