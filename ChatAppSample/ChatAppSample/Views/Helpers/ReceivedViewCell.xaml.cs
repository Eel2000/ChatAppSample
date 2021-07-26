using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatAppSample.Views.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceivedViewCell : ViewCell
    {
        public ReceivedViewCell()
        {
            InitializeComponent();
        }
    }
}