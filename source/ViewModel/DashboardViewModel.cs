using FWAK.Helpers;
using FWAK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWAK.ViewModel
{
    class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {
            LinkCommands();
            AreThereAnyPinnedJobs();
            
        }

        #region Properties

        //private 
        private bool _pinnedJobs;

        //public 
        public ObservableCollection<Job> JobList
        {
            get { return MainViewModel.Jobs; }
        }

        public bool PinnedJobs
        {
            get { return _pinnedJobs; }
            set
            {
                if (_pinnedJobs != value)
                {
                    _pinnedJobs = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //commands
        public RelayCommand UnpinJobCommand { get; private set; }

        #endregion

        #region Events

        private void UnpinJob(object o)
        {
            Job job = o as Job;
            job.Pin = false;
            MainViewModel.SaveJob(job);
            AreThereAnyPinnedJobs();
        }

        #endregion

        #region Methods

        private void LinkCommands()
        {
            UnpinJobCommand = new RelayCommand(UnpinJob);
        }
        
        private void AreThereAnyPinnedJobs()
        {
           PinnedJobs = MainViewModel.Jobs.FirstOrDefault(Job => Job.Pin == true) != null;
        }



        #endregion
    }
}
