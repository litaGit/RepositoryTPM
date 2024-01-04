using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodigoBarrasDemo.Views
{
    public partial class NewItemPage : ContentPage
    {
        public WorkersItemModel Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}