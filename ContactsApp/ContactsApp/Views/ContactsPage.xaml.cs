﻿using ContactsApp.Persistence;
using ContactsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            var contactStore = new SQLiteContactStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ContactsPageViewModel(contactStore, pageService);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectContactCommand.Execute(e.SelectedItem);
        }

        public ContactsPageViewModel ViewModel
        {
            get { return BindingContext as ContactsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}