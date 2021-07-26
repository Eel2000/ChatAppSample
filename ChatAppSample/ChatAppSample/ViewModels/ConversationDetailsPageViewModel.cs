using ChatAppSample.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ChatAppSample.ViewModels
{
    class ConversationDetailsPageViewModel : BaseViewModel
    {

        private ObservableCollection<Message> _messages;

        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        public ICommand BackCommand { get; set; }
        public ConversationDetailsPageViewModel(string phone = null)
        {
            Title = phone ?? "Default";
            BackCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopModalAsync(true);
            });

            Messages = new ObservableCollection<Message>
            {
                new Message
                { 
                    Id=1, 
                    Body="Hello!✌",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=true
                },
                new Message
                { 
                    Id=1,
                    Body="Hello!😁", 
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=false
                },
                new Message
                { 
                    Id=1,
                    Body="Hello!✌ i'm fine guys what's up to you?",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=true
                },
                new Message
                { 
                    Id=1,
                    Body="😂 are you good?",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=false
                },
                new Message
                { 
                    Id=1,
                    Body="😂 LOL",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=false
                },
                new Message
                { 
                    Id=1,
                    Body="😂 why are you laughing?",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=true
                },
                new Message
                { 
                    Id=1,
                    Body="😂 are you good?",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=false
                },
            };
        }
    }
}
