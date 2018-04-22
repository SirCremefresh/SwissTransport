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
        /*swiss transport api*/
        private Transport transport = new Transport();

        /*list of best matching stations from input*/
        private Hints hints = new Hints();

        public Hints Hints
        {
            get { return hints; }
            set { hints = value; OnPropertyChanged("Hints"); }
        }

        /*selected station names*/
        private Selected selected = new Selected();

        public Selected Selected
        {
            get { return selected; }
            set { selected = value; OnPropertyChanged("Selected"); }
        }

        /*connections between from and to station*/
        private Connections connections = new Connections();

        public Connections Connections
        {
            get { return connections; }
            set { connections = value; OnPropertyChanged("Connections"); }
        }

        /*interface INotifyPropertyChanged*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /*get station hints from input with api*/
        public void getStationHints(string input)
        {
            Hints.Stations = transport.GetStations(input).StationList;
            OnPropertyChanged("Hints");
        }

        /*selected station from dropdown*/
        public void selectStation(bool from, string station)
        {
            if (from)
            {
                Selected.From = station;
            }
            else
            {
                Selected.To = station;
            }
            OnPropertyChanged("Selected");
        }

        /*get a list of connections between input stations*/
        public void getConnections()
        {
            if (Selected.From != null && selected.From != "" && Selected.To != null && selected.To != "")
            {
                Connections.List = transport.GetConnections(Selected.From, Selected.To).ConnectionList;
                OnPropertyChanged("Connections");
            }
        }

        /*selected a connection to get more details*/
        public void getConnectionDetails(Connection connection)
        {
            MessageBox.Show("From: " + connection.From.Station.Name + "\nDeparting at " + DateTime.Parse(connection.From.Departure) + " on rail " + connection.From.Platform + "\n\n" +
                "Travel Duration: " + connection.Duration + "\n\n" +
                "To: " + connection.To.Station.Name + "\nArrive at " + DateTime.Parse(connection.To.Arrival) + " on rail " + connection.To.Platform);
        }
    }
}
