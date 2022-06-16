using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Data;
using FluentValidation;

namespace Careerio.Dtos
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(CareerioDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Login).NotEmpty().Length(4, 20).Matches(expression: "^[A-Za-z0-9]*$").WithMessage("Login musi składać się z 4-20 znaków oraz nie może zawierać znaków specjalnych.");
            RuleFor(x => x.Password).Length(7, 15).Matches(expression: "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{7,15}$").WithMessage("Hasło musi składać się z 7-15 znaków" +
                "zawierających przynajmniej jedną cyfrę i znak specjalny.");

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Email jest już zajęty");
                    }
                });
            RuleFor(x => x.Login)
                .Custom((value, context) =>
                {
                    var loginInUse = dbContext.Users.Any(u => u.Login == value);
                    if (loginInUse)
                    {
                        context.AddFailure("Login", "Login jest już zajęty");
                    }
                });
        }
    }
}
