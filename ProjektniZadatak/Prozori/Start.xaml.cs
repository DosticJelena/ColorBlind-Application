using ProjektniZadatak.Properties;
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
using System.Windows.Shapes;

namespace ProjektniZadatak.Prozori
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            //Load w = new Load();
            ((Button)sender).Cursor = Cursors.Wait;
            w.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void Tutorial(object sender, RoutedEventArgs e)
        {
            Tutorial t = new Tutorial();
            t.Show();
            //this.Visibility = Visibility.Hidden;
        }

    }
}
