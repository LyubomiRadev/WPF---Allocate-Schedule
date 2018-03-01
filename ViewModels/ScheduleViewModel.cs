using Catel.Data;
using Catel.MVVM;
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
    public class ScheduleViewModel : ViewModelBase
    {
        public override string Title { get { return "Schedule Window"; } }

        #region Constructor

        public ScheduleViewModel(ObservableCollection<Employee> employees, ObservableCollection<Shift> shifts, ObservableCollection<Absence> absences)
        {
            var monthsRange = Enumerable.Range(1, 12).ToList();
            var yearsRange = Enumerable.Range(2018, 50).ToList();

            this.Absences = absences;
            this.Shifts = shifts;
            this.Employees = employees;
            this.MonthsRange = monthsRange;
            this.YearsRange = yearsRange;
            this.EmployeesWithSchedule = new ObservableCollection<Employee>();
            this.EmployeesWithNoSchedule = new ObservableCollection<Employee>();
            this.SelectedMonth = DateTime.Now.Month;
            this.SelectedYear = DateTime.Now.Year;

            //Commands
            this.ApplyCommand = new Command(this.OnApplyCommandExecute);
            this.SelectedShiftCommand = new Command<Shift>(this.OnSelectedShiftCommandExecute);
            this.SelectedAbsenceCommand = new Command<Absence>(this.OnSelectedAbsenceCommandExecute);
            this.AddEmployeeSchedule = new Command(this.OnAddEmployeeScheduleExecute);
            this.SaveCommand = new Command(this.OnSaveCommandExecute);
            this.PrintCommand = new Command(this.OnPrintCommandExecute);

            var monthInString = this.SelectedMonth.ToString();
            if (this.SelectedMonth < 10)
            {
                monthInString = "0" + this.SelectedMonth.ToString();
            }

            var folderToRead = $"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\{monthInString}{this.SelectedYear}";

            //check if folder exists and fill in data
          
            CheckAndFillInDataMethod(folderToRead);
            
        }
        
        #endregion

        #region Properties

        public DateTime SelectedDate
        {
            get { return GetValue<DateTime>(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
        public static readonly PropertyData SelectedDateProperty = RegisterProperty(nameof(SelectedDate), typeof(DateTime), DateTime.Now);

        public ObservableCollection<Shift> Shifts
        {
            get { return GetValue<ObservableCollection<Shift>>(ShiftsProperty); }
            set { SetValue(ShiftsProperty, value); }
        }
        public static readonly PropertyData ShiftsProperty = RegisterProperty(nameof(Shifts), typeof(ObservableCollection<Shift>), null);

        public ObservableCollection<Employee> Employees
        {
            get { return GetValue<ObservableCollection<Employee>>(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }
        public static readonly PropertyData EmployeesProperty = RegisterProperty(nameof(Employees), typeof(ObservableCollection<Employee>), null);

        public ObservableCollection<Absence> Absences
        {
            get { return GetValue<ObservableCollection<Absence>>(AbsencesProperty); }
            set { SetValue(AbsencesProperty, value); }
        }
        public static readonly PropertyData AbsencesProperty = RegisterProperty(nameof(Absences), typeof(ObservableCollection<Absence>), null);

        public ObservableCollection<Employee> EmployeesWithSchedule
        {
            get { return GetValue<ObservableCollection<Employee>>(EmployeesWithScheduleProperty); }
            set { SetValue(EmployeesWithScheduleProperty, value); }
        }
        public static readonly PropertyData EmployeesWithScheduleProperty = RegisterProperty(nameof(EmployeesWithSchedule), typeof(ObservableCollection<Employee>), null);

        public ObservableCollection<Employee> EmployeesWithNoSchedule
        {
            get { return GetValue<ObservableCollection<Employee>>(EmployeesWithNoScheduleProperty); }
            set { SetValue(EmployeesWithNoScheduleProperty, value); }
        }
        public static readonly PropertyData EmployeesWithNoScheduleProperty = RegisterProperty(nameof(EmployeesWithNoSchedule), typeof(ObservableCollection<Employee>), null);

        public List<int> MonthsRange
        {
            get { return GetValue<List<int>>(MonthsRangeProperty); }
            set { SetValue(MonthsRangeProperty, value); }
        }
        public static readonly PropertyData MonthsRangeProperty = RegisterProperty(nameof(MonthsRange), typeof(List<int>), null);

        public List<int> YearsRange
        {
            get { return GetValue<List<int>>(YearsRangeProperty); }
            set { SetValue(YearsRangeProperty, value); }
        }
        public static readonly PropertyData YearsRangeProperty = RegisterProperty(nameof(YearsRange), typeof(List<int>), null);


        public int SelectedYear
        {
            get { return GetValue<int>(SelectedYearProperty); }
            set { SetValue(SelectedYearProperty, value); }
        }
        public static readonly PropertyData SelectedYearProperty = RegisterProperty(nameof(SelectedYear), typeof(int), null, (s, e) => ((ScheduleViewModel)s).OnSelectedYearChanged());

        public int SelectedMonth
        {
            get { return GetValue<int>(SelectedMonthProperty); }
            set { SetValue(SelectedMonthProperty, value); }
        }
        public static readonly PropertyData SelectedMonthProperty = RegisterProperty(nameof(SelectedMonth), typeof(int), null, (s, e) => ((ScheduleViewModel)s).OnSelectedMonthChanged());

        public bool IsVisibleAfterApply
        {
            get { return GetValue<bool>(IsVisibleAfterApplyProperty); }
            set { SetValue(IsVisibleAfterApplyProperty, value); }
        }
        public static readonly PropertyData IsVisibleAfterApplyProperty = RegisterProperty(nameof(IsVisibleAfterApply), typeof(bool), false);

        public Shift SelectedShift
        {
            get { return GetValue<Shift>(SelectedShiftProperty); }
            set { SetValue(SelectedShiftProperty, value); }
        }
        public static readonly PropertyData SelectedShiftProperty = RegisterProperty(nameof(SelectedShift), typeof(Shift), null);

        public Absence SelectedAbsence
        {
            get { return GetValue<Absence>(SelectedAbsenceProperty); }
            set { SetValue(SelectedAbsenceProperty, value); }
        }
        public static readonly PropertyData SelectedAbsenceProperty = RegisterProperty(nameof(SelectedAbsence), typeof(Absence), null);

        public Employee SelectedEmployee
        {
            get { return GetValue<Employee>(SelectedEmployeeProperty); }
            set { SetValue(SelectedEmployeeProperty, value); }
        }
        public static readonly PropertyData SelectedEmployeeProperty = RegisterProperty(nameof(SelectedEmployee), typeof(Employee), null);

        public DateTime FirstDayOfMonth
        {
            get { return GetValue<DateTime>(FirstDayOfMonthProperty); }
            set { SetValue(FirstDayOfMonthProperty, value); }
        }
        public static readonly PropertyData FirstDayOfMonthProperty = RegisterProperty(nameof(FirstDayOfMonth), typeof(DateTime), null);

        public DateTime LastDayOfMonth
        {
            get { return GetValue<DateTime>(LastDayOfMonthProperty); }
            set { SetValue(LastDayOfMonthProperty, value); }
        }
        public static readonly PropertyData LastDayOfMonthProperty = RegisterProperty(nameof(LastDayOfMonth), typeof(DateTime), null);


        #endregion

        #region Commands & Methods

        #region ApplyCommand

        public Command ApplyCommand { get; private set; }
        private void OnApplyCommandExecute()
        {
            var lastDay = DateTime.DaysInMonth(this.SelectedYear, this.SelectedMonth);

            this.FirstDayOfMonth = new DateTime(this.SelectedYear, this.SelectedMonth, 1);
            this.LastDayOfMonth = new DateTime(this.SelectedYear, this.SelectedMonth, lastDay);
            if (this.SelectedDate < this.FirstDayOfMonth || this.SelectedDate > this.LastDayOfMonth)
            {
                this.SelectedDate = new DateTime(this.FirstDayOfMonth.Ticks);
            }

            //convert month to two symbols
            var monthInString = this.SelectedMonth.ToString();
            if (this.SelectedMonth < 10)
            {
                monthInString = "0" + this.SelectedMonth.ToString();
            }

            this.EmployeesWithNoSchedule = new ObservableCollection<Employee>();
            this.EmployeesWithSchedule = new ObservableCollection<Employee>();

            //Check if folder exists and create
            if (!Directory.Exists($"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\{monthInString}{this.SelectedYear}"))
            {
                Directory.CreateDirectory($"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\{monthInString}{this.SelectedYear}");
            }

            //Check if file exists and separate employees with schedule and no schedule
            foreach (var employee in this.Employees.Where(empl => empl.Status == Status.Avtive))
            {
                if (!File.Exists($"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\{monthInString}{this.SelectedYear}\\{employee.ID}.csv"))
                {

                    this.EmployeesWithNoSchedule.Add(employee);

                }
                else
                {

                    this.EmployeesWithSchedule.Add(employee);

                }
            }

            this.IsVisibleAfterApply = !this.IsVisibleAfterApply;
        }

        #endregion

        #region AddEmployeeSchedule

        public Command AddEmployeeSchedule { get; private set; }
        private void OnAddEmployeeScheduleExecute()
        {
            if (this.SelectedEmployee == null)
            {
                MessageBox.Show("Plese select an employee", "No employee selected");
                return;
            }

            //convert month to two symbols
            var monthInString = this.SelectedMonth.ToString();
            if (this.SelectedMonth < 10)
            {
                monthInString = "0" + this.SelectedMonth.ToString();
            }

            //check file and create
            var emplFile = $"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\{monthInString}{this.SelectedYear}\\{this.SelectedEmployee.ID}.csv";
            if (!File.Exists(emplFile))
            {
                File.Create(emplFile).Close();
            }
            this.IsVisibleAfterApply = false;
            OnApplyCommandExecute();
        }
        #endregion

       

        #region SelectedShiftCommand

        public Command<Shift> SelectedShiftCommand { get; private set; }
        private void OnSelectedShiftCommandExecute(Shift shift)
        {
            this.SelectedShift = shift;
            var operatedEmployees = 0;

            var newShift = new ShiftsAndAbsences()
            {

                Abriviature = this.SelectedShift.Abriviature,
                WorkingHours = this.SelectedShift.TotalWorkingHours,
                DayOfUse = this.SelectedDate,
                AttendanceType = 0
            };



            //go throuhg all employees and if selected fill in data
            foreach (var employee in this.EmployeesWithSchedule)
            {
                if (employee.IsSelected)
                {
                    var shiftAndAbsencesList = employee.ShiftsAndAbsences.ToList();
                    shiftAndAbsencesList.Add(newShift);
                    employee.Shifts = null;
                    employee.ShiftsAndAbsences = new ObservableCollection<ShiftsAndAbsences>(shiftAndAbsencesList.OrderBy(t => t.DayOfUse));
                    operatedEmployees++;
                }
            }

            if (operatedEmployees == 0)
            {
                MessageBox.Show("Please select an employee for action!", "No employee selected");
            }
        }
        #endregion

        #region SelectedAbsenceCommand

        public Command<Absence> SelectedAbsenceCommand { get; private set; }
        private void OnSelectedAbsenceCommandExecute(Absence absence)
        {
            this.SelectedAbsence = absence;

            //calculate the starting and ending date of the absence
            var startingDateOfAbsence = this.SelectedDate;
            var endDateOfAbsence = startingDateOfAbsence.AddDays(this.SelectedAbsence.Days - 1);

            while (startingDateOfAbsence <= endDateOfAbsence)
            {
                foreach (var employee in this.EmployeesWithSchedule)
                {
                    //check which employee is enabled and fill in data
                    if (employee.IsSelected)
                    {
                        var newAbsence = new ShiftsAndAbsences()
                        {
                            Abriviature = this.SelectedAbsence.Abriviature,
                            WorkingHours = 0,
                            AttendanceType = 1,
                            DayOfUse = startingDateOfAbsence
                        };
                        employee.ShiftsAndAbsences.Add(newAbsence);
                    }
                }
                startingDateOfAbsence = startingDateOfAbsence.AddDays(1);
            }

        }

        #endregion

        #region SaveCommand

        public Command SaveCommand { get; private set; }
        private void OnSaveCommandExecute()
        {
            var monthInString = this.SelectedMonth.ToString();

            if (this.SelectedMonth < 10)
            {
                monthInString = "0" + this.SelectedMonth.ToString();
            }

            //go through each employee and fill info in a specific file for the employee
            foreach (var employee in this.EmployeesWithSchedule)
            {
                var fileName = $"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\{monthInString}{this.SelectedYear}\\{employee.ID}.csv";

                if (employee.ShiftsAndAbsences.Count() != 0)
                {
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    File.Create(fileName).Close();
                    foreach (var item  in employee.ShiftsAndAbsences)
                    {
                        var day = item.DayOfUse.ToString("dd.MM.yyyy");
                        File.AppendAllText(fileName, $"{item.Abriviature},{item.WorkingHours},{day},{item.AttendanceType}" + Environment.NewLine);
                    }
                }

            }
        }

        #endregion

        #region PrintCommand

        public Command PrintCommand { get; private set; }
        private void OnPrintCommandExecute()
        {
            var monthInString = string.Empty;
            var employeesWithSchedule = new List<Employee>();

            if (this.SelectedMonth < 10)
            {
                monthInString = "0" + this.SelectedMonth.ToString();
            }

            //collect all employees with schedule for the selected month and year
            foreach (var employee in this.Employees)
            {
                var employeeFileRecordForSelectedMonth = $"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\{monthInString}{this.SelectedYear}\\{employee.ID}.csv";

                if (File.Exists(employeeFileRecordForSelectedMonth))
                {
                    if (employee.ShiftsAndAbsences.Count() > 0)
                    {
                        employeesWithSchedule.Add(employee);
                    }

                }
            }

            var newFolderForFiles = $"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\FilesForPrint\\{monthInString}{this.SelectedYear}";

            //create new Folder for files
            if (!Directory.Exists(newFolderForFiles))
            {
                Directory.CreateDirectory(newFolderForFiles);
            }

            foreach (var employee in employeesWithSchedule)
            {
                var newFileForEmployee = $"D:\\GeoCon Education\\LogInForm\\Folders\\Schedule\\FilesForPrint\\{monthInString}{this.SelectedYear}\\{employee.FullNameOneLine}.txt";
                var totalHoursForTheMonth = 0.0M;

                //delete old employee file and replace with a new one
                if (File.Exists(newFileForEmployee))
                {
                    File.Delete(newFileForEmployee);
                }

                File.AppendAllText(newFileForEmployee,$"{employee.FullNameOneLine}" + Environment.NewLine + $"{this.SelectedMonth}.{this.SelectedYear}" + Environment.NewLine);

                foreach (var item in employee.ShiftsAndAbsences)
                {

                    if (item.AttendanceType == 0)
                    {
                        var shift = this.Shifts.FirstOrDefault(s => s.Abriviature == item.Abriviature);
                        var shiftWorkingHours = shift.TotalWorkingHours / 60.0M;
                        var day = item.DayOfUse.Day.ToString();

                        if(day.Length < 2)
                        {
                            day = "0" + day;
                        }
                        
                        //depending on existance of second shift add info to file
                        if (shift.SecondShift)
                        {
                            File.AppendAllText(newFileForEmployee, $"{day}, {shift.FirstStartingHour}:{shift.FirstStartingMinute} - {shift.FirstClosingHour}:{shift.FirstClosingMinute} втора част {shift.SecondStartingHour}:{shift.SecondStartingMinute} - {shift.SecondClosingHour}:{shift.SecondClosingMinute} Общо часове - {shiftWorkingHours}" + Environment.NewLine);
                        }
                        else
                        {
                            File.AppendAllText(newFileForEmployee, $"{day}, {shift.FirstStartingHour}:{shift.FirstStartingMinute} - {shift.FirstClosingHour}:{shift.FirstClosingMinute} Общо часове - {shiftWorkingHours}" + Environment.NewLine);
                        }

                        totalHoursForTheMonth += shiftWorkingHours;

                    }
                    else
                    {
                        var absence = this.Absences.FirstOrDefault(a => a.Abriviature == item.Abriviature);

                        //take only the certain day 
                        var absDay = item.DayOfUse.Day.ToString();

                        if (absDay.Length < 2)
                        {
                            absDay = "0" + absDay;
                        }

                        File.AppendAllText(newFileForEmployee, $"{absDay} {absence.Days}" + Environment.NewLine);
                    }
                }

                File.AppendAllText(newFileForEmployee, $"Сбор часове за месеца - {totalHoursForTheMonth}");

            }
        }

        #endregion

        #region ConvertInt Method

        private int ConvertIntMethod(string strParametr)
        {
            var outInt = 0;
            var value = 0;
            if (int.TryParse(strParametr, out outInt))
            {
                value = outInt;
            }

            return value;

        }

        #endregion

        #region Selected Properties Change

        private void OnSelectedMonthChanged()
        {
            this.IsVisibleAfterApply = false;
        }

        private void OnSelectedYearChanged()
        {
            this.IsVisibleAfterApply = false;
        }

        #endregion

        #region CheckAndFillInDataMethod

        private void CheckAndFillInDataMethod(string folderToRead)
        {
            if (Directory.Exists(folderToRead))
            {
                //read all the files
                foreach (string file in Directory.EnumerateFiles(folderToRead, "*.csv"))
                {
                    //separate data to get file name and employee ID
                    var contents = File.ReadAllLines(file);
                    var fileName = Path.GetFileName(file).Split('.');
                    var employeeIdString = fileName[0];
                    var employeeId = ConvertIntMethod(employeeIdString);

                    //check if file name is equal to employee ID and fill in data
                    foreach (var employee in this.Employees)
                    {
                        if (employee.ID == employeeId)
                        {
                            employee.ShiftsAndAbsences = new ObservableCollection<ShiftsAndAbsences>();

                            foreach (var line in contents)
                            {
                                var outParam = 0.0M;
                                var separatedInfo = line.Split(',');
                                var abriviature = separatedInfo[0];
                                var workingHoursString = separatedInfo[1];
                                decimal workingHours = 0.0M;
                                if (decimal.TryParse(workingHoursString, out outParam))
                                {
                                    workingHours = outParam;
                                }
                                var date = separatedInfo[2];
                                var sepDate = date.Split('.');
                                var dayStr = sepDate[0];
                                var monthStr = sepDate[1];
                                var yearStr = sepDate[2];
                                var typeStr = separatedInfo[3];

                                var day = ConvertIntMethod(dayStr);
                                var month = ConvertIntMethod(monthStr);
                                var year = ConvertIntMethod(yearStr);
                                var attendanceType = ConvertIntMethod(typeStr);
                                employee.ShiftsAndAbsences.Add(new ShiftsAndAbsences()
                                {
                                    Abriviature = abriviature,
                                    WorkingHours = workingHours,
                                    DayOfUse = new DateTime(year, month, day),
                                    AttendanceType = attendanceType
                                });
                            }
                        }
                    }

                }
            }
        }

        #endregion

        #endregion
    }
}
