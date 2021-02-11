using SmartHouse.Models;
using SmartHouse.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHouse.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string ID;
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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public Command DeleteCommand { get; }
        public Command EditCommand { get; }

        public ItemDetailViewModel()
        {
            DeleteCommand = new Command(OnDelete);
            EditCommand = new Command(OnEdit);
        }

        private async void OnEdit(object obj)
        {

            await Shell.Current.Navigation.PushAsync(new NewItemPage(ItemId));
        }

        private async void OnDelete(object obj)
        {
            await DataStore.DeleteItemAsync(ItemId);
            await Shell.Current.GoToAsync("..");
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                ID = item.ID;
                Name = item.Name;
                Description = item.Description;
                IPAddress = item.IPAddress;
                Port = item.PortNumber;
                Available = item.Available;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
