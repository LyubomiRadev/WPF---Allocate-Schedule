using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogInForm.Models;
using Catel.Data;
using System.Windows;

namespace LogInForm.ViewModels
{
    public class ControlPanelViewModel: ViewModelBase
    {
        public override string Title { get { return "Control Panel"; } }

        #region Constructor

        public ControlPanelViewModel(ObservableCollection<User> users, User loggedUser, ObservableCollection<Shift> shifts, ObservableCollection<Absence> absences, ObservableCollection<Employee> employees)
        {
            this.Users = users;

            //Commands
            this.OpenUsersWindow = new Command(this.OnOpenUsersWindowExecute);
            this.OpenNumenclaturesWindow = new Command(this.OnOpenNumenclaturesWindowExecute);
            this.OpenAbsencesWindow = new Command(this.OnOpenAbsencesWindowExecute);
            this.OpenEmployeesWindow = new Command(this.OnOpenEmployeesWindowExecute);
            this.OpenScheduleWindow = new Command(this.OnOpenScheduleWindowExecute);
            this.Shifts = shifts;
            this.Absences = absences;
            this.Employees = employees;

            if (loggedUser.Level == AccessType.Leader)
            {
                this.IsVisibleUsersButton = true;
            }
            else
            {
                this.IsVisibleUsersButton = false;
            }
        }

        #endregion

        #region Properties


        public ObservableCollection<Employee> Employees
        {
            get { return GetValue<ObservableCollection<Employee>>(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        public static readonly PropertyData EmployeesProperty = RegisterProperty(nameof(Employees), typeof(ObservableCollection<Employee>), null);

        public ObservableCollection<Absence> Absences
        {
            get { return GetValue<ObservableCollection<Absence>>(AbsencesProperty); }
            set { SetValue(AbsencesProperty, value); }
        }

        public static readonly PropertyData AbsencesProperty = RegisterProperty(nameof(Absences), typeof(ObservableCollection<Absence>), null);

        public ObservableCollection<Shift> Shifts
        {
            get { return GetValue<ObservableCollection<Shift>>(ShiftsProperty); }
            set { SetValue(ShiftsProperty, value); }
        }

        public static readonly PropertyData ShiftsProperty = RegisterProperty(nameof(Shifts), typeof(ObservableCollection<Shift>), null);

        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>), null);


        public bool IsVisibleUsersButton
        {
            get { return GetValue<bool>(IsVisibleUsersButtonProperty); }
            set { SetValue(IsVisibleUsersButtonProperty, value); }
        }
        public static readonly PropertyData IsVisibleUsersButtonProperty = RegisterProperty(nameof(IsVisibleUsersButton), typeof(bool), null);

        #endregion

        #region Commands & Methods

        #region OpenUsersWindow

        public Command OpenUsersWindow { get; private set; }
        private void OnOpenUsersWindowExecute()
        {
            var vm = new UsersViewModel(this.Users);
            Openwindow(vm);
        }

        #endregion

        #region OpenNumenclaturesWindow

        public Command OpenNumenclaturesWindow { get; private set; }
        private void OnOpenNumenclaturesWindowExecute()
        {
            var vm = new NumenclaturesViewModel(this.Shifts);
            Openwindow(vm);
        }
        #endregion

        #region OpenAbsencesWindow

        public Command OpenAbsencesWindow { get; private set; }
        private void OnOpenAbsencesWindowExecute()
        {
            var vm = new AbsencesViewModel(this.Absences);
            Openwindow(vm);
        }
        #endregion

        #region OpenEmployeesWindow

        public Command OpenEmployeesWindow { get; private set; }
        private void OnOpenEmployeesWindowExecute()
        {
            var vm = new EmployeesViewModel(this.Employees);

            Openwindow(vm);
        }
        #endregion

        #region OpenScheduleWindow

        public Command OpenScheduleWindow { get; private set; }
        private void OnOpenScheduleWindowExecute()
        {
            var vm = new ScheduleViewModel(this.Employees, this.Shifts, this.Absences);
            Openwindow(vm);
        }

        #endregion

        #region OpenWindow Method

        public void Openwindow(IViewModel vm)
        {
            var uiVisualizerService = this.GetDependencyResolver().Resolve<IUIVisualizerService>();
            uiVisualizerService.ShowDialog(vm);
        }

        #endregion

        
        #endregion
    }
}
