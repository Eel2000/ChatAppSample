using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppSample.ViewModels
{
    public class ContactsPageViewModel : BaseViewModel
    {
        private string _backArrow;

        public string BackArrow
        {
            get => _backArrow;
            set => SetProperty(ref _backArrow, value);
        }

        public ContactsPageViewModel()
        {
            BackArrow = "\u2190";
        }
    }
}
