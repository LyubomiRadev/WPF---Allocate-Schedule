using Catel.Data;
using Catel.MVVM;
using LogInForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace LogInForm.ViewModels
{
    public class CreateUserViewModel: ViewModelBase
    {
        public override string Title
        { get { return "Add User Window"; } }
        #region Constructor

        public CreateUserViewModel()
        {
            this.CreateNewUser = new Command(this.OnCreateNewUserExecute);
            this.TypeOperation = false;
        }

        #endregion

        #region Properties


        public bool TypeOperation
        {
            get { return GetValue<bool>(TypeOperationProperty); }
            set { SetValue(TypeOperationProperty, value); }
        }

        public static readonly PropertyData TypeOperationProperty = RegisterProperty(nameof(TypeOperation), typeof(bool), null);

        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        public static readonly PropertyData FirstNameProperty = RegisterProperty(nameof(FirstName), typeof(string), null);


        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }
        public static readonly PropertyData LastNameProperty = RegisterProperty(nameof(LastName), typeof(string), null);


        public string UserName
        {
            get { return GetValue<string>(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }
        public static readonly PropertyData UserNameProperty = RegisterProperty(nameof(UserName), typeof(string), null);


        public string Password
        {
            get { return GetValue<string>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly PropertyData PasswordProperty = RegisterProperty(nameof(Password), typeof(string), null);
        
        public AccessType SelectedAccessType
        {
            get { return GetValue<AccessType>(SelectedAccessTypeProperty); }
            set { SetValue(SelectedAccessTypeProperty, value); }
        }

        public static readonly PropertyData SelectedAccessTypeProperty = RegisterProperty(nameof(SelectedAccessType), typeof(AccessType), AccessType.Leader);
        
        #endregion

        #region Commands and Methods

        #region AddCommand


        public Command CreateNewUser { get; private set; }
        private void OnCreateNewUserExecute()
        {
            var pattern = new Regex(@"\b[a-zA-Z]+\b");
            if (!pattern.IsMatch(this.FirstName) || !pattern.IsMatch(this.LastName))
            {
                MessageBox.Show("Името може да съдържа само букви!", "Неправилно въвеждане на име");
                return;
            }
            else
            {
                this.TypeOperation = true;
                this.SaveAndCloseViewModelAsync();
            }
            
        }

        #endregion
        
        #endregion
    }
}
