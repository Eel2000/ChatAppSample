using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatAppSample.Controls;
using ChatAppSample.Droid.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(CustomEntry),typeof(DroidCustomEntry))]
namespace ChatAppSample.Droid.CustomControls
{
    [Obsolete]
    public class DroidCustomEntry : EntryRenderer
    {
        public DroidCustomEntry(Context context):base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                Control.Bottom = 10;
                Control.SetPadding(40, 0, 0, 5);

                int[][] states = new int[][]
                {
                    new int[]{ -Android.Resource.Attribute.StateFocused},
                    new int[]{ Android.Resource.Attribute.StateFocused},
                };

                int[] colors = new int[] { Color.Black.ToAndroid(), Color.FromHex("#FF4081").ToAndroid() };

                ColorStateList colorStateList = new ColorStateList(states, colors);

                GradientDrawable gradientDrawable = new GradientDrawable();

                gradientDrawable.SetCornerRadius(50);

                Control.Background = gradientDrawable;

                gradientDrawable.SetStroke(2, colorStateList);
            }
        }
    }
}