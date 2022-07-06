using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Data;
using FluentValidation;

namespace Careerio.Dtos
{
    public class LoginUserValidator : AbstractValidator<LoginDto>
    {
        public LoginUserValidator (CareerioDbContext context)
        {

        }
    }
}
