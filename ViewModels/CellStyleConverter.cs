using Catel.MVVM.Converters;
using System;
using System.Globalization;
using LogInForm.Models;
using System.Windows.Media;
using System.Windows.Data;

namespace LogInForm.ViewModels
{
    public class CellStyleConverter : Catel.MVVM.Converters.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int)
            {
                var val = (int)value;
                if (val == 1)
                {
                    Color absenceTextColor = Color.FromRgb(252, 63, 63);
                    return new SolidColorBrush(absenceTextColor);
                }
                else
                {
                    Color shiftTextColor = Color.FromRgb(0, 190, 211);
                    return new SolidColorBrush(shiftTextColor);
                }
            }
           
            else
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
