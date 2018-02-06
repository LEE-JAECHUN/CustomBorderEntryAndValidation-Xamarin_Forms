/*
 * 참조 : https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/
 *       https://github.com/Microsoft/SmartHotel360
 *       https://github.com/Microsoft/SmartHotel360-mobile-desktop-apps/blob/master/src/SmartHotel.Clients/SmartHotel.Clients/Controls/ExtendedEntry.cs
 */
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace EntryEffectAndValidation.Core.Controls
{
    public class ExtendedEntry : Entry
    {
        #region Private Fileds
        private Color _borderColorToApply;
        #endregion

        public ExtendedEntry()
        {
            Focused += OnFocused;
            Unfocused += OnUnfocused;

            ResetBorderColor();
        }

        #region General Public Property
        public Color BorderColorToApply
        {
            get
            {
                return _borderColorToApply;
            }
            private set
            {
                _borderColorToApply = value;
                OnPropertyChanged(nameof(BorderColorToApply));
            }
        }
        #endregion

        #region Binderable Property
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ExtendedEntry), Color.Default);

        public static readonly BindableProperty BorderWidthProperty = 
            BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(ExtendedEntry), GetDefaultBorderWidth());

        public static readonly BindableProperty FocusBorderColorProperty =
            BindableProperty.Create(nameof(FocusBorderColor), typeof(Color), typeof(ExtendedEntry), Color.Default);

        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ExtendedEntry), true);

        public static readonly BindableProperty InvalidBorderColorProperty =
            BindableProperty.Create(nameof(InvalidBorderColor), typeof(Color), typeof(ExtendedEntry), Color.Default);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public Color FocusBorderColor
        {
            get { return (Color)GetValue(FocusBorderColorProperty); }
            set { SetValue(FocusBorderColorProperty, value); }
        }

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        public Color InvalidBorderColor
        {
            get { return (Color)GetValue(InvalidBorderColorProperty); }
            set { SetValue(InvalidBorderColorProperty, value); }
        }
        #endregion

        #region Override Method 
        protected override void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsValidProperty.PropertyName)
            {
                CheckValidity();
            }
        }
        #endregion

        #region Private Method
        private static int GetDefaultBorderWidth()
        {
            int width;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    width = 1;
                    break;
                default:
                    width = 2;
                    break;
            }

            return width;
        }

        private void OnFocused(object sender, FocusEventArgs e)
        {
            IsValid = true;
            BorderColorToApply = FocusBorderColor != Color.Default ? FocusBorderColor : GetNormalStateLineColor();
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            ResetBorderColor();
        }

        private void ResetBorderColor()
        {
            BorderColorToApply = GetNormalStateLineColor();
        }

        private void CheckValidity()
        {
            if (!IsValid)
            {
                BorderColorToApply = InvalidBorderColor;
            }
        }

        private Color GetNormalStateLineColor()
        {
            return BorderColor != Color.Default ? BorderColor : TextColor;
        }
        #endregion
    }
}
