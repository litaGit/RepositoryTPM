using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Services
{
    public interface IDataTasks<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
