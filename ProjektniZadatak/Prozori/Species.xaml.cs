using Microsoft.Win32;
using ProjektniZadatak.Model;
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
    /// Interaction logic for Species.xaml
    /// </summary>
    public partial class Species : Window, INotifyPropertyChanged //INOTIFY i click metoda  i LISTA
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static int brojac=0;

        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public static ObservableCollection<Animal> Animals
        {
            get;
            set;
        }

        public static ObservableCollection<Model.Tip> Tipovi
        {
            get;
            set;
        }

        public static ObservableCollection<Model.Etiketa> Etikete
        {
            get;
            set;
        }


        public Species()
        {
            InitializeComponent();

            RightRectangle.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Hidden;
            PanelTip.Visibility = Visibility.Hidden;

            this.DataContext = this;
            
            if (brojac==0)
            {
                Animals = new ObservableCollection<Animal>();
                //Tip tipziv = Tip;
                Animal prva = new Animal {
                    Id = 1, Ime = "Prva",
                    Opis = "Opis1",
                    StUgr = Animal.StatusUgrozenosti.KriticnoUgrozena,
                    StTur = Animal.TuristickiStatus.DelimicnoHabituirana,
                    Opasna = false,
                    NaseljeniRegion = true,
                    CrvenaLista = false,
                    GodisnjiPrihod = 123.43,
                    // TipZiv = tipziv
                }; 
                Animals.Add(prva);

                Tipovi = new ObservableCollection<Model.Tip>();
                Etikete = new ObservableCollection<Model.Etiketa>();

                Tipovi.Add(new Model.Tip { Id = "1", Ime = "Ptice", Opis = "Pernate zivotinje" });
                Tipovi.Add(new Model.Tip { Id = "2", Ime = "Kopnene", Opis = "Zive na kopnu" });
                Tipovi.Add(new Model.Tip { Id = "3", Ime = "Vodene", Opis = "Zive u vodi" });

                Etikete.Add(new Model.Etiketa { Id = 1, Opis = "Pernate zivotinje" });
                Etikete.Add(new Model.Etiketa { Id = 2, Opis = "Zive na kopnu" });
                Etikete.Add(new Model.Etiketa { Id = 3, Opis = "Zive u vodi" });

                TipZivotinje.ItemsSource = Tipovi;
                TipZivotinje.SelectedIndex = 0;
                EtiketeZivotinje.ItemsSource = Etikete;
                //EtiketeZivotinje.SelectedIndex = 0;
            }

            zivotinje.ItemsSource = Animals;
          
        }
        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
            PanelTip.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Hidden;
            RightRectangle.Visibility = Visibility.Visible;
            btnDodajUListu.Visibility = Visibility.Visible;
            btnAzurirajListu.Visibility = Visibility.Hidden;

            ImeZivotinje.Text = "";
            OpisZivotinje.Text = "";
            StUgrZivotinje.SelectedItem = null;
            StTurZivotinje.SelectedItem = null;
            cbOpasna.IsChecked = false;
            cbNaseljeniRegion.IsChecked = false;
            cbCrvenaLista.IsChecked = false;
            pickDatum.SelectedDate = null;

            ImeZivotinje.Focus();
        }

        private void Dodavanje_Zivotinje(object sender, RoutedEventArgs e)
        {
            if (ImeZivotinje.Text != "" && OpisZivotinje.Text!="" && StTurZivotinje.Text !="" && StUgrZivotinje.Text!="")
            {
                //btnDodajUListu.IsEnabled = true;
                Animal.TuristickiStatus st1 = (Animal.TuristickiStatus)Enum.Parse(typeof(Animal.TuristickiStatus), StTurZivotinje.Text);
                Animal.StatusUgrozenosti st2 = (Animal.StatusUgrozenosti)Enum.Parse(typeof(Animal.StatusUgrozenosti), StUgrZivotinje.Text);
                
                Uri myUri = new Uri(SlikaZivotinje.Source.ToString(), UriKind.RelativeOrAbsolute);
                BitmapDecoder decoder = BitmapDecoder.Create(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource = decoder.Frames[0];

                Animals.Add(new Animal {
                    Id = 3,
                    Ime = ImeZivotinje.Text,
                    Opis = OpisZivotinje.Text,
                    StUgr = st2,
                    StTur = st1,
                    Opasna = (bool)cbOpasna.IsChecked,
                    NaseljeniRegion = (bool)cbNaseljeniRegion.IsChecked,
                    CrvenaLista = (bool)cbCrvenaLista.IsChecked,
                    GodisnjiPrihod = 123.43,
                    Datum = (DateTime)pickDatum.SelectedDate,
                    Image = bitmapSource
                });
               
                RightRectangle.Visibility = Visibility.Hidden;
            }
           
        }

        private void Azuriranje_Zivotinje(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Image(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {               
                SlikaZivotinje.Source = new BitmapImage(new Uri(op.FileName));
                rctSlika.Visibility = Visibility.Hidden;
            }

        }

        private void Dodaj_Ikonicu(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Ikonica.Source = new BitmapImage(new Uri(op.FileName));
                rctSlikaa.Visibility = Visibility.Hidden;
            }

        }

        private void Nova_Etiketa(object sender, RoutedEventArgs e)
        {
            RightRectangle.Visibility = Visibility.Hidden;
            PanelTip.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Visible;
            //Prozori.EtiketaProzor et = new Prozori.EtiketaProzor();
            Prozori.EtiketaProzor.brojacEtikete++;
            //et.ShowDialog();
        }

        private void Novi_Tip(object sender, RoutedEventArgs e)
        {
            //TipProzor t = new TipProzor();
            RightRectangle.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Hidden;
            PanelTip.Visibility = Visibility.Visible;
            
            TipProzor.brojacTip++;
            //t.ShowDialog();
        }

        

        private void Selekcija_Liste(object sender, SelectionChangedEventArgs e)
        {
            Animal animal = (Animal)zivotinje.SelectedItems[0];
            ImeZivotinje.Text = animal.Ime;
            OpisZivotinje.Text = animal.Opis;
            StUgrZivotinje.SelectedItem = animal.StUgr;
            StTurZivotinje.SelectedItem = animal.StTur;
            cbOpasna.IsChecked = animal.Opasna;
            cbNaseljeniRegion.IsChecked = animal.NaseljeniRegion;
            cbCrvenaLista.IsChecked = animal.CrvenaLista;
            pickDatum.SelectedDate = animal.Datum;

            btnDodajUListu.Visibility = Visibility.Hidden;
            btnAzurirajListu.Visibility = Visibility.Visible;
            RightRectangle.Visibility = Visibility.Visible;
        }

        private void Dodaj_Etiketu(object sender, RoutedEventArgs e)
        {
            if (!idEtiketa.Equals("") && !opisEtiketa.Equals(""))
            {
                Etikete.Add(new Model.Etiketa { Id = double.Parse(idEtiketa.Text), Opis = opisEtiketa.Text});
                TipZivotinje.ItemsSource = Tipovi;
                idEtiketa.Text = "";
                opisEtiketa.Text = "";
                
                EtiketaPanel.Visibility = Visibility.Hidden;
            }
        }

        private void Dodaj_Tip(object sender, RoutedEventArgs e)
        {
            Uri myUri = new Uri(Ikonica.Source.ToString(), UriKind.RelativeOrAbsolute);
            BitmapDecoder decoder = BitmapDecoder.Create(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];

            if (!idTipa.Equals("") && !imeTipa.Equals("") && !opisTipa.Equals(""))
            {
                Tipovi.Add(new Model.Tip { Id = idTipa.Text, Ime = imeTipa.Text, Opis = opisTipa.Text, Image = bitmapSource });
                TipZivotinje.ItemsSource = Tipovi;
                idTipa.Text = "";
                imeTipa.Text = "";
                opisTipa.Text = "";
                PanelTip.Visibility = Visibility.Hidden;
            }
        }
        
    }
}
