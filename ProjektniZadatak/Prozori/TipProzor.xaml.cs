using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for TipProzor.xaml
    /// </summary>
    public partial class TipProzor : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static int brojacTip = 0;

        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public static ObservableCollection<Model.Tip> Tipovi
        {
            get;
            set;
        }

        private Model.Tip _stip;

        public Model.Tip STip
        {
            get { return _stip; }
            set { _stip = value; }
        }

        public TipProzor()
        {
            InitializeComponent();

            this.DataContext = this;

            if (brojacTip==0)
            {
                Tipovi = new ObservableCollection<Model.Tip>();

                Tipovi.Add(new Model.Tip { Id = "1", Ime = "Ptice", Opis = "Pernate zivotinje" });
                Tipovi.Add(new Model.Tip { Id = "2", Ime = "Kopnene", Opis = "Zive na kopnu" });
                Tipovi.Add(new Model.Tip { Id = "3", Ime = "Vodene", Opis = "Zive u vodi" });
            }
            
        }

        private void Dodaj_Tip(object sender, RoutedEventArgs e)
        {
            if (!idTipa.Equals("") && !imeTipa.Equals("") && !opisTipa.Equals(""))
            {
                Tipovi.Add(new Model.Tip { Id = idTipa.Text, Ime = imeTipa.Text, Opis = opisTipa.Text });
                // POVEZI XAML SA LISTOM !!!
                this.Hide();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Ikonica.Source = new BitmapImage(new Uri(op.FileName));
                rctSlika.Visibility = Visibility.Hidden;
            }
        }
    }
}
