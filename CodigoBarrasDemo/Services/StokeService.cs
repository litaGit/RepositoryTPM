using CodigoBarrasDemo.Interfaces;
using CodigoBarrasDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Services
{
    public class StokeService : IStokeService
    {
        public async Task<IEnumerable<StokeResponseModel>> ExistanceStoke(StokeRequestModel data) {

            Uri RequestUri = new Uri("http://5.161.49.20:9096/AppKepler/api/Stoke/ConsultStoke");
            List<StokeResponseModel> stoke = new List<StokeResponseModel>();
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(data);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) {

                var content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<List<StokeResponseModel>>(content);
                if (dataResponse.Count > 0) {
                    foreach (StokeResponseModel item in dataResponse)
                    {
                        StokeResponseModel itemStoke = new StokeResponseModel 
                        {
                            SucursalId = item.SucursalId,
                            Store = item.Store,
                            NameStore = item.SucursalId + " - " + item.Store + " - " + item.NameStore,
                            ProductKey = item.ProductKey,
                            ProductName = item.ProductKey + " - " + item.ProductName,
                            BarCode = item.BarCode,
                            LocationStoke = item.LocationStoke,
                            Existence = item.Existence,
                            ImageProduct = item.ImageProduct
                        };
                        stoke.Add(itemStoke);

                    }
                }
            }
                return stoke;

        }
        public async Task<IEnumerable<CatalogStokeResponse>> GetCatalogStokeResponses(StokeRequestModel data) {

            Uri RequestUri = new Uri("http://5.161.49.20:9096/AppKepler/api/Stoke/GetCatalogStoke");
            List<CatalogStokeResponse> catalog = new List<CatalogStokeResponse>();
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(data);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<List<CatalogStokeResponse>>(content);
                if (dataResponse.Count > 0)
                {
                    var i = 0;
                    foreach (CatalogStokeResponse item in dataResponse)
                    {
                        CatalogStokeResponse itemCatalog = new CatalogStokeResponse
                        {
                            IdCatalog = i+1,
                            SucursalId = item.SucursalId,
                            Store = item.Store,
                            NameStore = item.SucursalId + " - " + item.Store + " - " + item.NameStore + " (" + item.Existence + ")",
                            ProductKey = item.ProductKey,
                            Existence = item.Existence
                        };
                        catalog.Add(itemCatalog);

                    }
                }
            }

            return catalog;

        }


    }
}
