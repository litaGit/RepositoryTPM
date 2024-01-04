using CodigoBarrasDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Interfaces
{
    public interface IAuthenticateService
    {
        Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel data);
    }
}
