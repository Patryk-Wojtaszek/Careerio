using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Dtos;
using Careerio.Authentication;

namespace Careerio.Interfaces
{
    public interface IAccount
    {
        string RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);

        UserDto GetUser(int id);

        UserDto GetUserByToken(string dto);

    }
}
