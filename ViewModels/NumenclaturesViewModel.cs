using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using LogInForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInForm.ViewModels
{
    public class NumenclaturesViewModel : ViewModelBase
    {
        public override string Title
        { get { return "Numenclatures Window"; } }

        #region Constructor

        public NumenclaturesViewModel(ObservableCollection<Shift> shifts)
        {
            this.CreateNewShift = new Command(this.OnCreateNewShiftExecute);
            this.EditShiftCommand = new Command<Shift>(this.OnEditShiftCommandExecute);
            this.DeleteShiftCommand = new Command(this.OnDeleteShiftCommandExecute);
            this.Shifts = shifts;
            this.AbriviaturesNames = new List<string>();
            foreach (var shift in this.Shifts)
            {
                AbriviaturesNames.Add(shift.Abriviature);
            }
        }

        #endregion

        #region Properties
        
        public string FileToOperate { get { return @"D:\GeoCon Education\LogInForm\Folders\allShifts.csv"; } }

        public List<String> AbriviaturesNames
        {
            get { return GetValue<List<String>>(AbriviaturesNamesProperty); }
            set { SetValue(AbriviaturesNamesProperty, value); }
        }

        public static readonly PropertyData AbriviaturesNamesProperty = RegisterProperty(nameof(AbriviaturesNames), typeof(List<String>), null);

        public ObservableCollection<Shift> Shifts
        {
            get { return GetValue<ObservableCollection<Shift>>(ShiftsProperty); }
            set { SetValue(ShiftsProperty, value); }
        }

        public static readonly PropertyData ShiftsProperty = RegisterProperty(nameof(Shifts), typeof(ObservableCollection<Shift>), null);
        #endregion

        #region Commands & Methods

        #region CreateShiftCommand

        public Command CreateNewShift { get; private set; }
        private void OnCreateNewShiftExecute()
        {
            //open window to create shift
            var vm = new CreateShiftViewModel(this.AbriviaturesNames);
            Openwindow(vm);

            //add ID to the sifht
            if(vm.NewShift != null)
            {
                vm.NewShift.ID = this.Shifts.Count();

                //add new shift to collection
                this.Shifts.Add(vm.NewShift);

                //add information to file
                if (vm.SecondShift)
                {
                    File.AppendAllText(FileToOperate, $"{vm.Name}, {vm.Abriviature}, {vm.FirstStartingHour}, {vm.FirstStartingMinute}, {vm.FirstClosingHour}, {vm.FirstClosingMinute}, {vm.SecondStartingHour}, {vm.SecondStartingMinute}, {vm.SecondClosingHour}, {vm.SecondClosingMinute}, {vm.FirstPeriodHours}, {vm.SecondPeriodHours},{vm.BreakFirstPeriod},{vm.BreakSecondPeriod}" + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(FileToOperate, $"{vm.Name}, {vm.Abriviature}, {vm.FirstStartingHour}, {vm.FirstStartingMinute}, {vm.FirstClosingHour}, {vm.FirstClosingMinute}, {vm.SecondStartingHour}, {vm.SecondStartingMinute}, {vm.SecondClosingHour}, {vm.SecondClosingMinute}, {vm.FirstPeriodHours}, {vm.SecondPeriodHours},{vm.BreakFirstPeriod},{vm.BreakSecondPeriod}" + Environment.NewLine);
                }
            }
            
        }

        #endregion

        #region EditShiftCommand

        public Command<Shift> EditShiftCommand { get; private set; }
        private void OnEditShiftCommandExecute(Shift argument)
        {
            var vm = new EditShiftViewModel(argument, AbriviaturesNames);
            Openwindow(vm);
            UpdateShift(argument, vm);

            //delete file and create a new one with the updated information
            File.Delete(this.FileToOperate);
            foreach (var shift in this.Shifts)
            {
                    File.AppendAllText(FileToOperate, $"{shift.Name}, {shift.Abriviature}, {shift.FirstStartingHour}, {shift.FirstStartingMinute}, {shift.FirstClosingHour}, {shift.FirstClosingMinute}, {shift.SecondStartingHour}, {shift.SecondStartingMinute}, {shift.SecondClosingHour}, {shift.SecondClosingMinute}, {shift.FirstPeriodHours}, {shift.SecondPeriodHours},{shift.BreakFirstPeriod},{shift.BreakSecondPeriod}" + Environment.NewLine);
                
            }
        }

        #endregion

        #region DeleteShiftCommand

        public Command DeleteShiftCommand { get; private set; }
        private void OnDeleteShiftCommandExecute()
        {
            var shiftsToDelete = new List<Shift>();

            //select shifts to be deleted
            foreach (var shift in this.Shifts)
            {
                if (shift.IsSelectedForDelete)
                {
                    shiftsToDelete.Add(shift);
                }
            }

            //delete shifts
            foreach (var shift in shiftsToDelete)
            {
                this.Shifts.Remove(shift);

            }

            //delete file and create a new one with the updated information
            File.Delete(this.FileToOperate);
            foreach (var shift in this.Shifts)
            {
                File.AppendAllText(FileToOperate, $"{shift.Name}, {shift.Abriviature}, {shift.FirstStartingHour}, {shift.FirstStartingMinute}, {shift.FirstClosingHour}, {shift.FirstClosingMinute}, {shift.SecondStartingHour}, {shift.SecondStartingMinute}, {shift.SecondClosingHour}, {shift.SecondClosingMinute}, {shift.FirstPeriodHours}, {shift.SecondPeriodHours}" + Environment.NewLine);
            }
        }

        #endregion

        #region UpdateShift Method

        private static void UpdateShift(Shift argument, EditShiftViewModel vm)
        {
            argument.FirstStartingHour = vm.FirstStartingHour;
            argument.FirstStartingMinute = vm.FirstStartingMinute;
            argument.FirstClosingHour = vm.FirstClosingHour;
            argument.FirstClosingMinute = vm.FirstClosingMinute;
            argument.SecondStartingHour = vm.SecondStartingHour;
            argument.SecondStartingMinute = vm.SecondStartingMinute;
            argument.SecondClosingHour = vm.SecondClosingHour;
            argument.SecondClosingMinute = vm.SecondClosingMinute;
            argument.Name = vm.Name;
            argument.Abriviature = vm.Abriviature;
            argument.FirstPeriodHours = vm.FirstPeriodHours;
            argument.SecondPeriodHours = vm.SecondPeriodHours;
            argument.SecondShift = vm.SecondShift;
            argument.BreakFirstPeriod = vm.BreakFirstPeriod;
            argument.BreakSecondPeriod = vm.BreakSecondPeriod;
            argument.TotalWorkingHours = vm.FirstPeriodHours + vm.SecondPeriodHours;
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
