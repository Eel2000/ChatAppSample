using ChatAppSample.Models;
using ChatAppSample.Views.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatAppSample.Controls
{
    public class DataSelector : DataTemplateSelector
    {
        DataTemplate Received;
        DataTemplate Sent;

        public DataSelector()
        {
            this.Received = new DataTemplate(typeof(ReceivedViewCell));
            this.Sent = new DataTemplate(typeof(SentViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            try
            {
                var message = item as Message;
                if (message != null)
                {
                    return message.State ? Received : Sent;
                }
            }
            catch (Exception w)
            {
                System.Diagnostics.Debug.WriteLine(w, "DataSelector");
            }
            return null;
        }
    }
}
