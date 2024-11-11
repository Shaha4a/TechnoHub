using FluentValidation;
using TechnoHub.Model;

namespace TechnoHub.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator() 
        {
            RuleFor(customer => customer.Name).NotEmpty().Matches("^[A-Za-zА-Яа-яЁё\\s'-]+$").Length(3, 50);
            RuleFor(customer => customer.Surname).NotEmpty().Matches("^[A-Za-zA-Яа-яЁё\\s'-]+$");
            RuleFor(customer => customer.lastname).Matches("^[A-Za-zA-Яа-яЁё\\s'-]+$");
        }
    }
}
