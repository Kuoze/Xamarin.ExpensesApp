using CoreGraphics;
using ExpensesApp.iOS.CustomRenderers;
using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpensesApp.iOS.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
     

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            // Valores para escalar en el eje X e Y
            float x = 1.0f;
            float y = 4.0f;

            CGAffineTransform transform = CGAffineTransform.MakeScale(x, y);
            Transform = transform;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressTintColor = Color.FromHex("#00B9AE").ToUIColor(); // Teal
            else if (e.NewElement.Progress < .3)
                Control.ProgressTintColor = Color.FromHex("#008DD5").ToUIColor(); //Blue
            else if (e.NewElement.Progress < .5)
                Control.ProgressTintColor = Color.FromHex("#2D76BA").ToUIColor(); // Dark Blue
            else if (e.NewElement.Progress < .7)
                Control.ProgressTintColor = Color.FromHex("#5A5F9F").ToUIColor(); // Purple
            else if (e.NewElement.Progress < .9)
                Control.ProgressTintColor = Color.FromHex("#B3316A").ToUIColor(); // Magenta
            else
                Control.ProgressTintColor = Color.FromHex("#E01A4F").ToUIColor(); // Red Coral

            LayoutSubviews();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}