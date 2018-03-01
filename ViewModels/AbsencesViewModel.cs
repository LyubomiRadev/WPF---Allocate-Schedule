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
using System.Windows;

namespace LogInForm.ViewModels
{
    public class AbsencesViewModel: ViewModelBase
    {
        #region Constructor

        public AbsencesViewModel(ObservableCollection<Absence> absences)
        {
            this.Absences = absences;
            this.AddAbsenceCommand = new Command(this.OnAddAbsenceCommandExecute);
            this.DeleteAbsenceCommand = new Command(this.OnDeleteAbsenceCommandExecute);
            this.EditAbsenceCommand = new Command<Absence>(this.OnEditAbsenceCommandExecute);
        }

        #endregion

        #region Properties

        public string FileToOperate { get {return @"D:\GeoCon Education\LogInForm\Folders\allAbsences.csv"; } }

        public ObservableCollection<Absence> Absences
        {
            get { return GetValue<ObservableCollection<Absence>>(AbsencesProperty); }
            set { SetValue(AbsencesProperty, value); }
        }

        public static readonly PropertyData AbsencesProperty = RegisterProperty(nameof(Absences), typeof(ObservableCollection<Absence>), null);


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

        #endregion

        #region Commands & Methods

        #region AddAbsenceCommand

        public Command AddAbsenceCommand { get; private set; }
        private void OnAddAbsenceCommandExecute()
        {
            var vm = new AddAbsenceViewModel();
            Openwindow(vm);
            //create an obj with new info
            var newAbsence = new Absence()
            {
                Name = vm.Name,
                Abriviature = vm.Abriviature,
                ID = this.Absences.Count(),
                Days = vm.Days
            };

            //add object
            this.Absences.Add(newAbsence);
            MessageBox.Show($"Absence \"{vm.Name}\" successfully added", "New absence added");

            //delete old file and create a new one with the new info
            File.Delete(FileToOperate);
            foreach (var item in this.Absences)
            {
                File.AppendAllText(FileToOperate, $"{item.Name},{item.Abriviature},{item.Days}" + Environment.NewLine);
            }
            
        }

        #endregion

        #region EditAbsenceCommand

        public Command<Absence> EditAbsenceCommand { get; private set; }
        private void OnEditAbsenceCommandExecute(Absence absence)
        {
            var vm = new EditAbsenceViewModel(absence);
            Openwindow(vm);

            //Update the absence
            foreach (var item in this.Absences.Where(a => a.ID == absence.ID))
            {
                item.Name = vm.Name;
                item.Abriviature = vm.Abriviature;
                item.Days = vm.Days;
            }

            File.Delete(FileToOperate);
            foreach (var item in this.Absences)
            {
                File.AppendAllText(FileToOperate, $"{item.Name},{item.Abriviature},{item.Days}" + Environment.NewLine);
            }
        }

        #endregion

        #region DeleteAbsenceCommand

        public Command DeleteAbsenceCommand { get; private set; }
        private void OnDeleteAbsenceCommandExecute()
        {
            var itemsToDelete = new List<Absence>();
            foreach (var item in this.Absences)
            {
                if (item.IsSelectedForDelete)
                {
                    itemsToDelete.Add(item);
                }
            }

            foreach (var item in itemsToDelete)
            {
                this.Absences.Remove(item);
            }
            File.Delete(FileToOperate);

            if(this.Absences != null)
            {
                foreach (var absence in this.Absences)
                {
                    File.AppendAllText(FileToOperate, $"{absence.Name},{absence.Abriviature}, {absence.Days}");
                }
            }
            
            MessageBox.Show("Items successfully deleted!", "Deleted absences");
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
