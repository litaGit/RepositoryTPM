using CodigoBarrasDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodigoBarrasDemo.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string name;
        private string position;
        private string status;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(position)
                && !String.IsNullOrWhiteSpace(status);
        }

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
        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
           /* WorkersItemM newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Position = Position,
                Date = Status
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");*/
        }
    }
}
