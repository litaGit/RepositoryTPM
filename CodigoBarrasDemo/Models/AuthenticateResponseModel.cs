using System;
using System.Collections.Generic;
using System.Text;

namespace CodigoBarrasDemo.Models
{
    public class AuthenticateResponseModel
    {
        public LoginModel data { get; set; }

        public bool isSucces { get; set; }

        public string message { get; set; }

    }
}
