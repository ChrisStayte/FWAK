using FWAK.Helpers;
using FWAK.Model;
using FWAK.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            

        
        }

        #region Properties

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

        #endregion

        #region Commands

        public RelayCommand CloseCommand { get; private set; }
        public RelayCommand ShowSettingsCommand { get; private set; }

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

        #endregion

        #region Methods

        private void LinkCommands()
        {
            CloseCommand = new RelayCommand(Close);
            ShowSettingsCommand = new RelayCommand(ShowSettings);
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

        #endregion
    }
}
