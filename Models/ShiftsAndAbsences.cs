using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInForm.Models
{
    public class ShiftsAndAbsences: ViewModelBase
    {

        public DateTime DayOfUse
        {
            get { return GetValue<DateTime>(DayOfUseProperty); }
            set { SetValue(DayOfUseProperty, value); }
        }
        public static readonly PropertyData DayOfUseProperty = RegisterProperty(nameof(DayOfUse), typeof(DateTime), DateTime.Now);

        public string Abriviature
        {
            get { return GetValue<string>(AbriviatureProperty); }
            set { SetValue(AbriviatureProperty, value); }
        }
        public static readonly PropertyData AbriviatureProperty = RegisterProperty(nameof(Abriviature), typeof(string), string.Empty);

        public decimal WorkingHours
        {
            get { return GetValue<decimal>(WorkingHoursProperty); }
            set { SetValue(WorkingHoursProperty, value); }
        }
        public static readonly PropertyData WorkingHoursProperty = RegisterProperty(nameof(WorkingHours), typeof(decimal), default(decimal), (s, e) => ((ShiftsAndAbsences)s).OnWorkingHoursChanged());

        private void OnWorkingHoursChanged()
        {
            this.WorkingHoursForTable = this.WorkingHours / 60.0M;
        }

        public decimal WorkingHoursForTable
        {
            get { return GetValue<decimal>(WorkingHoursForTableProperty); }
            set { SetValue(WorkingHoursForTableProperty, value); }
        }

        public static readonly PropertyData WorkingHoursForTableProperty = RegisterProperty(nameof(WorkingHoursForTable), typeof(decimal), null);
        
        /// <summary>
        /// 0 - Shift
        /// 1 - Absence
        /// </summary>
        public int AttendanceType
        {
            get { return GetValue<int>(AttendanceTypeProperty); }
            set { SetValue(AttendanceTypeProperty, value); }
        }
        public static readonly PropertyData AttendanceTypeProperty = RegisterProperty(nameof(AttendanceType), typeof(int), 0);

    }

}
