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
    public class InventoryService: IInventoryService
    {
        public async Task<bool> InsertInventory(InventoryModel data) 
        {
            Uri RequestUri = new Uri("http://5.161.49.20:9096/AppKepler/api/Inventory/InsertInventory");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(data);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {

                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
