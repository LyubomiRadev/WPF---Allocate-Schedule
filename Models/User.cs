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
    public class User: ViewModelBase
    {

        #region Constructor

        public User()
        {
            this.SuccessfulLogins = new ObservableCollection<DateTime>();
            this.UnsuccessfulLogins = new ObservableCollection<DateTime>();
        }
        #endregion

        #region Properties

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
        
        public string CreationDate
        {
            get { return GetValue<string>(CreationDateProperty); }
            set { SetValue(CreationDateProperty, value); }
        }
        public static readonly PropertyData CreationDateProperty = RegisterProperty(nameof(CreationDate), typeof(string), null);

        public AccessType Level
        {
            get { return GetValue<AccessType>(AccessTypeProperty); }
            set { SetValue(AccessTypeProperty, value); }
        }
        public static readonly PropertyData AccessTypeProperty = RegisterProperty(nameof(Level), typeof(AccessType), null);
        
        public ObservableCollection<Activity> Activities
        {
            get { return GetValue<ObservableCollection<Activity>>(ActivitiesProperty); }
            set { SetValue(ActivitiesProperty, value); }
        }
        public static readonly PropertyData ActivitiesProperty = RegisterProperty(nameof(Activities), typeof(ObservableCollection<Activity>), null);
        
        public ObservableCollection<DateTime> SuccessfulLogins
        {
            get { return GetValue<ObservableCollection<DateTime>>(SuccessfulLoginsProperty); }
            set { SetValue(SuccessfulLoginsProperty, value); }
        }
        public static readonly PropertyData SuccessfulLoginsProperty = RegisterProperty(nameof(SuccessfulLogins), typeof(ObservableCollection<DateTime>), null);
        
        public ObservableCollection<DateTime> UnsuccessfulLogins
        {
            get { return GetValue<ObservableCollection<DateTime>>(UnsuccessfulLoginsProperty); }
            set { SetValue(UnsuccessfulLoginsProperty, value); }
        }
        public static readonly PropertyData UnsuccessfulLoginsProperty = RegisterProperty(nameof(UnsuccessfulLogins), typeof(ObservableCollection<DateTime>), null);

        #endregion

    }
    
}
