using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodigoBarrasDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanDetail : ContentPage
    {
        ScanDetailViewModel _viewModel;
        public ScanDetail(string DataEntry)
        {
            InitializeComponent();
            BindingContext = _viewModel = new ScanDetailViewModel(DataEntry);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedOption = (sender as Picker).SelectedItem;
            _viewModel.ChangeOptionCommand.Execute(selectedOption);
        }
    }

    
}