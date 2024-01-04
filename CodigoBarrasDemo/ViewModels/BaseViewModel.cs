using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;

namespace CodigoBarrasDemo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataTasks<Tarea> DataTask => DependencyService.Get<IDataTasks<Tarea>>();
        public IDataAlmacen<Almacen> DataAlmacen => DependencyService.Get<IDataAlmacen<Almacen>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string nameLogin = string.Empty;
        public string NameLogin
        {
            get { return nameLogin; }
            set { SetProperty(ref nameLogin, value); }
        }

        private Result result;

        public Result ResultBarcode
        {
            get { return result; }
            set { SetProperty(ref result, value); }
         
        }

        string dataEntry = string.Empty;
        public string DataEntry
        {
            get { return dataEntry; }
            set { SetProperty(ref dataEntry, value); }
        }

        private string user;
        public string User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string productCode;
        public string ProductCode
        {
            get { return productCode; }
            set { SetProperty(ref productCode, value); }
        }

        private string productName;
        public string ProductName 
        {
            get { return productName; }
            set { SetProperty(ref productName, value);}
        }

        private string barCode;
        public string BarCode
        {
            get { return barCode; }
            set { SetProperty(ref barCode, value); }
        }

        private string locationStoke;
        public string LocationStoke
        {
            get { return locationStoke; }
            set { SetProperty(ref locationStoke, value); }
        }
        private double existence;
        public double Existence
        {
            get { return existence; }
            set { SetProperty(ref existence, value); }
        }

        
        private string ubicacionAlmacen;
        public string UbicacionAlmacen
        {
            get { return ubicacionAlmacen; }
            set { SetProperty(ref ubicacionAlmacen, value); }
        }
        private double totalAlmacen;
        public double TotalAlmacen
        {
            get { return totalAlmacen; }
            set { SetProperty(ref totalAlmacen, value); }
        }

        private string idEmployee;
        public string IdEmployee 
        {
            get { return idEmployee; }
            set { SetProperty(ref idEmployee, value);}
        }

        private string status;
        public string Status 
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }
        private string quantity;

        public string Quantity 
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
        private string process;
        public string Process 
        {
            get { return process; }
            set { SetProperty(ref process, value); }
        }

        private string machine;
        public string Machine 
        {
            get { return machine; }
            set { SetProperty(ref machine, value); }
        }
        private string date;
        public string Date 
        {
            get { return date; }
            set { SetProperty(ref date, value);}
        }
        private string hour;
        public string Hour 
        {
            get { return hour; }
            set { SetProperty(ref hour, value);}
        }

        private string odp;
        public string Odp 
        {
            get { return odp; }
            set { SetProperty(ref odp, value);}
        }
        private bool isVisibleButton;
        public bool IsVisibleButton 
        {
            get { return isVisibleButton; }
            set { SetProperty(ref isVisibleButton, value); }
        }
         
        private string newExistence;
        public string NewExistence
        {
            get { return newExistence; }
            set { SetProperty(ref newExistence, value); }

            
        }

        private Xamarin.Forms.ImageSource imageProduct;
        public Xamarin.Forms.ImageSource ImageProduct 
        {
            get { return imageProduct; }
            set { SetProperty(ref imageProduct, value); }
        }

        private Xamarin.Forms.ImageSource imageUser;
        public Xamarin.Forms.ImageSource ImageUser
        {
            get { return imageUser; }
            set { SetProperty(ref imageUser, value); }
        }

        private CatalogValuesModel _selectedProduct;
        public CatalogValuesModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    SetProperty(ref _selectedProduct, value);
                }
            }
        }
        private CatalogWorkersFilterModel _selectedFilter;
        public CatalogWorkersFilterModel SelectedFilter
        {
            get { return _selectedFilter; }
            set
            {
                if (_selectedFilter != value)
                {
                    SetProperty(ref _selectedFilter, value);
                }
            }
        }

        private string comentario;
        public string Comentario
        {
            get { return comentario; }
            set { SetProperty(ref comentario, value); }
        }

        private string sucursal;
        public string Sucursal
        {
            get { return sucursal; }
            set { SetProperty(ref sucursal, value); }
        }
        private string almacen;
        public string Almacen
        {
            get { return almacen; }
            set { SetProperty(ref almacen, value); }
        }
        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set { SetProperty(ref isChecked, value); }
        }
        private string productAlmacen;
        public string ProductAlmacen
        {
            get { return productAlmacen; }
            set { SetProperty(ref productAlmacen, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
