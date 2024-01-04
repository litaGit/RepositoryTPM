using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.QrCode.Internal;
using ZXing;
using CodigoBarrasDemo.Interfaces;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Essentials;

namespace CodigoBarrasDemo.ViewModels
{
    public class ScanDetailViewModel : BaseViewModel
    {
        public IStokeService _stokeService = new StokeService();
        public IInventoryService _inventoryService = new InventoryService();
        public ObservableCollection<StokeResponseModel> Stoke { get; }
        public ObservableCollection<CatalogValuesModel> Catalog { get; }
        public Command LoadItemsCommand { get; }
        public Command ChangeOptionCommand { get; set; }
        public Command TextChangeCommand { get; set; }
        public Command CommentChangeCommand { get; set; }
        public Command SaveInfoCommand { get; set; }
        public Command TextChangeLocationCommand { get; set; }
        public Command CheckedChangeCommand { get; set; }
        public Almacen _dataAlmacen { get; set; }
        public String source { get; set; }
        public string lastUbication { get; set; }
        public string lastExistence { get; set; }

        StokeRequestModel codeProduct = new StokeRequestModel();

        private CatalogValuesModel selectCatalogIndex { get; set; }
        public CatalogValuesModel SelectCatalogIndex
        {
            get { return selectCatalogIndex; }
            set
            {
                if (selectCatalogIndex != value)
                {
                    selectCatalogIndex = value;
                    GetStokes(selectCatalogIndex);
                }
            }
        }
        public ScanDetailViewModel(string dataEntry) 
        {
            IsChecked = false;
            IsVisibleButton = false;
            ProductCode = dataEntry;
            StokeRequestModel Product = new StokeRequestModel 
            {
                productCode = ProductCode
            };
            codeProduct = Product;
            Catalog = new ObservableCollection<CatalogValuesModel>();
            Stoke = new ObservableCollection<StokeResponseModel>();
            GetImage();
            GetCatalogStoke();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            TextChangeCommand = new Command(async () => await ChangeTextCommand());
            CommentChangeCommand = new Command(async () => await ComentTextCommand());
            SaveInfoCommand = new Command(async () => await SaveInfo());
            TextChangeLocationCommand = new Command(async () => await TextChangeLocation());
            CheckedChangeCommand = new Command(async () => await CheckedChange());
            ChangeOptionCommand = new Command<CatalogValuesModel>(GetStokeSelect);
            
        }

        async Task GetImage() {
            var stoke = await _stokeService.ExistanceStoke(codeProduct);
            TotalAlmacen = 0;
            foreach (var item in stoke) {

                source = item.ImageProduct;
                ProductName = item.ProductName;
                TotalAlmacen = TotalAlmacen + item.Existence;
            }
            if (source == "pieza_image.png")
            {
                ImageProduct = source;
            }
            else {
                ImageProduct = Xamarin.Forms.ImageSource.FromStream(
            () => new MemoryStream(Convert.FromBase64String(source)));
            }
        }
        private void GetStokeSelect(CatalogValuesModel obj)
        {
            GetStokes(obj);
        }

        async Task GetCatalogStoke() 
        {
            var catalogItems = await _stokeService.GetCatalogStokeResponses(codeProduct);
            
            foreach (var itemcatalog in catalogItems)
            {
                CatalogValuesModel catalogItem = new CatalogValuesModel
                {
                    Store = itemcatalog.Store,
                    NameStore = itemcatalog.NameStore
                };
                Catalog.Add(catalogItem);
            }
            if (Catalog.Count == 1 ){
                SelectedProduct = Catalog[0];
            }
        }
        async Task GetStokes(CatalogValuesModel selectOption) 
        {
            var items = await _stokeService.ExistanceStoke(codeProduct);
            
            foreach (var item in items)
            {
                if (item.Store == selectOption.Store) {
                    Sucursal = item.SucursalId;
                    Almacen = item.Store;
                    ProductName = item.ProductName;
                    ProductCode = item.ProductKey;
                    BarCode = item.BarCode;
                    LocationStoke = item.LocationStoke;
                    Existence = item.Existence;
                    item.RealExistence = Convert.ToDouble(NewExistence);
                    lastUbication = item.LocationStoke;
                    lastExistence = item.Existence.ToString();
                }
                
                Stoke.Add(item);
               
            }
            Debug.WriteLine(selectOption);
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Stoke.Clear();
                
                
                
                
                var select = SelectCatalogIndex.NameStore;

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

        async Task ChangeTextCommand() 
        {
            var items = await _stokeService.ExistanceStoke(codeProduct);
            if (NewExistence != "")
            {
                var regex = new System.Text.RegularExpressions.Regex(@"^[0-9]*$");

                if (!regex.IsMatch(NewExistence))
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "Ingresar solo números", "OK");
                    return;
                    
                }

                if (LocationStoke == lastUbication && IsChecked == false && string.IsNullOrEmpty(NewExistence) && string.IsNullOrEmpty(Comentario))
                {
                    IsVisibleButton = false;
                }
                else
                {
                    IsVisibleButton = true;
                }

            }
            else 
            {
                if (LocationStoke == lastUbication && IsChecked == false && string.IsNullOrEmpty(NewExistence) && string.IsNullOrEmpty(Comentario))
                {
                    IsVisibleButton = false;
                }
                else
                {
                    IsVisibleButton = true;
                }
            }
            


        }

        async Task ComentTextCommand()
        {
            var items = await _stokeService.ExistanceStoke(codeProduct);

            if (LocationStoke == lastUbication && IsChecked == false && string.IsNullOrEmpty(NewExistence) && string.IsNullOrEmpty(Comentario))
            {
                IsVisibleButton = false;
            }
            else
            {
                IsVisibleButton = true;
            }

        }
        async Task TextChangeLocation() {
            var items = await _stokeService.ExistanceStoke(codeProduct);
            if (LocationStoke != "")
            {
                if (LocationStoke == lastUbication && IsChecked == false && string.IsNullOrEmpty(NewExistence) && string.IsNullOrEmpty(Comentario))
                {
                    IsVisibleButton = false;
                }
                else
                {
                    IsVisibleButton = true;
                }
            }
            else 
            {
                if (LocationStoke == lastUbication && IsChecked == false && string.IsNullOrEmpty(NewExistence) && string.IsNullOrEmpty(Comentario))
                {
                    IsVisibleButton = false;
                }
                else
                {
                    IsVisibleButton = true;
                }

                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "Ingresa ubicación", "OK");
            }
            
            
        }
        async Task CheckedChange() 
        {
            var items = await _stokeService.ExistanceStoke(codeProduct);

            if (LocationStoke == lastUbication && IsChecked == false && string.IsNullOrEmpty(NewExistence) && string.IsNullOrEmpty(Comentario))
            {
                IsVisibleButton = false;
            }
            else 
            {
                IsVisibleButton = true;
            }

        }
        async Task SaveInfo()
        {
            if (!string.IsNullOrEmpty(LocationStoke))
            {
                if (string.IsNullOrEmpty(NewExistence))
                {
                    NewExistence = lastExistence;
                }
                if (string.IsNullOrEmpty(Comentario))
                {
                    Comentario = " ";
                }
                var impresion = 0;
                if (IsChecked == true)
                {
                    impresion = 1;
                }
                else
                {
                    impresion = 0;
                }
                if (string.IsNullOrEmpty(Almacen)) 
                {
                    Almacen = "0";
                }
                if (string.IsNullOrEmpty(Sucursal)) {
                    Sucursal = "1";
                }
                var dateNow = DateTime.Now;
                InventoryModel dataInsert = new InventoryModel
                {
                    Sucursal = Sucursal,
                    Almacen = Convert.ToInt32(Almacen),
                    Producto = ProductCode,
                    Fecha = dateNow,
                    Hora = DateTime.Now.ToString("h:mm tt"),
                    Usuario = Preferences.Get("userLogin", "defaultValue"),
                    Existencia = Convert.ToDouble(NewExistence),
                    Comentario = Comentario,
                    Etiqueta = impresion,
                    Ubicacion = LocationStoke
                };

                var response = await _inventoryService.InsertInventory(dataInsert);
                if (response == true)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "Se guardo la información correctamente", "OK");
                    await Shell.Current.GoToAsync("//AboutPage");
                }
                else
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "No se pudo guardar la información correctamente, por favor verificar", "OK");

                }
            }
            else 
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "Por favor ingrese la Ubicación correspondiente", "OK");
            }
            
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

       
    }
}
