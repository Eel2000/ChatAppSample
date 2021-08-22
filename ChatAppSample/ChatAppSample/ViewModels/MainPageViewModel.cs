using ChatAppSample.Helpers;
using ChatAppSample.Models;
using ChatAppSample.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatAppSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Conversation> conversations;

        public ObservableCollection<Conversation> Messages
        {
            get => conversations;
            set => SetProperty(ref conversations, value);
        }

        public ICommand SelectConversationCommand { get; set; }
        public ICommand AddConversationCommand { get; set; }

        public MainPageViewModel()
        {
            Title = "ChatMe";
            Messages = new ObservableCollection<Conversation>()
            {
                new Conversation
                { 
                    ContactName="Ushma",
                    LastRead="Hi! tell me, what's up today with xamarin.forms?😒",
                    Time=DateTime.Now
                },
                new Conversation
                { 
                    ContactName="Srydevi",
                    LastRead="Hi! watch this amazing template.😍",
                    Time=DateTime.Now
                }
            };

            SelectConversationCommand = new Command<Conversation>(async (Conversation) =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ConversationDetailsPage(Conversation.ContactName));
                //await App.Current.MainPage.ShowSuccessAsync($"{Conversation.ContactName} conversation opened");
            });

            AddConversationCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ContactsPage());
            });
        }
    }
}
