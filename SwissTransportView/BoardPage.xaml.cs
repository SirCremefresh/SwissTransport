using SwissTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwissTransportView
{
    public partial class BoardPage : Page
    {
        /*logic in modelView*/
        ModelView modelView = new ModelView();

        public BoardPage()
        {
            InitializeComponent();
            this.DataContext = modelView;
        }

        /*on station input changes*/
        private void stationInput(object sender, TextChangedEventArgs e)
        {
            ComboBox cmbx = sender as ComboBox;

            if (cmbx.Text != null && cmbx.Text != "")
            {
                modelView.getStationHints(cmbx.Text);
            }

            if (cmbx.Text == null || cmbx.Text == "" || modelView.Hints.Stations.Count <= 0)
            {
                cmbx.IsDropDownOpen = false;
            }
        }

        /*open dropdown on focus*/
        private void previewInput(object sender, TextCompositionEventArgs e)
        {
            ComboBox cmbx = sender as ComboBox;
            cmbx.IsDropDownOpen = true;
        }

        /*selected station from hints*/
        private void selectStation(object sender, SelectionChangedEventArgs args)
        {
            Station selectedStation = (sender as ComboBox).SelectedItem as Station;

            if (selectedStation != null && selectedStation.Name != "")
            {
                modelView.selectStation(true, selectedStation.Name);
            }
        }

        /*search for connections between from and to station*/
        private void getBoard(object sender, RoutedEventArgs e)
        {
            modelView.getBoard();
        }
    }
}
