using Android.Graphics.Drawables;
using ExpensesApp.Droid.Effects;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("CCT")]
[assembly: ExportEffect(typeof(SelectedEffect), nameof(SelectedEffect))]
namespace ExpensesApp.Droid.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        private Android.Graphics.Color _selectedColor;

        protected override void OnAttached()
        {
            _selectedColor = new Android.Graphics.Color(229, 235, 234);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((ColorDrawable)Control.Background).Color != _selectedColor)
                    {
                        Control.SetBackgroundColor(_selectedColor);
                    }
                    else
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.White);
                    }
                }               
            }
            catch (InvalidCastException)
            {
                Control.SetBackgroundColor(_selectedColor);
            }           
        }

        protected override void OnDetached()
        {
        }
    }
}