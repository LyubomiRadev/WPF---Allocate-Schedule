using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using LogInForm.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInForm.ViewModels
{
    public class EmployeesViewModel: ViewModelBase
    {
        public override string Title
        { get { return "Employees Window"; } }

        #region Constructor

        public EmployeesViewModel(ObservableCollection<Employee> empoloyees)
        {
            this.AddEmployeeCommand = new Command(this.OnAddEmployeeCommandExecute);
            this.EditEmployeeCommand = new Command<Employee>(this.OnEditEmployeeCommandExecute);
            this.DeleteEmployeeCommand = new Command(this.OnDeleteEmployeeCommandExecute);
            this.Empoloyees = empoloyees;
        }

        #endregion

        #region Properties

        public string FileToOperate { get { return @"D:\GeoCon Education\LogInForm\Folders\allEmployees.csv"; } }

        public ObservableCollection<Employee> Empoloyees
        {
            get { return GetValue<ObservableCollection<Employee>>(EmpoloyeesProperty); }
            set { SetValue(EmpoloyeesProperty, value); }
        }
        public static readonly PropertyData EmpoloyeesProperty = RegisterProperty(nameof(Empoloyees), typeof(ObservableCollection<Employee>), null);

        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        public static readonly PropertyData FirstNameProperty = RegisterProperty(nameof(FirstName), typeof(string), null);


        public bool IsSelectedForDelete
        {
            get { return GetValue<bool>(IsSelectedForDeleteProperty); }
            set { SetValue(IsSelectedForDeleteProperty, value); }
        }
        public static readonly PropertyData IsSelectedForDeleteProperty = RegisterProperty(nameof(IsSelectedForDelete), typeof(bool), null);


        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }
        public static readonly PropertyData LastNameProperty = RegisterProperty(nameof(LastName), typeof(string), null);


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
        public static readonly PropertyData StatusProperty = RegisterProperty(nameof(Status), typeof(Status), null);


        public Position Position
        {
            get { return GetValue<Position>(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }
        public static readonly PropertyData PositionProperty = RegisterProperty(nameof(Position), typeof(Position), null);

        #endregion

        #region Commands & Methods

        #region AddEmployeeCommand

        public Command AddEmployeeCommand { get; private set; }
        private void OnAddEmployeeCommandExecute()
        {
            var vm = new AddEmployeeViewModel();
            Openwindow(vm);

            var newEmployee = new Employee()
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Age = vm.SelectedAge,
                Position = vm.SelectedPositionType,
                Status = vm.SelectedStatysType,
                ID = this.Empoloyees.Count
            };

            this.Empoloyees.Add(newEmployee);

            File.Delete(FileToOperate);
            foreach (var item in this.Empoloyees)
            {
                File.AppendAllText(FileToOperate, $"{item.FirstName},{item.LastName},{item.Age},{item.Position},{(int)item.Status}" + Environment.NewLine);
            }

        }

        #endregion

        #region EditEmployeeCommand

        public Command<Employee> EditEmployeeCommand { get; private set; }
        private void OnEditEmployeeCommandExecute(Employee employee)
        {
            var vm = new EditEmployeeViewModel(employee);
            Openwindow(vm);

            employee.FirstName = vm.FirstName;
            employee.LastName = vm.LastName;
            employee.Age = vm.SelectedAge;
            employee.Position = vm.SelectedPositionType;
            employee.Status = vm.SelectedStatysType;

            File.Delete(FileToOperate);

            foreach (var empl in this.Empoloyees)
            {
                File.AppendAllText(FileToOperate, $"{empl.FirstName}, {empl.LastName}, {empl.Age},{empl.Position}, {(int)empl.Status}" + Environment.NewLine);
            }
        }

        #endregion

        #region DeleteEmployeeCommand

        public Command DeleteEmployeeCommand { get; private set; }
        private void OnDeleteEmployeeCommandExecute()
        {
            var employeesToDelete = new List<Employee>();

            foreach (var empl in this.Empoloyees)
            {
                if (empl.IsSelectedForDelete)
                {
                    employeesToDelete.Add(empl);
                }
            }

            foreach (var empl in employeesToDelete)
            {
                this.Empoloyees.Remove(empl);
            }
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
