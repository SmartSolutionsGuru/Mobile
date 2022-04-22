using SmartSolutions.Mobile.iOS.Renderer;
using SmartSolutions.Mobile.Rendrer;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SmartSolutions.Mobile.iOS.Renderer
{
    public class UIBackwardsTextField : UITextField
    {
        // A delegate type for hooking up change notifications.
        public delegate void DeleteBackwardEventHandler(object sender, EventArgs e);

        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public event DeleteBackwardEventHandler OnDeleteBackward;
        public void OnDeleteBackwardPressed()
        {
            if (OnDeleteBackward != null)
            {
                OnDeleteBackward(null, null);
            }
        }

        public UIBackwardsTextField()
        {
            BorderStyle = UITextBorderStyle.RoundedRect;
            ClipsToBounds = true;
        }

        public override void DeleteBackward()
        {
            base.DeleteBackward();
            OnDeleteBackwardPressed();
        }
    }
    public class CustomEntryRenderer : EntryRenderer, IUITextFieldDelegate
    {
        IElementController ElementController => Element as IElementController;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            if (Element == null)
            {
                return;
            }

            var entry = (CustomEntry)Element;
            var textField = new UIBackwardsTextField();

            textField.EditingChanged += OnEditingChanged;
            textField.OnDeleteBackward += (sender, a) =>
            {
                entry.OnBackspacePressed();
            };

            SetNativeControl(textField);

            base.OnElementChanged(e);
        }

        void OnEditingChanged(object sender, EventArgs eventArgs)
        {
            ElementController.SetValueFromRenderer(Entry.TextProperty, Control.Text);
        }

        public delegate void DeleteBackwardEventHandler(object sender, EventArgs e);

        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public event DeleteBackwardEventHandler OnDeleteBackward;
        public void OnDeleteBackwardPressed()
        {
            if (OnDeleteBackward != null)
            {
                OnDeleteBackward(null, null);
            }
        }
    }


}