using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInForm.Models
{
    public class ScheduleInformation: ViewModelBase
    {


        public ObservableCollection<Shift> Shifts
        {
            get { return GetValue<ObservableCollection<Shift>>(ShiftsProperty); }
            set { SetValue(ShiftsProperty, value); }
        }

        public static readonly PropertyData ShiftsProperty = RegisterProperty(nameof(Shifts), typeof(ObservableCollection<Shift>), null);

        public ObservableCollection<Absence> Absences
        {
            get { return GetValue<ObservableCollection<Absence>>(AbsencesProperty); }
            set { SetValue(AbsencesProperty, value); }
        }

        public static readonly PropertyData AbsencesProperty = RegisterProperty(nameof(Absences), typeof(ObservableCollection<Absence>), null);
    }
}
