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

        /*connections between from and to station*/
        private Board board = new Board();

        public Board Board
        {
            get { return board; }
            set { board = value; OnPropertyChanged("Board"); }
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
            List<Connection> connections = null;

            try
            {
                /*best matching stations*/
                List<Station> from = transport.GetStations(Selected.From).StationList;
                if(from == null || from.Count <= 0)
                {
                    MessageBox.Show("From station not found");
                    return;
                }
                else
                {
                    Selected.From = from[0].Name;
                    OnPropertyChanged("Selected");
                }

                List<Station> to = transport.GetStations(Selected.To).StationList;
                if (to == null || to.Count <= 0)
                {
                    MessageBox.Show("To station not found");
                    return;
                }
                else
                {
                    Selected.To = to[0].Name;
                    OnPropertyChanged("Selected");
                }

                connections = transport.GetConnections(Selected.From, Selected.To).ConnectionList;
            }
            catch (Exception e)
            {
                MessageBox.Show("Stations not found");
            }

            if (connections != null && connections.Count > 0)
            {
                try
                {
                    Connections.List = connections;
                    OnPropertyChanged("Connections");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at getting connections occured: " + e.ToString());
                }
            }
        }

        /*selected a connection to get more details*/
        public void getConnectionDetails(Connection connection)
        {
            MessageBox.Show("From: " + connection.From.Station.Name + "\nDeparting at " + DateTime.Parse(connection.From.Departure) + " on rail " + connection.From.Platform + "\n\n" +
                "Travel Duration: " + connection.Duration + "\n\n" +
                "To: " + connection.To.Station.Name + "\nArrive at " + DateTime.Parse(connection.To.Arrival) + " on rail " + connection.To.Platform);
        }

        /*get a list of connections going from one station*/
        public void getBoard()
        {
            List<Station> stations = null;

            try
            {
                stations = transport.GetStations(Selected.From).StationList;
            }
            catch (Exception e)
            {
                MessageBox.Show("Station not found");
            }

            if (stations != null && stations.Count > 0)
            {
                Station station = transport.GetStations(Selected.From).StationList[0];
                Selected.From = station.Name;
                OnPropertyChanged("Selected");

                try
                {
                    Board.List = transport.GetStationBoard(station.Name, station.Id).Entries;
                    OnPropertyChanged("Board");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at getting Board occured: " + e.ToString());
                }
            }
        }
    }
}
