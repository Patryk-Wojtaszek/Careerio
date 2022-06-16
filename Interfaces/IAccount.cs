using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Dtos;

namespace Careerio.Interfaces
{
    public interface IAccount
    {
        string RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
    }
}
