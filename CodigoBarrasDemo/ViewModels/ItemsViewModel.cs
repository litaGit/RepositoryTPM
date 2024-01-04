using Acr.UserDialogs;
using CodigoBarrasDemo.Interfaces;
using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.Services;
using CodigoBarrasDemo.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CodigoBarrasDemo.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private WorkersItemModel _selectedItem;
        public int numberTasks { get; set; }
        public int TagActionSheet { get; set; }

        public IWorkersService _workersService = new WorkersService();
        public Command SelectedOptionCommand { get; set; }
        public ObservableCollection<WorkersItemModel> Items { get; set; }
        public ObservableCollection<CatalogWorkersFilterModel> CatalogFilters { get; set; }
        public ObservableCollection<Tarea> Tasks { get; }
        public ObservableCollection<Tarea> TareaAux { get; }
        public Command LoadItemsCommand { get; }
        public Command FilterCommand { get; }
        public Command AddItemCommand { get; }
        public Command SearchCommand { get; }
        public Command<WorkersItemModel> ItemTapped { get; }

        public ItemsViewModel()
        {
            NameLogin = Preferences.Get("nameLogin","defaultValue");
            Title = "Recursos Humanos";
            Items = new ObservableCollection<WorkersItemModel>();
            CatalogFilters = new ObservableCollection<CatalogWorkersFilterModel>();
            Tasks = new ObservableCollection<Tarea>();
            numberTasks = 0;
            GetCatalogValues();
            FilterCommand = new Command(async () => await ExecuteMenuCommand());
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<WorkersItemModel>(OnItemSelected);
            SelectedOptionCommand = new Command<CatalogWorkersFilterModel>(GetFilterSelect);
            SearchCommand = new Command<object>(Search);
        }

        void Search(object obj)
        {
            var text = (string)obj;
            var textUpper = text.ToUpper();

            if (!string.IsNullOrEmpty(textUpper)) {
                var employeeContains = Items.Where(c => c.employeeName.Contains(textUpper));
                Items = new ObservableCollection<WorkersItemModel>(employeeContains);
                OnPropertyChanged("Items");
            } 
            else {
                GetCatalogValues();
            }
                
            

        }
        async Task GetCatalogValues() 
        {
            var items = await _workersService.GetWorkers();
            CatalogWorkersFilterModel item1 = new CatalogWorkersFilterModel { IdFilter = 0, NameFilter = "Todos" };
            CatalogWorkersFilterModel item2 = new CatalogWorkersFilterModel { IdFilter = 1, NameFilter = "En turno" };
            CatalogWorkersFilterModel item3 = new CatalogWorkersFilterModel { IdFilter = 2, NameFilter = "Inactivos" };
            CatalogWorkersFilterModel item4 = new CatalogWorkersFilterModel { IdFilter = 3, NameFilter = "En actividad"};
            CatalogFilters.Add(item1);
            CatalogFilters.Add(item2);
            CatalogFilters.Add(item3);
            CatalogFilters.Add(item4);
            SelectedFilter = CatalogFilters[0];
            await GetActionFilter(SelectedFilter);
        }
        private void GetFilterSelect(CatalogWorkersFilterModel obj)
        {
            SelectedFilter = obj;
            GetActionFilter(SelectedFilter);
        }
        async Task GetActionFilter(CatalogWorkersFilterModel selectedOption) 
        {
            var Workers = await _workersService.GetWorkers();
            switch (selectedOption.IdFilter) 
            {
                case 0:
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");
                    foreach (var item in Workers)
                    {
                        Items.Add(item);
                    }
                   
                    break;

                case 1:
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");
                    foreach (var item in Workers)
                    {
                        var fecha = item.infoTurn.Substring(0,1);
                        if (fecha != " ") 
                        {
                            Items.Add(item);
                        }
                        
                    }
                    break;

                case 2:
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");
                    foreach (var item in Workers)
                    {
                        var date = item.infoTurn.Substring(0,1);
                        if (date == " ")
                        {
                            Items.Add(item);
                        }
                    }
                    break;
                case 3:
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");
                    foreach (var item in Workers)
                    {
                        var task = item.infoTask.Substring(0, 1);
                        if (task != " ")
                        {
                            Items.Add(item);
                        }
                    }
                    break;

                default:

                    break;
            }
            UserDialogs.Instance.HideLoading();


        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                await GetActionFilter(SelectedFilter);
                
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
        async Task ExecuteMenuCommand() {
            var actionSheet = await App.Current.MainPage.DisplayActionSheet("", "Cancel", null, "Todos", "En turno", "Inactivos","En actividad");
            var Workers = await _workersService.GetWorkers();
            switch (actionSheet) 
            {
                case "Todos":
                    SelectedFilter.IdFilter = 0;
                    SelectedFilter.NameFilter = "Todos";
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");

                    foreach (var item in Workers)
                    {
                        Items.Add(item);
                    }

                    UserDialogs.Instance.HideLoading();
                    break;

                case "En turno":
                    SelectedFilter.IdFilter = 1;
                    SelectedFilter.NameFilter = "En Turno";
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");
                    foreach (var item in Workers)
                    {
                        var fecha = item.infoTurn.Substring(0, 1);
                        if (fecha != " ")
                        {
                            Items.Add(item);
                        }

                    }
                    UserDialogs.Instance.HideLoading();
                    break;
                case "Inactivos":
                    SelectedFilter.IdFilter = 2;
                    SelectedFilter.NameFilter = "Inactivos";
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");
                    foreach (var item in Workers)
                    {
                        var date = item.infoTurn.Substring(0, 1);
                        if (date == " ")
                        {
                            Items.Add(item);
                        }
                    }
                    UserDialogs.Instance.HideLoading();
                    break;
                case "En actividad":
                    SelectedFilter.IdFilter = 3;
                    SelectedFilter.NameFilter = "En actividad";
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");
                    foreach (var item in Workers)
                    {
                        var task = item.infoTask.Substring(0, 1);
                        if (task != " ")
                        {
                            Items.Add(item);
                        }
                    }
                    UserDialogs.Instance.HideLoading();
                    break;
                default:
                    Items.Clear();
                    UserDialogs.Instance.ShowLoading("Cargando...");
                    foreach (var item in Workers)
                    {
                        Items.Add(item);
                    }
                    UserDialogs.Instance.HideLoading();
                    break;
                 

            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public WorkersItemModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }


        async void OnItemSelected(WorkersItemModel item)
        {
           // if (item == null)
             //   return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        
    }
}