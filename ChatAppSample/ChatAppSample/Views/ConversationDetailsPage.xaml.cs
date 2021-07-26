using ChatAppSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatAppSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationDetailsPage : ContentPage
    {
        public ConversationDetailsPage()
        {
            InitializeComponent();
            BindingContext = new ConversationDetailsPageViewModel();
        }

        public ConversationDetailsPage(string phone)
        {
            InitializeComponent();
            BindingContext = new ConversationDetailsPageViewModel(phone);
        }
    }
}