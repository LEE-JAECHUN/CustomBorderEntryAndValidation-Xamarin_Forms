/*
 * 참조 : https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/
 *       https://github.com/Microsoft/SmartHotel360
 *       https://github.com/Microsoft/SmartHotel360-mobile-desktop-apps/blob/master/src/SmartHotel.Clients/SmartHotel.Clients/Controls/ExtendedEntry.cs
 */
using EntryEffectAndValidation.Core.Controls;
using EntryEffectAndValidation.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace EntryEffectAndValidation.iOS.Controls
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntry ExtendedElementEntry => Element as ExtendedEntry;

        #region Override Method Area
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                UpdateBorderWidth();
                UpdateBorderColor();
                UpdateCursorColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(ExtendedEntry.BorderWidthProperty.PropertyName))
            {
                UpdateBorderWidth();
            }
            else if (e.PropertyName.Equals(nameof(ExtendedEntry.BorderColorToApply)))
            {
                UpdateBorderColor();
            }
            else if (e.PropertyName.Equals(Entry.TextColorProperty.PropertyName))
            {
                UpdateCursorColor();
            }
        }
        #endregion

        #region Private Method Area
        private void UpdateBorderWidth()
        {
            Control.Layer.BorderWidth = ExtendedElementEntry.BorderWidth;
        }

        private void UpdateBorderColor()
        {
            Control.Layer.BorderColor = ExtendedElementEntry.BorderColorToApply.ToCGColor();
        }

        private void UpdateCursorColor()
        {
            Control.TintColor = Element.TextColor.ToUIColor();
        }
        #endregion
    }
}
