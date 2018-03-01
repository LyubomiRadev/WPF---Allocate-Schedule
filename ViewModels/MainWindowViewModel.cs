namespace LogInForm.ViewModels
{
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Services;
    using System.Threading.Tasks;
    using System.Collections.ObjectModel;
    using Models;
    using Catel.Data;
    using System.Linq;
    using System.IO;
    using System;
    using System.Windows;
    public class MainWindowViewModel : ViewModelBase
    {
        public override string Title { get { return "Log in Window"; } }

        //<Name>,<Abriviature>,<FirstStartingHour>,<FirstStartingMinute>,<FirstClosingHour>,<FirstClosingMinute>,<SecondStartingHour>,
        //<SecondStartingMinute>,<SecondClosingHour>,<SecondClosingMinute>,<FirstPeriodHours>,<SecondPeriodHours>

        #region Constructor

        public MainWindowViewModel()
        {
            this.Users = new ObservableCollection<User>();
            this.Shifts = new ObservableCollection<Shift>();
            this.Absences = new ObservableCollection<Absence>();
            this.Employees = new ObservableCollection<Employee>();
            //Commands
            this.OpenControlPanelCommand = new Command<object>(this.OnOpenControlPanelCommandExecute);

            this.CloseWindow = new Command(this.OnCloseWindowExecute);

            var scheduleFile = @"D:\GeoCon Education\LogInForm\Folders\Schedule";

            if (!Directory.Exists(scheduleFile))
            {
                Directory.CreateDirectory(scheduleFile);
            }

            ImportEmployeesList();

            ImportAbsencesList();

            ImportShiftsData();

            ImportUsersData();

        }

        #endregion

        #region Properties


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


        public ObservableCollection<Shift> Shifts
        {
            get { return GetValue<ObservableCollection<Shift>>(ShiftsProperty); }
            set { SetValue(ShiftsProperty, value); }
        }

        public static readonly PropertyData ShiftsProperty = RegisterProperty(nameof(Shifts), typeof(ObservableCollection<Shift>), null);

        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>), null);


        public string UserName
        {
            get { return GetValue<string>(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }
        public static readonly PropertyData UserNameProperty = RegisterProperty(nameof(UserName), typeof(string), string.Empty);


        public string Password
        {
            get { return GetValue<string>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly PropertyData PasswordProperty = RegisterProperty(nameof(Password), typeof(string), null);


        #endregion

        #region Commands & Methods

        #region OpenControlPanel Command

        public Command<object> OpenControlPanelCommand { get; private set; }
        private void OnOpenControlPanelCommandExecute(object arugment)
        {
            var passBox = arugment as System.Windows.Controls.PasswordBox;
            var passwordFromQuery = passBox.Password;

            var checkUser = this.Users.FirstOrDefault(u => u.UserName.Trim() == this.UserName.Trim());
            if (checkUser != null)
            {
                var userPass = EncryptDecrypt.Decrypt(checkUser.Password, EncryptDecrypt.passPhrase);
                if (passwordFromQuery == userPass)
                {
                    if (checkUser.Level != AccessType.NaN)
                    {
                        checkUser.SuccessfulLogins.Add(new DateTime(DateTime.Now.Ticks));
                        var vm = new ControlPanelViewModel(this.Users, checkUser, this.Shifts, this.Absences, this.Employees);
                        Openwindow(vm);
                    }
                    else
                    {
                        MessageBox.Show($"User {checkUser.UserName} access rights limited!", "Restriction Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }

                }
                else
                {
                    checkUser.UnsuccessfulLogins.Add(new DateTime(DateTime.Now.Ticks));
                    MessageBox.Show("Wrong Password! Please try again", "Incorrect Password");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wrong username! Please try again", "No such username");
                return;
            }

            this.SaveAndCloseViewModelAsync();
        }

        #endregion

        #region CloseWindow Command

        public Command CloseWindow { get; private set; }
        private void OnCloseWindowExecute()
        {
            this.SaveAndCloseViewModelAsync();
        }

        #endregion

        #region OpenWindow Method

        public void Openwindow(IViewModel vm)
        {
            var uiVisualizerService = this.GetDependencyResolver().Resolve<IUIVisualizerService>();
            uiVisualizerService.ShowDialog(vm);
        }

        #endregion

        #region AddIdMethod

        public int AddId()
        {
            var id = this.Users.Max(u => u.ID) + 1;

            return id;
        }

        #endregion

        #region ConvertToIntMethod

        private int ConvertToIntMethod(string text)
        {
            var converter = 0;
            var outParameter = 0;
            if (int.TryParse(text, out converter))
            {
                outParameter = converter;
            }

            return outParameter;
        }
        #endregion

        #region ImportEmployeesList Method

        private void ImportEmployeesList()
        {

            if (!File.Exists(@"D:\GeoCon Education\LogInForm\Folders\allEmployees.csv"))
            {
                File.Create(@"D:\GeoCon Education\LogInForm\Folders\allEmployees.csv").Close();
            }

            var allEmployees = File.ReadAllLines(@"D:\GeoCon Education\LogInForm\Folders\allEmployees.csv");

            if (allEmployees.Count() > 0)
            {
                foreach (var line in allEmployees)
                {
                    var separetedLine = line.Split(',');
                    var out1 = 0;
                    var age = 0;
                    var position = new Position();
                    var status = new Status();

                    if (int.TryParse(separetedLine[3], out out1))
                    {
                        position = (Position)out1;
                    }

                    if (int.TryParse(separetedLine[4], out out1))
                    {
                        status = (Status)out1;
                    }

                    if (int.TryParse(separetedLine[2], out out1))
                    {
                        age = out1;
                    }

                    var newEmployee = new Employee()
                    {
                        FirstName = separetedLine[0].Trim(),
                        LastName = separetedLine[1].Trim(),
                        Age = age,
                        Position = position,
                        Status = status,
                        ID = this.Employees.Count
                    };

                    this.Employees.Add(newEmployee);
                }
            }
            
        }

        #endregion

        #region ImportAbsencesList Method

        private void ImportAbsencesList()
        {
            if (!File.Exists(@"D:\GeoCon Education\LogInForm\Folders\allAbsences.csv"))
            {
                File.Create(@"D:\GeoCon Education\LogInForm\Folders\allAbsences.csv").Close();
            }
            var allAbsencesFile = File.ReadAllLines(@"D:\GeoCon Education\LogInForm\Folders\allAbsences.csv");

            foreach (var line in allAbsencesFile)
            {
                var separetedLine = line.Split(new char[] { ',', ' ' });
                int out1 = 0;
                var days = 0;
                if (int.TryParse(separetedLine[2], out out1))
                {
                    days = out1;
                }
                var newAbsence = new Absence()
                {
                    Name = separetedLine[0],
                    Abriviature = separetedLine[1],
                    ID = this.Absences.Count(),
                    Days = days
                };

                this.Absences.Add(newAbsence);
            }
        }

        #endregion

        #region ImportUsersData Method

        private void ImportUsersData()
        {

            if (!File.Exists(@"D:\GeoCon Education\LogInForm\Folders\allUsers.csv"))
            {
                File.Create(@"D:\GeoCon Education\LogInForm\Folders\allUsers.csv").Close();
            }

            var allUsersFile = File.ReadAllLines(@"D:\GeoCon Education\LogInForm\Folders\allUsers.csv");

            foreach (var line in allUsersFile)
            {
                var separetedLine = line.Split(',');
                var id = 0;

                if (this.Users.Count != 0)
                {
                    id = this.Users.Max(u => u.ID) + 1;
                }

                var userName = separetedLine[1];
                var firstName = separetedLine[2];
                var lastName = separetedLine[3];
                var date = separetedLine[4].Split(new char[] { '.', '/' });
                var day = int.Parse(date[0]);
                var month = int.Parse(date[1]);
                var year = int.Parse(date[2]);
                var creationDate = DateTime.Now.ToString("dd.MM.yyyy");

                var level = AccessType.NaN;
                var tmpLevel = 0;
                if (int.TryParse(separetedLine[5].Trim(), out tmpLevel))
                {
                    level = (AccessType)tmpLevel;
                }
                var password = separetedLine[6];

                var newUser = new User()
                {
                    CreationDate = creationDate,
                    ID = id,
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Level = level
                };

                this.Users.Add(newUser);
            }
        }

        #endregion

        #region ImportShiftsData Method

        private void ImportShiftsData()
        {

            if (!File.Exists(@"D:\GeoCon Education\LogInForm\Folders\allShifts.csv"))
            {
                File.Create(@"D:\GeoCon Education\LogInForm\Folders\allShifts.csv").Close();
            }

            var allShiftsFile = File.ReadAllLines(@"D:\GeoCon Education\LogInForm\Folders\allShifts.csv");

            if (allShiftsFile.Count() > 0)
            {
                foreach (var line in allShiftsFile)
                {

                    //ints
                    var firstStartingHour = 0;
                    var firstStartingMunute = 0;
                    var firstClosingHour = 0;
                    var firstClosingMin = 0;
                    var SecondClosingHour = 0;
                    var secondClosingMin = 0;
                    var secondStartingHour = 0;
                    var secondStartingMin = 0;
                    var firstPeriodHours = 0;
                    var secondPeriodHours = 0;
                    var out1 = 0;
                    var breakFirstPeriod = 0;
                    var breakSecondPeriod = 0;

                    var separetedLine = line.Split(',');

                    var name = string.Empty;
                    var abriviature = string.Empty;
                    var firstStartingHourStr = string.Empty;
                    var firstStartingMunuteStr = string.Empty;
                    var firstClosingHourStr = string.Empty;
                    var firstClosingMinStr = string.Empty;
                    var firstPeriodHoursStr = string.Empty;

                    name = separetedLine[0].Trim();
                    abriviature = separetedLine[1].Trim();
                    firstStartingHourStr = separetedLine[2].Trim();
                    firstStartingMunuteStr = separetedLine[3].Trim();
                    firstClosingHourStr = separetedLine[4].Trim();
                    firstClosingMinStr = separetedLine[5].Trim();
                    var secondStartingHourStr = separetedLine[6].Trim();
                    var secondStartingMinStr = separetedLine[7].Trim();
                    var secondClosingHourStr = separetedLine[8].Trim();
                    var secondClosingMinStr = separetedLine[9].Trim();
                    firstPeriodHoursStr = separetedLine[10].Trim();
                    var secondPeriodHoursStr = separetedLine[11].Trim();
                    var breakFirstPeriodStr = separetedLine[12].Trim();
                    var breakSecondPeriodStr = separetedLine[13].Trim();

                    //first period hours convertion to int
                    firstStartingHour = ConvertToIntMethod(firstStartingHourStr);
                    firstStartingMunute = ConvertToIntMethod(firstStartingMunuteStr);
                    firstClosingHour = ConvertToIntMethod(firstClosingHourStr);
                    firstClosingMin = ConvertToIntMethod(firstClosingMinStr);
                    breakFirstPeriod = ConvertToIntMethod(breakFirstPeriodStr);
                    firstPeriodHours = ConvertToIntMethod(firstPeriodHoursStr);

                    //second period hours convertion to int
                    secondStartingHour = ConvertToIntMethod(secondStartingHourStr);
                    secondStartingMin = ConvertToIntMethod(secondStartingMinStr);
                    SecondClosingHour = ConvertToIntMethod(secondClosingHourStr);
                    secondClosingMin = ConvertToIntMethod(secondClosingMinStr);
                    breakSecondPeriod = ConvertToIntMethod(breakSecondPeriodStr);
                    secondPeriodHours = ConvertToIntMethod(secondPeriodHoursStr);

                    var addShift2 = new Shift()
                    {
                        Name = name,
                        Abriviature = abriviature,
                        FirstStartingHour = firstStartingHour,
                        FirstStartingMinute = firstStartingMunute,
                        FirstClosingHour = firstClosingHour,
                        FirstClosingMinute = firstClosingMin,
                        FirstPeriodHours = firstPeriodHours,
                        SecondStartingHour = secondStartingHour,
                        SecondStartingMinute = secondStartingMin,
                        SecondClosingHour = SecondClosingHour,
                        SecondClosingMinute = secondClosingMin,
                        SecondPeriodHours = secondPeriodHours,
                        BreakFirstPeriod = breakFirstPeriod,
                        BreakSecondPeriod = breakSecondPeriod
                    };

                    this.Shifts.Add(addShift2);

                }
            }
        }

        #endregion

        #endregion

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }
        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
