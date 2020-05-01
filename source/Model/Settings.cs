using FWAK.Model.Enum;
using FWAK.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FWAK.Model
{
    class Settings : INotifyPropertyChanged
    {
        public Settings()
        {
            DarkMode = false;
            KeepOnTop = false;
            ShowNotifications = true;
            PerformanceLevel = 0; // Standard
            CustomCoreCount = 1;
        }

        // Basic ViewModelBase
        internal void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        internal void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetSettings()
        {
            DarkMode = false;
            KeepOnTop = false;
            ShowNotifications = true;
            PerformanceLevel = 0; // Standard
            CustomCoreCount = 1;
        }

        private bool _darkMode;
        public bool DarkMode
        {
            get { return _darkMode; }
            set
            {
                _darkMode = value;
                NotifyPropertyChanged();
            }
        }

        private bool _keepOnTop;
        public bool KeepOnTop
        {
            get { return _keepOnTop; }
            set
            {
                _keepOnTop = value;
                NotifyPropertyChanged();
            }
        }

        private bool _showNotifications;
        public bool ShowNotifications
        {
            get { return _showNotifications; }
            set
            {
                if (_showNotifications != value)
                {
                    _showNotifications = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private PerformanceLevel _performanceLevel;
        public int PerformanceLevel
        {
            get
            {
                return (int)_performanceLevel;
            }
            set
            {
                _performanceLevel = (PerformanceLevel)value;
                NotifyPropertyChanged();
            }
        }

        private int _customCoreCount;
        public int CustomCoreCount
        {
            get { return _customCoreCount; }
            set
            {
                if (_customCoreCount != value)
                {
                    _customCoreCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region Methods

        public void SetDarkTheme()
        {
            var palleteHelper = new PaletteHelper();
            ITheme theme = palleteHelper.GetTheme();

            Color primaryColor = (Color)ColorConverter.ConvertFromString("#FF006098");
            theme.SetPrimaryColor(primaryColor);

            Color secondaryColor = (Color)ColorConverter.ConvertFromString("#FF648C1C");
            theme.SetSecondaryColor(secondaryColor);

            theme.SetBaseTheme(MainViewModel.Settings.DarkMode ? Theme.Dark : Theme.Light);

            palleteHelper.SetTheme(theme);
        }

        #endregion

    }
}
