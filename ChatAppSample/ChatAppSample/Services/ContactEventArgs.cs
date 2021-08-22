using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ChatAppSample.Services
{
    public class ContactEventArgs : EventArgs
    {
        public Contact MyProperty { get; set; }
    }
}
