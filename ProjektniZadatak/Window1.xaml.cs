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

namespace ProjektniZadatak
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Species species = new Species();
            Species.brojac++;
            species.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Map map = new Map();
            map.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void Hover(object sender, MouseEventArgs e)
        {
            //btnAS.Background.Opacity = 100;
        }

        private void Hover_Exit(object sender, MouseEventArgs e)
        {
            //btnAS.Background.Opacity = 50;
        }

        private void Hover1(object sender, MouseEventArgs e)
        {
            //btnAS.Background.Opacity = 100;
        }
    }

}
