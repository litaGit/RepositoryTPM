using CodigoBarrasDemo.Interfaces;
using CodigoBarrasDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Services
{
    public class WorkersService : IWorkersService
    {

        public async Task<IEnumerable<WorkersItemModel>> GetWorkers()
        {
            Uri RequestUri = new Uri("http://5.161.49.20:9096/AppKepler/api/WorkUser/WorkUsers");
            List<WorkersItemModel> workers = new List<WorkersItemModel>();
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<List<WorkersModel>>(content);

                if (dataResponse.Count > 0) 
                {
                    foreach (WorkersModel item in dataResponse) 
                    {
                        WorkersItemModel itemWorker = new WorkersItemModel
                        {
                            employeeName = item.employeeName,
                            infoTurn = item.infoTurn,
                            infoTask = item.infoTask,
                            infoProduct = item.infoProduct,
                            descriptionProduct = item.descriptionProduct,
                            photo = Xamarin.Forms.ImageSource.FromStream(
                                () => new MemoryStream(Convert.FromBase64String(item.imageEmployee)))

                        };
                        workers.Add(itemWorker);
                    }
                }
  
            }

            return workers;
        }
    }
}
