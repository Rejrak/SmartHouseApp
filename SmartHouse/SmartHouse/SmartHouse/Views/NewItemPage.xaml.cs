using SmartHouse.Models;
using SmartHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHouse.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
        public NewItemPage(string itemid)
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel(itemid);
        }
    }
}