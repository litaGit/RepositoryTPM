using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode.Internal;

namespace CodigoBarrasDemo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        
        public AboutViewModel()
        {
            DataEntry = string.Empty;
            Title = "Almacén";
            OpenWebCommand = new Command(async () => await ScanAsync()); ;
            ScanPageCommand = new Command(async () => await ScanChangePage());
        }

        public ICommand OpenWebCommand { get; }
        public ICommand ScanPageCommand { get; }
        

        async Task ScanAsync()
        {
                DataEntry = ResultBarcode.Text;
        }
        async Task ScanChangePage()
        {
            if (DataEntry != string.Empty)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ScanDetail(DataEntry));
                DataEntry= string.Empty;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("","No hay información para buscar","Ok");
            }
            
        }
    }
}