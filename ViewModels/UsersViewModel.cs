using Catel.MVVM;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogInForm.Models;
using Catel.Data;
using Catel.IoC;
using Catel.Services;
using System.Security.Cryptography;
using System.IO;
using System.Windows;

namespace LogInForm.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {

        #region Constructor

        public UsersViewModel(ObservableCollection<User> users)
        {
            
            this.AddNewUser = new Command(this.OnAddNewUserExecute);
            this.ShowLogIns = new Command(this.OnShowLogInsExecute);
            this.ShowSuccessfulLogins = new Command(this.OnShowSuccessfulLoginsExecute);
            this.ShowUnsuccessfulLogins = new Command(this.OnShowUnsuccessfulLoginsExecute);
            this.EditUser = new Command(this.OnEditUserExecute);
            this.Users = users;
        }

        #endregion

        #region Properties

        /// <summary>
        /// int = user ID
        /// strings = FristName, LastName, UserName, CreationDate
        /// </summary>
        public Tuple<int,string, string, string, string> UserInfoCollection
        {
            get { return GetValue<Tuple<int,string, string, string, string>>(UserInfoCollectionProperty); }
            set { SetValue(UserInfoCollectionProperty, value); }
        }

        public static readonly PropertyData UserInfoCollectionProperty = RegisterProperty(nameof(UserInfoCollection), typeof(Tuple<int,string, string, string, string>), null);
        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }

        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>), null);


        public bool IsVisibleLogInsButtons
        {
            get { return GetValue<bool>(IsVisibleLogInsButtonsProperty); }
            set { SetValue(IsVisibleLogInsButtonsProperty, value); }
        }
        public static readonly PropertyData IsVisibleLogInsButtonsProperty = RegisterProperty(nameof(IsVisibleLogInsButtons), typeof(bool), null);


        public bool IsVisibleSuccessfulLogins
        {
            get { return GetValue<bool>(IsVisibleSuccessfulLoginsProperty); }
            set { SetValue(IsVisibleSuccessfulLoginsProperty, value); }
        }

        public static readonly PropertyData IsVisibleSuccessfulLoginsProperty = RegisterProperty(nameof(IsVisibleSuccessfulLogins), typeof(bool), null);


        public bool IsVisibleUnsuccessfulLogins
        {
            get { return GetValue<bool>(IsVisibleUnsuccessfulLoginsProperty); }
            set { SetValue(IsVisibleUnsuccessfulLoginsProperty, value); }
        }

        public static readonly PropertyData IsVisibleUnsuccessfulLoginsProperty = RegisterProperty(nameof(IsVisibleUnsuccessfulLogins), typeof(bool), null);


       


        public User SelectedUser
        {
            get { return GetValue<User>(SelectedUserProperty); }
            set { SetValue(SelectedUserProperty, value); }
        }
        public static readonly PropertyData SelectedUserProperty = RegisterProperty(nameof(SelectedUser), typeof(User), null);

        #endregion

        #region Commands and Methods

        #region ShowLogIns

        public Command ShowLogIns { get; private set; }
        private void OnShowLogInsExecute()
        {
            if (this.SelectedUser != null)
            {
                this.IsVisibleLogInsButtons = !this.IsVisibleLogInsButtons;
                if (!this.IsVisibleLogInsButtons)
                {
                    this.IsVisibleSuccessfulLogins = false;
                    this.IsVisibleUnsuccessfulLogins = false;
                }
            }
            else
            {
                MessageBox.Show("Please select a user.", "No user selected");
            }
            
            
        }

        #endregion

        #region Successful Logins

        public Command ShowSuccessfulLogins { get; private set; }
        private void OnShowSuccessfulLoginsExecute()
        {
            this.IsVisibleSuccessfulLogins = !this.IsVisibleSuccessfulLogins;

            this.IsVisibleUnsuccessfulLogins = false;
           

        }

        #endregion

        #region UnsuccessfulLogins

        public Command ShowUnsuccessfulLogins { get; private set; }
        private void OnShowUnsuccessfulLoginsExecute()
        {
            this.IsVisibleUnsuccessfulLogins = !this.IsVisibleUnsuccessfulLogins;
            if (this.IsVisibleSuccessfulLogins )
            {
                this.IsVisibleSuccessfulLogins = false;
                
            }
        }

        #endregion

        #region ShowUsersInfotable

        public Command EditUser { get; private set; }
        private void OnEditUserExecute()
        {
            
            if (this.SelectedUser != null)
            {
                var vm = new EditUserViewModel(this.SelectedUser);
                Openwindow(vm);

                this.SelectedUser.FirstName = vm.FirstName;
                this.SelectedUser.LastName = vm.LastName;
                this.SelectedUser.UserName = vm.UserName;
                this.SelectedUser.Level = vm.SelectedAccessType;
                this.SelectedUser.Password = EncryptDecrypt.Encrypt(vm.Password, EncryptDecrypt.passPhrase);
            }
            else
            {
                MessageBox.Show("Please select a user.", "No user selected");
            }

            this.IsVisibleUnsuccessfulLogins = false;
            this.IsVisibleSuccessfulLogins = false;
            this.IsVisibleLogInsButtons = false;
        }
        #endregion

        #region AddNewUser

        public Command AddNewUser { get; private set; }
        private void OnAddNewUserExecute()
        {
            var vm = new CreateUserViewModel();
            Openwindow(vm);

            if (vm.TypeOperation)
            {
                var id = 0;
                if (this.Users.Count != 0)
                {
                    id = this.Users.Max(u => u.ID) + 1;
                }

                var newUser = new User()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    UserName = vm.UserName,
                    Password = EncryptDecrypt.Encrypt(vm.Password, EncryptDecrypt.passPhrase),
                    CreationDate = DateTime.Now.ToString("dd.MM.yyyy"),
                    ID = id,
                    Level = vm.SelectedAccessType
                };

                this.Users.Add(newUser);
                File.AppendAllText(@"D:\GeoCon Education\LogInForm\Folders\allUsers.csv", $"{newUser.ID}, {newUser.UserName}, {newUser.FirstName}, {newUser.LastName},{newUser.CreationDate},{((int)newUser.Level).ToString()}, {newUser.Password}" + Environment.NewLine);
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
