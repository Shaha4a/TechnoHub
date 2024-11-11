using FluentValidation;
using TechnoHub.Model;

namespace TechnoHub.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserModel>
    {
        public UserUpdateValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().Matches("^[A-Za-zА-Яа-яЁё\\s'-]+$");
            RuleFor(x => x.Surname).NotEmpty().Matches("^[A-Za-zA-Яа-яЁё\\s'-]+$");
            RuleFor(x => x.lastname).NotEmpty().Matches("^[A-Za-zA-Яа-яЁё\\s'-]+$");
        }
    }
}
