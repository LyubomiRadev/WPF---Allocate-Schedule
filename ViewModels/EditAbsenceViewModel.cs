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
    public class EditAbsenceViewModel: ViewModelBase
    {
        #region Constructor

        public EditAbsenceViewModel(Absence absence)
        {
            this.Name = absence.Name;
            this.Abriviature = absence.Abriviature;
            this.AddAbsenceCommand = new Command(this.OnAddAbsenceCommandExecute);
            this.Days = absence.Days;
            
        }

        #endregion

        #region Properties

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


        public int Days
        {
            get { return GetValue<int>(DaysProperty); }
            set { SetValue(DaysProperty, value); }
        }

        public static readonly PropertyData DaysProperty = RegisterProperty(nameof(Days), typeof(int), null);

        #endregion

        #region Commands & Methods

        public Command AddAbsenceCommand { get; private set; }
        private void OnAddAbsenceCommandExecute()
        {
            if (this.Name == null)
            {
                MessageBox.Show("Please fill in absence definition.", "No absence definition");
                return;
            }
            if (this.Abriviature == null)
            {
                MessageBox.Show("Please fill in absence abriviature.", "No abriviature for absence");
                return;
            }

            this.SaveAndCloseViewModelAsync();
        }

        #endregion
    }
}
