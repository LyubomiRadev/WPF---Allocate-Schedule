using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInForm.Models
{
    public class Activity: ViewModelBase
    {

        public DateTime LogInDay
        {
            get { return GetValue<DateTime>(LogInDayProperty); }
            set { SetValue(LogInDayProperty, value); }
        }

        public static readonly PropertyData LogInDayProperty = RegisterProperty(nameof(LogInDay), typeof(DateTime), DateTime.Now);
    }
}
