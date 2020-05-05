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
        private bool _pin;
        private bool _run;
        private string _simpleLog;

        //public
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
        public bool Run
        {
            get { return _run; }
            set
            {
                if (_run != value)
                {
                    _run = value;
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
