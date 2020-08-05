using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWAK.Model
{
    class Job : Notify
    {

        public Job(String jobName, bool pin)
        {
            Name = jobName;
            Pin = pin;
        }


        #region Properties

        // private
        private string _name;
        private Guid _guid;
        private string _watchFolder;
        private string _outputFolder;
        private Command _command;
        private bool _pin;
        private bool _running;
        private string _simpleLog;
        private List<Task> _tasks;
        private bool _watchMode;
        private bool _processExisting;
        private List<string> _libraries;
        private DateTime _created;
        private DateTime _started;
        private List<Tuple<DateTime, DateTime>> _runtimeHistory;
        private double _largestFileSize;
        private double _smallestFileSize;
        private double _averageFileSize;
        private double _longestFileRuntime;
        private double _shortestFileRuntime;
        private double _averageFileRuntime;
        private int _successfullCount;
        private int _failureCount;

        //public

        /// <summary>
        /// Name Of The Job
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Guid GUID
        {
           get { return _guid; }
            set
            {
                if (_guid != value)
                {
                    _guid = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Pin Job To Dashboard
        /// </summary>
        public bool Pin
        {
            get { return _pin; }
            set
            {
                if (_pin != value)
                {
                    _pin = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Is Job Running
        /// </summary>
        public bool Running
        {
            get { return _running; }
            set
            {
                if (_running != value)
                {
                    _running = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string SimpleLog
        {
            get { return _simpleLog; }
            set
            {
                if (_simpleLog != value)
                {
                    _simpleLog = value;
                }
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
