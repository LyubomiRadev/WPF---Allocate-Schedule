using Catel.MVVM.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using LogInForm.Models;

namespace LogInForm.ViewModels
{
    public class User_TypeConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var test = value as User;

            if(test != null)
            {
                var strType = string.Empty;
                switch (test.Level)
                {
                    case AccessType.Leader:

                        strType = "Ръководител";
                        break;
                    case AccessType.Employee:

                        strType = "Служител";
                        break;
                }
                return $"{test.UserName}: {strType}";
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
