﻿using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExpensesApp.Droid.CustomRenderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace ExpensesApp.Droid.CustomRenderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View _currentCell;
        private bool _isSelected;
        private Drawable _defaultBackground;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _currentCell = base.GetCellCore(item, convertView, parent, context);
            _isSelected = false;
            _defaultBackground = _currentCell.Background;
            
            return _currentCell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);
          
            if(e.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;

                if (_isSelected)
                {
                    _currentCell.SetBackgroundColor(Color.FromHex("#E6E6E6").ToAndroid());
                }
                else
                {
                    _currentCell.Background = _defaultBackground;
                }
            }
        }
    }
}