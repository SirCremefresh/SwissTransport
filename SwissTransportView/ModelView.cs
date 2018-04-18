using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SwissTransport;

namespace SwissTransportView
{
    class ModelView : INotifyPropertyChanged
    {
        private Transport transport = new Transport();

        public Hints hints = new Hints();

        public Hints Hints
        {
            get { return hints; }
            set { hints = value; OnPropertyChanged("Hints"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ModelView()
        {

        }

        public void search(Boolean from, string input)
        {
            if (from)
            {
                Hints.From = transport.GetStations(input).StationList;
            }

            else
            {
                Hints.To = transport.GetStations(input).StationList;
            }

            OnPropertyChanged("Hints");
        }
    }
}
