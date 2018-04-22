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
using SwissTransport;

namespace SwissTransportView
{
    public partial class SwissTransportWindow : Window
    {
        /*logic in modelPage*/
        ModelPage modelPage = new ModelPage();

        public SwissTransportWindow()
        {
            InitializeComponent();
            this.DataContext = modelPage;
            swapButtons(false, true);
            modelPage.CurrentPage = new StationPage();
        }

        /*change to stations and connections page*/
        private void getBoard(object sender, RoutedEventArgs e)
        {
            swapButtons(false, true);
            modelPage.CurrentPage = new StationPage();
        }

        /*change to board with all departing trains page*/
        private void getStations(object sender, RoutedEventArgs e)
        {
            swapButtons(true, false);
            modelPage.CurrentPage = new BoardPage();
        }

        /*enable and disable page buttons*/
        private void swapButtons(bool station, bool board)
        {
            btnStationPage.IsEnabled = station;
            btnBoardPage.IsEnabled = board;
        }
    }
}
