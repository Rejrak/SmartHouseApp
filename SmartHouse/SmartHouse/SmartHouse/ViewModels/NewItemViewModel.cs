using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHouse.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NewItemViewModel : BaseViewModel
    {
        private string ItemId;

        private string name;
        private string description;
        private string ipaddress;
        private string port;
        private bool available;



        public string IPAddress
        {
            get => ipaddress;
            set => SetProperty(ref ipaddress, value);
        }
        public string Port
        {
            get => port;
            set => SetProperty(ref port, value);
        }
        public bool Available
        {
            get => available;
            set => SetProperty(ref available, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command UpdateCommand { get; }

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public NewItemViewModel(string ItemId)
        {
            this.ItemId = ItemId;
            LoadItem();

            SaveCommand = new Command(OnUpdate, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

        }

        private async void LoadItem()
        {
            try
            {
                var oldItem = await DataStore.GetItemAsync(ItemId);
                this.Name = oldItem.Name;
                this.Description = oldItem.Description;
                this.IPAddress = oldItem.IPAddress;
                this.Port = oldItem.PortNumber;
                this.Available = oldItem.Available;
            }
            catch (Exception e)
            {

                Debug.WriteLine("Failed to Load Item  " + e.Message);
            }
            
            
        }

        private async void OnUpdate()
        {
            Item newItem = new Item()
            {
                ID = this.ItemId,
                Name = this.Name,
                Description = this.Description,
                IPAddress = this.IPAddress,
                PortNumber = this.Port,
                Available = this.Available
            };

            await DataStore.UpdateItemAsync(newItem);

            await Shell.Current.Navigation.PopToRootAsync();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(ipaddress)
                && !String.IsNullOrWhiteSpace(port);
        }


        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                ID = Guid.NewGuid().ToString(),
                Name = this.Name,
                Description = this.Description,
                IPAddress = this.IPAddress,
                PortNumber = this.Port,
                Available = this.Available
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
