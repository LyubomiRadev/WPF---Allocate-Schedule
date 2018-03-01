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
    public class Shift: ViewModelBase
    {

        public int ID
        {
            get { return GetValue<int>(IDProperty); }
            set { SetValue(IDProperty, value); }
        }
        public static readonly PropertyData IDProperty = RegisterProperty(nameof(ID), typeof(int), null);
        
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);
        
        public string Abriviature
        {
            get { return GetValue<string>(AbriviatureProperty); }
            set { SetValue(AbriviatureProperty, value); }
        }
        public static readonly PropertyData AbriviatureProperty = RegisterProperty(nameof(Abriviature), typeof(string), null);

        #region ShiftTimes

        public int FirstStartingHour
        {
            get { return GetValue<int>(FirstStartingHourProperty); }
            set { SetValue(FirstStartingHourProperty, value); }
        }
        public static readonly PropertyData FirstStartingHourProperty = RegisterProperty(nameof(FirstStartingHour), typeof(int), null);
        
        public int FirstStartingMinute
        {
            get { return GetValue<int>(FirstStartingMinuteProperty); }
            set { SetValue(FirstStartingMinuteProperty, value); }
        }
        public static readonly PropertyData FirstStartingMinuteProperty = RegisterProperty(nameof(FirstStartingMinute), typeof(int), null);

        public int SecondStartingHour
        {
            get { return GetValue<int>(SecondStartingHourProperty); }
            set { SetValue(SecondStartingHourProperty, value); }
        }
        public static readonly PropertyData SecondStartingHourProperty = RegisterProperty(nameof(SecondStartingHour), typeof(int), null);
        
        public int SecondStartingMinute
        {
            get { return GetValue<int>(SecondStartingMinuteProperty); }
            set { SetValue(SecondStartingMinuteProperty, value); }
        }
        public static readonly PropertyData SecondStartingMinuteProperty = RegisterProperty(nameof(SecondStartingMinute), typeof(int), null);
        
        public int FirstClosingHour
        {
            get { return GetValue<int>(FirstClosingHourProperty); }
            set { SetValue(FirstClosingHourProperty, value); }
        }
        public static readonly PropertyData FirstClosingHourProperty = RegisterProperty(nameof(FirstClosingHour), typeof(int), null);
        
        public int SecondClosingHour
        {
            get { return GetValue<int>(SecondClosingHourProperty); }
            set { SetValue(SecondClosingHourProperty, value); }
        }
        public static readonly PropertyData SecondClosingHourProperty = RegisterProperty(nameof(SecondClosingHour), typeof(int), null);
        
        public int FirstClosingMinute
        {
            get { return GetValue<int>(FirstClosingMinuteProperty); }
            set { SetValue(FirstClosingMinuteProperty, value); }
        }
        public static readonly PropertyData FirstClosingMinuteProperty = RegisterProperty(nameof(FirstClosingMinute), typeof(int), null);
        
        public int SecondClosingMinute
        {
            get { return GetValue<int>(SecondClosingMinuteProperty); }
            set { SetValue(SecondClosingMinuteProperty, value); }
        }

        public static readonly PropertyData SecondClosingMinuteProperty = RegisterProperty(nameof(SecondClosingMinute), typeof(int), null);

        public int FirstPeriodHours
        {
            get { return GetValue<int>(FirstPeriodHoursProperty); }
            set { SetValue(FirstPeriodHoursProperty, value); }
        }
        public static readonly PropertyData FirstPeriodHoursProperty = RegisterProperty(nameof(FirstPeriodHours), typeof(int), null, (s, e) => ((Shift)s).OnfPCChanged());
        
        public int BreakFirstPeriod
        {
            get { return GetValue<int>(BreakFirstPeriodProperty); }
            set { SetValue(BreakFirstPeriodProperty, value); }
        }
        public static readonly PropertyData BreakFirstPeriodProperty = RegisterProperty(nameof(BreakFirstPeriod), typeof(int), 0);

        public int BreakSecondPeriod
        {
            get { return GetValue<int>(BreakSecondPeriodProperty); }
            set { SetValue(BreakSecondPeriodProperty, value); }
        }
        public static readonly PropertyData BreakSecondPeriodProperty = RegisterProperty(nameof(BreakSecondPeriod), typeof(int), 0);


        public int SecondPeriodHours
        {
            get { return GetValue<int>(SecondPeriodHoursProperty); }
            set { SetValue(SecondPeriodHoursProperty, value); }
        }
        public static readonly PropertyData SecondPeriodHoursProperty = RegisterProperty(nameof(SecondPeriodHours), typeof(int),null, (s, e) => ((Shift)s).OnSPCChanged());


        public decimal TotalWorkingHours
        {
            get { return GetValue<decimal>(TotalWorkingHoursProperty); }
            set { SetValue(TotalWorkingHoursProperty, value); }
        }
        public static readonly PropertyData TotalWorkingHoursProperty = RegisterProperty(nameof(TotalWorkingHours), typeof(decimal), null);


        public bool SecondShift
        {
            get { return GetValue<bool>(SecondShiftProperty); }
            set { SetValue(SecondShiftProperty, value); }
        }
        public static readonly PropertyData SecondShiftProperty = RegisterProperty(nameof(SecondShift), typeof(bool), false);

        private void OnSPCChanged()
        {
            this.TotalWorkingHours += this.SecondPeriodHours;
        }

        private void OnfPCChanged()
        {
            this.TotalWorkingHours += this.FirstPeriodHours;
        }

        public bool IsSelectedForDelete
        {
            get { return GetValue<bool>(IsSelectedForDeleteProperty); }
            set { SetValue(IsSelectedForDeleteProperty, value); }
        }
        public static readonly PropertyData IsSelectedForDeleteProperty = RegisterProperty(nameof(IsSelectedForDelete), typeof(bool), false);

        #endregion
    }
}
