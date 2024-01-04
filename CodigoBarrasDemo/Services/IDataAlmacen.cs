using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Services
{
    public interface IDataAlmacen<T>
    {
        Task<T> GetAlmacen(string code);
    }
}
