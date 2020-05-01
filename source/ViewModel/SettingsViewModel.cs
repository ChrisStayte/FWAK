using FWAK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FWAK.ViewModel
{
    class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            LinkCommands();
            SetThemeStatus();

            MaxNumberOfCores = Environment.ProcessorCount - 1;

            VersionNumber = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #region Properties

        // private
        private string _themeName;
        private int _maxNumberOfCores;
        private string _versionNumber;

        // public
        public string ThemeName
        {
            get
            {
                return _themeName;
            }
            set
            {
                if (_themeName != value)
                {
                    _themeName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int MaxNumberOfCores
        {
            get { return _maxNumberOfCores; }
            set
            {
                if (_maxNumberOfCores != value)
                {
                    _maxNumberOfCores = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string VersionNumber
        {
            get { return _versionNumber; }
            set
            {
                if (_versionNumber != value)
                {
                    _versionNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // RelayCommands
        public RelayCommand SetDarkThemeCommand { get; private set; }
        public RelayCommand SaveSettingsCommand { get; private set; }
        public RelayCommand MailToCommand { get; private set; }

        #endregion

        #region Events

        private void SaveSettings(object o)
        {
            MainViewModel.SaveSettings();
        }

        private void SetDarkTheme(object o)
        {
            MainViewModel.Settings.SetDarkTheme();

            SetThemeStatus();

            MainViewModel.SaveSettings();
        }

        private void MailTo(object o)
        {
            string subject = String.Format("CPF User REQ / {0} / Version {1}", System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"), Assembly.GetExecutingAssembly().GetName().Version);

            System.Diagnostics.Process.Start(string.Format("mailto:chris.stayte@woolpert.com?Subject={0}", subject));
        }

        #endregion

        #region Methods

        private void LinkCommands()
        {
            SetDarkThemeCommand = new RelayCommand(SetDarkTheme);
            SaveSettingsCommand = new RelayCommand(SaveSettings);
            MailToCommand = new RelayCommand(MailTo);
        }

        private void SetThemeStatus()
        {
            ThemeName = MainViewModel.Settings.DarkMode ? "Dark" : "Light";
        }

        #endregion
    }
}
