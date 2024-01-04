using CodigoBarrasDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodigoBarrasDemo.ViewModels
{
    [QueryProperty(nameof(Tarea), "tarea")]
    public class QualityViewModel : BaseViewModel
    {
        private WorkersItemModel item;
        private Tarea tarea;
        public Command SaveInfoCommand { get; }
        public WorkersItemModel Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
               
            }
        }
        public Tarea Tarea
        {
            get
            {
                return tarea;
            }
            set
            {
                tarea = value;
               
            }
        }
        public QualityViewModel(Tarea tarea, WorkersItemModel item) 
        {
            this.DisplayData(tarea,item);
            SaveInfoCommand = new Command(async () => await ExecuteSaveTasksCommand());
        }

        public void DisplayData(Tarea tarea, WorkersItemModel item) 
        {
            if (tarea != null && item != null)
            {
               // Odp = "";
                //IdEmployee = item.Id;
                //Process = tarea.IdProcess;
                //Machine = tarea.Machine;
                //Date = tarea.FinalDate;
                //Hour = item.Hours;
                Quantity = "10";
                Status = "Terminado";
            }
            else 
            {
                Odp = "";
                IdEmployee = "";
                Process = "";
                Machine = "";
                Date = "";
                Hour = "";
                Quantity = "10";
            }
        }
        async Task ExecuteSaveTasksCommand()
        {
            
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

    }
}
