using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.ViewModels;
using CodigoBarrasDemo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodigoBarrasDemo.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedOption = (sender as Picker).SelectedItem;
            _viewModel.SelectedOptionCommand.Execute(selectedOption);
        }
    }
}