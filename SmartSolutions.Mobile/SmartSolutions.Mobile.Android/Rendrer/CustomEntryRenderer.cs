using Android.Content;
using Android.Views;
using SmartSolutions.Mobile.Droid.Rendrer;
using SmartSolutions.Mobile.Rendrer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SmartSolutions.Mobile.Droid.Rendrer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        #region [Constructor]
        public CustomEntryRenderer(Context context) : base(context)
        {
        }
        #endregion

        #region [Methods]
        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.Action == KeyEventActions.Down)
            {
                if (e.KeyCode == Keycode.Del)
                {
                    if (string.IsNullOrWhiteSpace(Control.Text))
                    {
                        var entry = (CustomEntry)Element;
                        entry.OnBackspacePressed();
                    }
                }
            }
            return base.DispatchKeyEvent(e);
        }
        #endregion
    }
}