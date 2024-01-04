using System;
using System.Collections.Generic;
using System.Text;

namespace CodigoBarrasDemo.Models
{
    public class StokeResponseModel
    {
        public string SucursalId { get; set; }
        public string Store { get; set; }
        public string NameStore { get; set; }
        public string ProductKey { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string LocationStoke { get; set; }
        public double Existence { get; set; }
        public string ImageProduct { get; set; }
        public double RealExistence { get; set; } = 0;
    }
}
