using System;
using Xamarin.Forms;

namespace SmartSolutions.Mobile.Rendrer
{
    /// <summary>
    /// Class for Creating new Entry With single Digit
    /// </summary>
    public class CustomEntry : Entry
    {
        #region [Delegate]

        public delegate void BackspaceEventHandler(object sender, EventArgs e);
        #endregion

        #region [Events]

        public event BackspaceEventHandler OnBackspace;
        #endregion

        #region [Constructor]
        public CustomEntry() { }
        #endregion

        #region [Methods]
        public void OnBackspacePressed()
        {
            if (OnBackspace != null)
            {
                OnBackspace(null, null);
            }

        }
        #endregion
    }
}
