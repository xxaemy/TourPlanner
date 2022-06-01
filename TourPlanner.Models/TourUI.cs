﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using TourPlanner.Models;

namespace TourPlanner.UI.Models
{
    public class TourUI :INotifyPropertyChanged
    {


        private Tour _tourData;
        public Tour TourData {
            get
            {
                return _tourData;
            }
            set
            {
                _tourData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TourData"));
            }
        }

        public ObservableCollection<TourLog> Tourlogs { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
