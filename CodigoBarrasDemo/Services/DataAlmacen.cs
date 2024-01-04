using CodigoBarrasDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Services
{
    public class DataAlmacen : IDataAlmacen<Almacen>
    {
        public Almacen almacenItem;

        public DataAlmacen()
        {
            almacenItem = new Almacen
            {
                ProductName = "SPACER NUT M8 X 16 X 18",
                Sucursal = "CASA MATRIZ",
                Lote = "0RD-029282",
                UbicacionAlmacen = "E1X",
                TotalAlmacen = "2,215"
            };
        }

        public async Task<Almacen> GetAlmacen(string code)
        {
           
            return await Task.FromResult(almacenItem);
        }
    }
}
