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
    public class AddEmployeeViewModel: ViewModelBase
    {
        #region Constructor

        public AddEmployeeViewModel()
        {
            this.AddEmployeeCommand = new Command(this.OnAddEmployeeCommandExecute);
            var age = Enumerable.Range(18, 52).ToList();
            this.ChosenAge = age;
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

        #region Commands

        public Command AddEmployeeCommand { get; private set; }
        private void OnAddEmployeeCommandExecute()
        {
            if(string.IsNullOrEmpty(this.FirstName) || string.IsNullOrEmpty(this.LastName))
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
