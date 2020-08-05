using FWAK.Helpers;
using FWAK.Model;
using FWAK.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FWAK.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel() : base()
        {
            LinkCommands();

            Settings = new Settings();

            LoadSettings();

            Settings.SetDarkTheme();

            if (Settings.CustomCoreCount > Environment.ProcessorCount - 1)
                Settings.CustomCoreCount = Environment.ProcessorCount - 1;


            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));
            Jobs.Add(new Job("HAHAH", true));

            DashboardSelected = true;
            Debug.WriteLine(Jobs.Count);

            SetView();
        }

        #region Properties

        static public ObservableCollection<Job> Jobs = new ObservableCollection<Job>();
        static public Settings Settings { get; set; }

        private bool _rightDrawerShown;
        public bool RightDrawerShown
        {
            get
            {
                return _rightDrawerShown;
            }
            set
            {
                _rightDrawerShown = value;
                NotifyPropertyChanged();
            }
        }

        private object _rightDrawerContent;
        public object RightDrawerContent
        {
            get
            {
                return _rightDrawerContent;
            }
            set
            {
                if (_rightDrawerContent != value)
                {
                    _rightDrawerContent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get
            {
                return _selectedViewModel;
            }
            set
            {
                if (_selectedViewModel != value)
                {
                    _selectedViewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _dashboardSelected;
        public bool DashboardSelected
        {
            get { return _dashboardSelected; }
            set
            {
                if (_dashboardSelected != value)
                {
                    _dashboardSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _jobsSelected;
        public bool JobsSelected
        {
            get { return _jobsSelected; }
            set
            {
                if (_jobsSelected != value)
                {
                    _jobsSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _commandsSelected;
        public bool CommandsSelected
        {
            get { return _commandsSelected; }
            set
            {
                if (_commandsSelected != value)
                {
                    _commandsSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _hasJobs;
        public bool HasJobs
        {
            get { return _hasJobs; }
            set
            {
                if (_hasJobs != value)
                {

                }
            }
        }


        #endregion

        #region Commands

        public RelayCommand CloseCommand { get; private set; }
        public RelayCommand ShowSettingsCommand { get; private set; }
        public RelayCommand SetViewCommand { get; private set; }

        #endregion

        #region Events

        private void Close(object o)
        {
            ((MainView)o).ExitApplication();
        }

        private void ShowSettings(object o)
        {
            RightDrawerContent = new SettingsView()
            {
                DataContext = new SettingsViewModel()
            };
            RightDrawerShown = true;
        }

        private void SetView(object o)
        {
            SetView();
        }

        #endregion

        #region Methods

        private void SetView()
        {
            if (DashboardSelected)
            {
                SelectedViewModel = new DashboardView()
                {
                    DataContext = new DashboardViewModel()
                };
                return;
            }


            SelectedViewModel = null;
        }

        private void LinkCommands()
        {
            CloseCommand = new RelayCommand(Close);
            ShowSettingsCommand = new RelayCommand(ShowSettings);
            SetViewCommand = new RelayCommand(SetView);
        }

        public static void SaveSettings()
        {
            try
            {
                if (!Directory.Exists(SaveInfo.SaveFolder))
                {
                    Directory.CreateDirectory(SaveInfo.SaveFolder);
                }

                var save = JsonConvert.SerializeObject(Settings, Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                File.WriteAllText(SaveInfo.SettingsFile, save);
            }
            catch
            {

            }
        }

        private static void LoadSettings()
        {
            try
            {
                if (File.Exists(SaveInfo.SettingsFile))
                {
                    string save = File.ReadAllText(SaveInfo.SettingsFile);
                    Settings = JsonConvert.DeserializeObject<Model.Settings>(save);
                }
            }
            catch
            {

            }
        }

        public static void SaveJobs()
        {

        }

        public static void SaveJob(Job job)
        {

        }

        #endregion
    }
}
