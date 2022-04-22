using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartSolutions.Mobile.Droid.Rendrer;
using SmartSolutions.Mobile.Rendrer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(BorderlessEntry),typeof(BorderlessEntryRenderer))]
namespace SmartSolutions.Mobile.Droid.Rendrer
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
                Control.Background = null;
        }
    }
}