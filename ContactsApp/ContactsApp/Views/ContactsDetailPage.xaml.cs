using ContactsApp.Persistence;
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
    public partial class ContactsDetailPage : ContentPage
    {
        public ContactsDetailPage(ContactViewModel viewModel)
        {
            InitializeComponent();
            var contactStore = new SQLiteContactStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Phone == null) ? "New Contact" : "Edit Contact";
            BindingContext = new ContactsDetailViewModel(viewModel ?? new ContactViewModel(), contactStore, pageService);
        }
    }
}