using SmartHouse.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SmartHouse.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}