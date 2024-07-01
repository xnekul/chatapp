using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Services
{
    public interface ITokenService
    {
        string CreateToken(UserEntity user);
    }
}