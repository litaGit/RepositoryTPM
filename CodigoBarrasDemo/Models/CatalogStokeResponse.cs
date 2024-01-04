using System;
using System.Collections.Generic;
using System.Text;

namespace CodigoBarrasDemo.Models
{
    public class CatalogStokeResponse
    {
        public int IdCatalog { get; set; }
        public string SucursalId { get; set; }
        public string Store { get; set; }
        public string NameStore { get; set; }
        public string ProductKey { get; set; }
        public double Existence { get; set; }
    }
}
