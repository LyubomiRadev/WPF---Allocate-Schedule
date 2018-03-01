using Catel.Data;
using Catel.MVVM;
using LogInForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogInForm.ViewModels
{
    public class EditEmployeeViewModel: ViewModelBase
    {
        #region Constructor

        public EditEmployeeViewModel(Employee employee)
        {
            var age = Enumerable.Range(18, 52).ToList();
            this.ChosenAge = age;

            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.SelectedPositionType = employee.Position;
            this.SelectedStatysType = employee.Status;
            this.SelectedAge = employee.Age;

            this.EditEmployee = new Command(this.OnEditEmployeeExecute);
        }

        #endregion

        #region Properties
        
        public List<int> ChosenAge
        {
            get { return GetValue<List<int>>(ChosenAgeProperty); }
            set { SetValue(ChosenAgeProperty, value); }
        }
        public static readonly PropertyData ChosenAgeProperty = RegisterProperty(nameof(ChosenAge), typeof(List<int>), null);


        public int SelectedAge
        {
            get { return GetValue<int>(SelectedAgeProperty); }
            set { SetValue(SelectedAgeProperty, value); }
        }

        public static readonly PropertyData SelectedAgeProperty = RegisterProperty(nameof(SelectedAge), typeof(int), null);

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


        public Status SelectedStatysType
        {
            get { return GetValue<Status>(SelectedStatysTypeProperty); }
            set { SetValue(SelectedStatysTypeProperty, value); }
        }
        public static readonly PropertyData SelectedStatysTypeProperty = RegisterProperty(nameof(SelectedStatysType), typeof(Status), Status.Avtive);


        public Position SelectedPositionType
        {
            get { return GetValue<Position>(SelectedPositionTypeProperty); }
            set { SetValue(SelectedPositionTypeProperty, value); }
        }
        public static readonly PropertyData SelectedPositionTypeProperty = RegisterProperty(nameof(SelectedPositionType), typeof(Position), Position.Trainee);

        #endregion

        #region EditEmployeeCommand

        public Command EditEmployee { get; private set; }
        private void OnEditEmployeeExecute()
        {
            if (this.FirstName == null || this.LastName == null)
            {
                MessageBox.Show("Please, fill FirstName and LastName!", "Missing input");
            }
            else
            {
                this.SaveAndCloseViewModelAsync();
            }
        }

        #endregion
    }
}
