using CodigoBarrasDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Interfaces
{
    public interface IStokeService
    {
        Task<IEnumerable<StokeResponseModel>> ExistanceStoke(StokeRequestModel data);
        Task<IEnumerable<CatalogStokeResponse>> GetCatalogStokeResponses(StokeRequestModel data);
    }
}
