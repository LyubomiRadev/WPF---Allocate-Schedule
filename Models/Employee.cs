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
    public class Employee : ViewModelBase
    {
        public Employee()
        {
            this.Shifts = new ObservableCollection<Shift>();
            this.Absences = new ObservableCollection<Absence>();
            this.ShiftsAndAbsences = new ObservableCollection<Models.ShiftsAndAbsences>();

        }

        public int ID
        {
            get { return GetValue<int>(IDProperty); }
            set { SetValue(IDProperty, value); }
        }
        public static readonly PropertyData IDProperty = RegisterProperty(nameof(ID), typeof(int), null);
        
        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        public static readonly PropertyData FirstNameProperty = RegisterProperty(nameof(FirstName), typeof(string), string.Empty, (s, e) => ((Employee)s).OnEmployeeChanged());
        
        public bool IsSelectedForDelete
        {
            get { return GetValue<bool>(IsSelectedForDeleteProperty); }
            set { SetValue(IsSelectedForDeleteProperty, value); }
        }
        public static readonly PropertyData IsSelectedForDeleteProperty = RegisterProperty(nameof(IsSelectedForDelete), typeof(bool), false);
        
        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }
        public static readonly PropertyData LastNameProperty = RegisterProperty(nameof(LastName), typeof(string), string.Empty, (s, e) => ((Employee)s).OnEmployeeChanged());

        public bool IsSelected
        {
            get { return GetValue<bool>(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static readonly PropertyData IsSelectedProperty = RegisterProperty(nameof(IsSelected), typeof(bool), false);
        
        public int Age
        {
            get { return GetValue<int>(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }
        public static readonly PropertyData AgeProperty = RegisterProperty(nameof(Age), typeof(int), null);
        
        public Status Status
        {
            get { return GetValue<Status>(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        public static readonly PropertyData StatusProperty = RegisterProperty(nameof(Status), typeof(Status), Status.Avtive);

        public decimal MonthTotalWorkingHours
        {
            get { return GetValue<decimal>(MonthTotalWorkingHoursProperty); }
            set { SetValue(MonthTotalWorkingHoursProperty, value); }
        }

        public static readonly PropertyData MonthTotalWorkingHoursProperty = RegisterProperty(nameof(MonthTotalWorkingHours), typeof(decimal), null);

        public Position Position
        {
            get { return GetValue<Position>(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }
        public static readonly PropertyData PositionProperty = RegisterProperty(nameof(Position), typeof(Position), null);
        
        public string FullName
        {
            get { return GetValue<string>(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }
        public static readonly PropertyData FullNameProperty = RegisterProperty(nameof(FullName), typeof(string), null);
        
        public string FullNameOneLine
        {
            get { return GetValue<string>(FullNameOneLineProperty); }
            set { SetValue(FullNameOneLineProperty, value); }
        }
        public static readonly PropertyData FullNameOneLineProperty = RegisterProperty(nameof(FullNameOneLine), typeof(string), null);
        
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
        
        public ObservableCollection<ShiftsAndAbsences> ShiftsAndAbsences
        {
            get { return GetValue<ObservableCollection<ShiftsAndAbsences>>(ShiftsAndAbsencesProperty); }
            set { SetValue(ShiftsAndAbsencesProperty, value); }
        }
        public static readonly PropertyData ShiftsAndAbsencesProperty = RegisterProperty(nameof(ShiftsAndAbsences), typeof(ObservableCollection<ShiftsAndAbsences>), null);


        private void OnEmployeeChanged()
        {
            this.FullName = $"{this.FirstName}" + Environment.NewLine + $"{this.LastName}";
            this.FullNameOneLine = $"{this.FirstName} {this.LastName}";
        }

        private void OnWorkingStatsChanged()
        {
            var totalHours = 0.0M;
            

            foreach (var item in this.Shifts)
            {
                totalHours += item.TotalWorkingHours;
            }
            this.MonthTotalWorkingHours = totalHours;
        }

    }

    public enum Status
    {
        Avtive = 1,
        Unactive = 2
    }

    public enum Position
    {
        Trainee = 0,
        Junior = 1,
        MidLevel = 2,
        Senior = 3
    }

}
