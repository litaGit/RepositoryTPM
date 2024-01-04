using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace CodigoBarrasDemo.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private Tarea _selectedTarea;
        WorkersItemModel item1 = null;
        public ObservableCollection<Tarea> Tasks { get; }
        public ObservableCollection<Tarea> TareaAux { get; }
        public Command LoadTaskCommand { get; }
        public Command<Tarea> TasksTapped { get; }

        private string itemId;
        private string name;
        private string position;
        private string hour;
        private string date;
        private string photo;
        private string id;
        private int numberTask;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }
        public string Hours
        {
            get => hour;
            set => SetProperty(ref hour, value);
        }
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public int NumberTasks
        {
            get => numberTask;
            set => SetProperty(ref numberTask, value);
        }

        public string Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }

        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public Tarea SelectedTarea
        {
            get => _selectedTarea;
            set
            {
                SetProperty(ref _selectedTarea, value);
                OnItemSelected(value);
            }
        }

        public ItemDetailViewModel()
        {
            Title = "Lista de Tareas";
            Tasks = new ObservableCollection<Tarea>();
            TareaAux = new ObservableCollection<Tarea>();
            LoadTaskCommand = new Command(async () => await ExecuteLoadTasksCommand());
            TasksTapped = new Command<Tarea>(OnItemSelected);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedTarea = null;
        }

        public async void LoadItemId(string itemId)
        {
       /*     try
            {
                item1 = await DataStore.GetItemAsync(itemId);
                Id = item1.Id;
                Name = item1.Name;
                Position = item1.Position;
                Date = item1.Date;
                Hours = item1.Hours;
                Photo = item1.Photo;
                NumberTasks = item1.NumberTasks;


            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }*/
        }
        

        async Task ExecuteLoadTasksCommand()
        {
            IsBusy = true;

            try
            {
                Tasks.Clear();
                TareaAux.Clear();
                var tareas = await DataTask.GetItemsAsync(true);
                foreach (var tarea in tareas)
                {
                    TareaAux.Add(tarea);
                }
                var tareasAux = from tarea in TareaAux
                                where tarea.Id == ItemId
                                group tarea by id;

                foreach (var tarea in tareasAux)
                {
                    foreach (var i in tarea) 
                    {
                        Tasks.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

       

        async void OnItemSelected(Tarea tarea)
        {
            if (tarea == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await App.Current.MainPage.Navigation.PushAsync(new QualityPage(tarea, item1));


        }
    }
}
