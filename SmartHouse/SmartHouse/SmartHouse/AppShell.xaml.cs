using SmartHouse.ViewModels;
using SmartHouse.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SmartHouse
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
