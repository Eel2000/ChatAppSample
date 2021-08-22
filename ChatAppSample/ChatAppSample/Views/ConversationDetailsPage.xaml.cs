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
        public ConversationDetailsPageViewModel conversation;
        public ConversationDetailsPage()
        {
            InitializeComponent();
            conversation = new ConversationDetailsPageViewModel();
            BindingContext = conversation;
        }

        public ConversationDetailsPage(string phone)
        {
            InitializeComponent();
            conversation = new ConversationDetailsPageViewModel(phone);
            BindingContext = conversation;

            MessagingCenter.Subscribe<ConversationDetailsPageViewModel>(this, "Sent", (sender) =>
              {
                  Device.BeginInvokeOnMainThread(() =>
                  {
                      this.Messages.ScrollTo(sender.Messages[sender.Messages.Count - 1], ScrollToPosition.End, true);
                  });
              });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //conversation.LoadCommand = new Command(() =>
            //{
            //    if (conversation.Messages.Count > 0)
            //    {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Messages.ScrollTo(conversation.Messages[conversation.Messages.Count - 1], ScrollToPosition.End, true);
                    });
            //    }
            //});
        }
    }
}