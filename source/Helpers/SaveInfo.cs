using System;
using System.IO;

namespace FWAK.Helpers
{
    class SaveInfo
    {
        private static string _saveFolder
        {
            get
            {
                return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FWAK");
            }
        }

        public static string SaveFolder
        {
            get
            {
                return _saveFolder;
            }
        }

        public static string SettingsFile
        {
            get
            {
                return Path.Combine(_saveFolder, "settings.json");
            }
        }

        public static string CommandsFolder
        {
            get
            {
                return Path.Combine(_saveFolder, "commands");
            }
        }

        
    }
}
