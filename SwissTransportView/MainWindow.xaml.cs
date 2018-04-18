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
    public partial class MainWindow : Window
    {
        ModelView modelView = new ModelView();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = modelView;
        }

        private void inputChange(object sender, TextChangedEventArgs e)
        {
            ComboBox cmbx = sender as ComboBox;

            modelView.search(cmbx == cmbxFrom ? true : false, cmbx.Text);

            if (cmbx.Text == null || cmbx.Text == "")
            {
                cmbx.IsDropDownOpen = false;
            }
        }

        private void ComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ComboBox cmbx = sender as ComboBox;
            cmbx.IsDropDownOpen = true;
        }
    }
}
