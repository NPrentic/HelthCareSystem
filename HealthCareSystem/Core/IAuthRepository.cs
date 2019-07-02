using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
    public interface IAuthRepository
    {
        Task<TokenModel> SearchUserByCredentials(LoginModel loginModel);
    }
}
