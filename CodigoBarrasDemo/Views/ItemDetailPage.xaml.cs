using CodigoBarrasDemo.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CodigoBarrasDemo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel _viewModel;
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemDetailViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}