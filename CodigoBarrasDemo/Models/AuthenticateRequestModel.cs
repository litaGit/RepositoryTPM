using System;
using System.Collections.Generic;
using System.Text;

namespace CodigoBarrasDemo.Models
{
    public class AuthenticateRequestModel
    {
        public string userCode { get; set; }

        public string password { get; set; }
    }
}
