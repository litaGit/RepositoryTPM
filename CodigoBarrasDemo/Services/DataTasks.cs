using CodigoBarrasDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Services
{
    public class DataTasks : IDataTasks<Tarea>
    {
        readonly List<Tarea> tasks;
        public DataTasks() 
        {
            tasks = new List<Tarea>()
            {
                new Tarea{Id = "Q0001",Folio="28153001",IdProcess="A01-002",Process="Punzonado",IdProduct ="G9066B",Product = "PIASTRINA BUSBAR 2500 1015 X 1600",Machine="PUNZADORA TRUMPF 2000",InitialDate="14/11/22",FinalDate="14/12/22",CT="20",CP="0",CF="20",TE="2.75",TR="-2370.78",TF="-2370.78"},
                new Tarea{Id = "Q0001",Folio="29700002",IdProcess="A03-002",Process="Torno",IdProduct ="47524307",Product = "HUB",Machine="MAZAK QTN250-2",InitialDate="14/11/22",FinalDate="14/12/22",CT="250",CP="0",CF="250",TE="17.07",TR="75.75",TF="-58.68"},
                new Tarea{Id = "Q0002",Folio="28153001",IdProcess="A01-002",Process="Punzonado",IdProduct ="G9066B",Product = "PIASTRINA BUSBAR 2500 1015 X 1600",Machine="PUNZADORA TRUMPF 2000",InitialDate="14/11/22",FinalDate="14/12/22",CT="20",CP="0",CF="20",TE="2.75",TR="-2370.78",TF="-2370.78"},
                new Tarea{Id = "Q0002",Folio="29700002",IdProcess="A03-002",Process="Torno",IdProduct ="47524307",Product = "HUB",Machine="MAZAK QTN250-2",InitialDate="14/11/22",FinalDate="14/12/22",CT="250",CP="0",CF="250",TE="17.07",TR="75.75",TF="-58.68"},
                new Tarea{Id = "Q0007",Folio="28153001",IdProcess="A01-002",Process="Punzonado",IdProduct ="G9066B",Product = "PIASTRINA BUSBAR 2500 1015 X 1600",Machine="PUNZADORA TRUMPF 2000",InitialDate="14/11/22",FinalDate="14/12/22",CT="20",CP="0",CF="20",TE="2.75",TR="-2370.78",TF="-2370.78"},
                new Tarea{Id = "Q0007",Folio="29700002",IdProcess="A03-002",Process="Torno",IdProduct ="47524307",Product = "HUB",Machine="MAZAK QTN250-2",InitialDate="14/11/22",FinalDate="14/12/22",CT="250",CP="0",CF="250",TE="17.07",TR="75.75",TF="-58.68"},
                new Tarea{Id = "Q0011",Folio="28153001",IdProcess="A01-002",Process="Punzonado",IdProduct ="G9066B",Product = "PIASTRINA BUSBAR 2500 1015 X 1600",Machine="PUNZADORA TRUMPF 2000",InitialDate="14/11/22",FinalDate="14/12/22",CT="20",CP="0",CF="20",TE="2.75",TR="-2370.78",TF="-2370.78"},
                new Tarea{Id = "Q0011",Folio="29700002",IdProcess="A03-002",Process="Torno",IdProduct ="47524307",Product = "HUB",Machine="MAZAK QTN250-2",InitialDate="14/11/22",FinalDate="14/12/22",CT="250",CP="0",CF="250",TE="17.07",TR="75.75",TF="-58.68"},
                new Tarea{Id = "Q0011",Folio="29700003",IdProcess="A04-002",Process="Cortadora",IdProduct ="H9066B",Product = "HUB",Machine="MAZAK QTN250-2",InitialDate="14/11/22",FinalDate="14/12/22",CT="250",CP="0",CF="250",TE="17.07",TR="75.75",TF="-58.68"},
                new Tarea{Id = "Q0012",Folio="28153001",IdProcess="A01-002",Process="Punzonado",IdProduct ="G9066B",Product = "PIASTRINA BUSBAR 2500 1015 X 1600",Machine="PUNZADORA TRUMPF 2000",InitialDate="14/11/22",FinalDate="14/12/22",CT="20",CP="0",CF="20",TE="2.75",TR="-2370.78",TF="-2370.78"},
                new Tarea{Id = "Q0012",Folio="29700002",IdProcess="A03-002",Process="Torno",IdProduct ="47524307",Product = "HUB",Machine="MAZAK QTN250-2",InitialDate="14/11/22",FinalDate="14/12/22",CT="250",CP="0",CF="250",TE="17.07",TR="75.75",TF="-58.68"},
                new Tarea{Id = "00152",Folio="28153001",IdProcess="A01-002",Process="Punzonado",IdProduct ="G9066B",Product = "PIASTRINA BUSBAR 2500 1015 X 1600",Machine="PUNZADORA TRUMPF 2000",InitialDate="14/11/22",FinalDate="14/12/22",CT="20",CP="0",CF="20",TE="2.75",TR="-2370.78",TF="-2370.78"},
                new Tarea{Id = "00152",Folio="29700002",IdProcess="A03-002",Process="Torno",IdProduct ="47524307",Product = "HUB",Machine="MAZAK QTN250-2",InitialDate="14/11/22",FinalDate="14/12/22",CT="250",CP="0",CF="250",TE="17.07",TR="75.75",TF="-58.68"}
            };
        }

        public async Task<IEnumerable<Tarea>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(tasks);
        }
    }
}
