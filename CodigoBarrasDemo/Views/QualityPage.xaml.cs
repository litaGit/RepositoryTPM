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
    public partial class QualityPage : ContentPage
    {
        QualityViewModel _viewModel;
        private Tarea tarea;
        private WorkersItemModel item1;

        public QualityPage(Tarea tarea, WorkersItemModel item)
        {
            InitializeComponent();
            BindingContext = _viewModel = new QualityViewModel(tarea,item);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}