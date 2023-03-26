using ExpensesApp.iOS.Effects;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(SelectedEffect), nameof(SelectedEffect))]
namespace ExpensesApp.iOS.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        UIColor _selectedColor;

        protected override void OnAttached()
        {
            _selectedColor = new UIColor(176f/255,152f/255,164f/255, 1f);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if(args.PropertyName == "IsFocused")
            {
                if(Control.BackgroundColor != _selectedColor)
                {
                    Control.BackgroundColor = _selectedColor;
                }
                else
                {
                    Control.BackgroundColor = UIColor.White;
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }
}