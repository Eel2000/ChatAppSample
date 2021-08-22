using ChatAppSample.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace ChatAppSample.ViewModels
{
    public class ConversationDetailsPageViewModel : BaseViewModel
    {

        private bool _refrech;
        private bool _isActive;
        private string _message;
        private ObservableCollection<Message> _messages;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        public bool Refrech
        {
            get => _refrech;
            set => SetProperty(ref _refrech, value);
        }

        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        public ICommand BackCommand { get; set; }
        public ICommand SendCommand { get; set; }
        public ICommand LoadCommand { get; set; }
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
                    Id=2,
                    Body="Hello!😁",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=false
                },
                new Message
                {
                    Id=3,
                    Body="Hello!✌ i'm fine guys what's up to you?",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=true
                },
                new Message
                {
                    Id=4,
                    Body="😂 are you good?",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=false
                },
                new Message
                {
                    Id=5,
                    Body="😂 LOL",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=false
                },
                new Message
                {
                    Id=6,
                    Body="😂 why are you laughing?",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=true
                },
                new Message
                {
                    Id=7,
                    Body="😂 are you good?",
                    Sent=((DateTime.Now).ToShortTimeString()),
                    State=false
                },
            };

            int id = Messages.Count;
            SendCommand = new Command(async() =>
            {
                if (string.IsNullOrWhiteSpace(Message)) return;
                var messageToSend = new Message()
                {
                    Id = id++,
                    Body = Message,
                    State = false,
                    Sent = DateTime.Now.ToShortTimeString()
                };

                Message = string.Empty;//free input zone
                IsActive = true;
                Messages.Add(messageToSend);
                MessagingCenter.Send<ConversationDetailsPageViewModel>(this, "Sent");
            });
        }

    }
}
