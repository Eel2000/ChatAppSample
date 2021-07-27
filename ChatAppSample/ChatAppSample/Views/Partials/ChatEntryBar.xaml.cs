using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatAppSample.Views.Partials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatEntryBar : ContentPage
    {
        public ChatEntryBar()
        {
            InitializeComponent();
        }

        private void chatInput_Completed(object sender, EventArgs e)
        {

        }
    }
}