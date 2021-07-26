using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace ChatAppSample.Helpers
{
    public static class Toast
    {
        public static async Task ShowSuccessAsync(this Page page, string message, int duration = 3000)
        {
            var config = new MessageOptions()
            {
                Foreground = Color.White,
                Font = Font.SystemFontOfSize(17),
                Message = message,
            };

            var toastConfig = new ToastOptions()
            {
                MessageOptions = config,
                BackgroundColor = Color.Green,
                Duration = TimeSpan.FromMilliseconds(duration),
                CornerRadius = 5,
                IsRtl = false
            };

            await page.DisplayToastAsync(toastConfig);
        }
    }
}
