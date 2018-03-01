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
    public class CreateShiftViewModel : ViewModelBase
    {
        #region Fields

        private bool isVerifiedFirstShift { get; set; }

        private bool isVerifiedSecondShift { get; set; }

        private bool isVerifiedAbriviatureName { get; set; }

        #endregion

        #region Constructor

        public CreateShiftViewModel(List<string> shiftAbriviaturesName)
        {
            this.AddNewShift = new Command(this.OnAddNewShiftExecute);
            var hours = Enumerable.Range(0, 24).ToList();
            var minuts = Enumerable.Range(0, 60).ToList();
            this.Hours = hours;
            this.Minutes = minuts;
            this.TypeOperation = true;
            this.AbriviatureNames = shiftAbriviaturesName;
        }

        #endregion

        #region Properties

        public List<string> AbriviatureNames
        {
            get { return GetValue<List<string>>(AbriviatureNamesProperty); }
            set { SetValue(AbriviatureNamesProperty, value); }
        }
        public static readonly PropertyData AbriviatureNamesProperty = RegisterProperty(nameof(AbriviatureNames), typeof(List<string>), null);

        public List<int> Hours
        {
            get { return GetValue<List<int>>(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }
        public static readonly PropertyData HoursProperty = RegisterProperty(nameof(Hours), typeof(List<int>), null);


        public List<int> Minutes
        {
            get { return GetValue<List<int>>(MinutesProperty); }
            set { SetValue(MinutesProperty, value); }
        }
        public static readonly PropertyData MinutesProperty = RegisterProperty(nameof(Minutes), typeof(List<int>), null);

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

        #endregion
        
        public bool IsSecondShiftCheck
        {
            get { return GetValue<bool>(IsSecondShiftCheckProperty); }
            set { SetValue(IsSecondShiftCheckProperty, value); }
        }
        public static readonly PropertyData IsSecondShiftCheckProperty = RegisterProperty(nameof(IsSecondShiftCheck), typeof(bool), false);
        
        public int FirstPeriodHours
        {
            get { return GetValue<int>(FirstPeriodHoursProperty); }
            set { SetValue(FirstPeriodHoursProperty, value); }
        }
        public static readonly PropertyData FirstPeriodHoursProperty = RegisterProperty(nameof(FirstPeriodHours), typeof(int), null);
        
        public int SecondPeriodHours
        {
            get { return GetValue<int>(SecondPeriodHoursProperty); }
            set { SetValue(SecondPeriodHoursProperty, value); }
        }
        public static readonly PropertyData SecondPeriodHoursProperty = RegisterProperty(nameof(SecondPeriodHours), typeof(int), null);
        
        public Shift NewShift
        {
            get { return GetValue<Shift>(NewShiftProperty); }
            set { SetValue(NewShiftProperty, value); }
        }
        public static readonly PropertyData NewShiftProperty = RegisterProperty(nameof(NewShift), typeof(Shift), null);
        
        public bool TypeOperation
        {
            get { return GetValue<bool>(TypeOperationProperty); }
            set { SetValue(TypeOperationProperty, value); }
        }
        public static readonly PropertyData TypeOperationProperty = RegisterProperty(nameof(TypeOperation), typeof(bool), null);
        
        public bool SecondShift
        {
            get { return GetValue<bool>(SecondShiftProperty); }
            set { SetValue(SecondShiftProperty, value); }
        }
        public static readonly PropertyData SecondShiftProperty = RegisterProperty(nameof(SecondShift), typeof(bool), null);

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

        #endregion

        #region Commands & Methods


        #region AddNewShift

        public Command AddNewShift { get; private set; }
        private void OnAddNewShiftExecute()
        {
            this.isVerifiedFirstShift = true;
            this.isVerifiedSecondShift = true;
            this.isVerifiedAbriviatureName = true;
            var checkFirstShift = CheckShiftHours(this.FirstStartingHour, this.FirstStartingMinute, this.FirstClosingHour, this.FirstClosingMinute);
            var checkSecondShift = CheckShiftHours(this.SecondStartingHour, this.SecondStartingMinute, this.SecondClosingHour, this.SecondClosingMinute);

            if (this.Name == string.Empty)
            {
                MessageBox.Show("Please, chose shift name!", "Empty shift name");
                return;
            }
            else if (this.Abriviature == string.Empty)
            {
                MessageBox.Show("Please, chose shift abriviature!", "Empty shift abriviature");
                return;
            }
            else if (this.AbriviatureNames.Contains(this.Abriviature))
            {
                this.isVerifiedAbriviatureName = false;
                MessageBox.Show("Such abriviature already exists!", "Abriviature match");
                return;
            }

            //Check First Shift and add hours summary
            if (!checkFirstShift)
            {
                this.isVerifiedFirstShift = false;
                MessageBox.Show("Shift can't end before or at the same time it starts", "Wrong shift input");
                return;
            }
            else
            {
                this.FirstPeriodHours = (this.FirstClosingHour * 60 + this.FirstClosingMinute) - (this.FirstStartingHour * 60 + this.FirstStartingMinute) - this.BreakFirstPeriod;
            }

            //Check if second shift is selected and add hours summary
            if (this.IsSecondShiftCheck)
            {
                this.SecondShift = true;
                if (!checkSecondShift)
                {
                    this.isVerifiedSecondShift = false;
                    MessageBox.Show("Shift can't end before or at the same time it starts", "Wrong shift input");
                    return;
                }
                else
                {
                    this.SecondPeriodHours = (this.SecondClosingHour * 60 + this.SecondClosingMinute) - (this.SecondStartingHour * 60 + this.SecondStartingMinute) - this.BreakSecondPeriod;
                }
            }

            if (this.isVerifiedAbriviatureName && this.isVerifiedFirstShift && this.isVerifiedSecondShift)
            {
                 CreateNewShift();

                this.SaveAndCloseViewModelAsync();
            }
        }

        
        #endregion

        #region CreateNewShift Method

        private void CreateNewShift()
        {
            var newShift = new Shift()
            {
                FirstPeriodHours = this.FirstPeriodHours,
                SecondPeriodHours = this.SecondPeriodHours,
                Name = this.Name,
                Abriviature = this.Abriviature,
                FirstStartingHour = this.FirstStartingHour,
                FirstStartingMinute = this.FirstStartingMinute,
                FirstClosingHour = this.FirstClosingHour,
                FirstClosingMinute = this.FirstClosingMinute,
                SecondStartingHour = this.SecondStartingHour,
                SecondStartingMinute = this.SecondStartingMinute,
                SecondClosingHour = this.SecondClosingHour,
                SecondClosingMinute = this.SecondClosingMinute,
                BreakFirstPeriod = this.BreakFirstPeriod,
                BreakSecondPeriod = this.BreakSecondPeriod,
                TotalWorkingHours = this.FirstPeriodHours + this.SecondPeriodHours
                
            };

            this.NewShift = newShift;
        }

        #endregion

        #region CheckShiftHours Method

        private bool CheckShiftHours(int shiftStartingHour, int shiftStartingMinute, int shiftClosingHour, int shiftClosingMinute)
        {
            var startSummary = shiftStartingHour * 60 + shiftStartingMinute;
            var closeSummary = shiftClosingHour * 60 + shiftClosingMinute;

            if (startSummary >= closeSummary)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        
        #endregion
    }
}
