using MAUIMobileStarterKit.Models.API.Request;
using MAUIMobileStarterKit.Models.API.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.RestApiService
{
    public interface IUserAuthonticator
    {

        [Post("/token")]
        Task<LoginResponseModal> AuthonticateUser(LoginRequestModal loginRequest);
    }
}
