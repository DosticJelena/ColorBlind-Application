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
        private int animalIndex;

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

        public ObservableCollection<Model.Tip> Tipovi
        {
            get;
            set;
        }

        public ObservableCollection<Model.Etiketa> Etikete
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
                Tipovi = new ObservableCollection<Model.Tip>();
                Etikete = new ObservableCollection<Model.Etiketa>();

                Tipovi.Add(new Model.Tip { Id = "1", Ime = "Ptice", Opis = "Pernate zivotinje" });
                Tipovi.Add(new Model.Tip { Id = "2", Ime = "Kopnene", Opis = "Zive na kopnu" });
                Tipovi.Add(new Model.Tip { Id = "3", Ime = "Vodene", Opis = "Zive u vodi" });

                Etikete.Add(new Model.Etiketa { Id = 1, Opis = "1" });
                Etikete.Add(new Model.Etiketa { Id = 2, Opis = "2" });
                Etikete.Add(new Model.Etiketa { Id = 3, Opis = "3" });


                Animal prva = new Animal
                {
                    Id = "1",
                    Ime = "Prva",
                    Opis = "Opis1",
                    StUgr = Animal.StatusUgrozenosti.KriticnoUgrozena,
                    StTur = Animal.TuristickiStatus.DelimicnoHabituirana,
                    Opasna = false,
                    NaseljeniRegion = true,
                    CrvenaLista = false,
                    GodisnjiPrihod = "123.43",
                    TipZiv = Tipovi[0],
                    Image = new BitmapImage(new Uri("C:\\Users\\jelen\\Pictures\\Projekat\\fish.jpg")),
                    Datum = new DateTime(2018, 6, 7)
            };
                Animal druga = new Animal
                {
                    Id = "2",
                    Ime = "Druga",
                    Opis = "Opis2",
                    StUgr = Animal.StatusUgrozenosti.Ranjiva,
                    StTur = Animal.TuristickiStatus.Habituirana,
                    Opasna = true,
                    NaseljeniRegion = true,
                    CrvenaLista = false,
                    GodisnjiPrihod = "2323.51",
                    TipZiv = Tipovi[2],
                    Image = new BitmapImage(new Uri("C:\\Users\\jelen\\Pictures\\Projekat\\land.jpg")),
                    Datum = new DateTime(2018, 6, 5)
                };

                Animals.Add(prva);
                Animals.Add(druga);

                TipZivotinje.ItemsSource = Tipovi;
                //TipZivotinje.SelectedIndex = 0;
                EtiketeZivotinje.ItemsSource = Etikete;
                //EtiketeZivotinje.SelectedIndex = 0;

                zivotinje.ItemsSource = Animals;
                etikete.ItemsSource = Etikete;
                etikete.Visibility = Visibility.Hidden;
                tipovi.ItemsSource = Tipovi;
                tipovi.Visibility = Visibility.Hidden;
            }

            EtiketeZivotinje.ItemsSource = Etikete;
            TipZivotinje.ItemsSource = Tipovi;
            zivotinje.ItemsSource = Animals;
            etikete.ItemsSource = Etikete;
            etikete.Visibility = Visibility.Hidden;
            tipovi.ItemsSource = Tipovi;
            tipovi.Visibility = Visibility.Hidden;

        }
        
        // Dugme za prikaz panela za dodavanje zivotinje
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
            PanelTip.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Hidden;
            RightRectangle.Visibility = Visibility.Visible;
            btnDodajUListu.Visibility = Visibility.Visible;
            btnAzurirajListu.Visibility = Visibility.Hidden;
            btnObrisi.Visibility = Visibility.Hidden;

            IdZivotinje.Text = "";
            IdZivotinje.IsEnabled = true;
            ImeZivotinje.Text = "";
            OpisZivotinje.Text = "";
            StUgrZivotinje.SelectedItem = null;
            StTurZivotinje.SelectedItem = null;
            cbOpasna.IsChecked = false;
            cbNaseljeniRegion.IsChecked = false;
            cbCrvenaLista.IsChecked = false;
            pickDatum.SelectedDate = null;
            SlikaZivotinje.Source = null;
            rctSlika.Visibility = Visibility.Visible;
            godPrihod.Text = "";
            EtiketeZivotinje.SelectedItem = null;
            TipZivotinje.SelectedItem = null;

            IdZivotinje.Focus();

            nazivListe.Content = "Lista Zivotinja";
            //zivotinje.SelectedValue = null;
            zivotinje.Visibility = Visibility.Visible;
            tipovi.Visibility = Visibility.Hidden;
            etikete.Visibility = Visibility.Hidden;
        }


        // Dugmici za dodavanje, azuriranje i brisanje zivotinje iz liste
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
                    Id = IdZivotinje.Text,
                    Ime = ImeZivotinje.Text,
                    Opis = OpisZivotinje.Text,
                    StUgr = st2,
                    StTur = st1,
                    Opasna = (bool)cbOpasna.IsChecked,
                    NaseljeniRegion = (bool)cbNaseljeniRegion.IsChecked,
                    CrvenaLista = (bool)cbCrvenaLista.IsChecked,
                    GodisnjiPrihod = godPrihod.Text,
                    Datum = (DateTime)pickDatum.SelectedDate,
                    Image = bitmapSource,
                    TipZiv = (Tip)TipZivotinje.SelectedItem
                });
               
                RightRectangle.Visibility = Visibility.Hidden;

                
            }
           
        }

        private void Azuriranje_Zivotinje(object sender, RoutedEventArgs e)
        { 
            if(Animals.Any(x => x.Id == IdZivotinje.Text))
            {
                List<Animal> animalList = Animals.ToList<Animal>();
                Animal animal = animalList.Find(x => x.Id == IdZivotinje.Text);
                int pozicija = Animals.IndexOf(animal);
                animal = Animals.ElementAt(pozicija);

                Animal.TuristickiStatus st1 = (Animal.TuristickiStatus)Enum.Parse(typeof(Animal.TuristickiStatus), StTurZivotinje.Text);
                Animal.StatusUgrozenosti st2 = (Animal.StatusUgrozenosti)Enum.Parse(typeof(Animal.StatusUgrozenosti), StUgrZivotinje.Text);

                Uri myUri = new Uri(SlikaZivotinje.Source.ToString(), UriKind.RelativeOrAbsolute);
                BitmapDecoder decoder = BitmapDecoder.Create(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource = decoder.Frames[0];

                animal.Ime = ImeZivotinje.Text;
                animal.Opis = OpisZivotinje.Text;
                animal.StUgr = st2;
                animal.StTur = st1;
                animal.Opasna = (bool)cbOpasna.IsChecked;
                animal.NaseljeniRegion = (bool)cbNaseljeniRegion.IsChecked;
                animal.CrvenaLista = (bool)cbCrvenaLista.IsChecked;
                animal.GodisnjiPrihod = godPrihod.Text;
                animal.Datum = (DateTime)pickDatum.SelectedDate;
                animal.Image = bitmapSource;
                animal.TipZiv = (Tip)TipZivotinje.SelectedItem;

                //zivotinje.SelectedIndex = -1;

                RightRectangle.Visibility = Visibility.Hidden;
                
            }
        }

        private void Brisanje_Zivotinje(object sender, RoutedEventArgs e)
        {
            

            if (Animals.Any(x => x.Id == IdZivotinje.Text))
            {
                List<Animal> animalList = Animals.ToList<Animal>();
                Animal nadjena = animalList.Find(x => x.Id == IdZivotinje.Text);
                zivotinje.UnselectAll();
                Animals.Remove(nadjena);
            }
        }


        // Dugmici za dodavanje slike zivotinje i ikonice tipa
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


        //Dugmici za otvaranje panela za dodavanje etikete i tipa
        private void Nova_Etiketa(object sender, RoutedEventArgs e)
        {
            RightRectangle.Visibility = Visibility.Hidden;
            PanelTip.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Visible;

            idEtiketa.Text = "";
            idEtiketa.IsEnabled = true;
            opisEtiketa.Text = "";
            cbBoja.SelectedColor = null;

            idEtiketa.Focus();

            Prozori.EtiketaProzor.brojacEtikete++;
            nazivListe.Content = "Lista Etiketa";
            zivotinje.Visibility = Visibility.Hidden;
            tipovi.Visibility = Visibility.Hidden;
            etikete.Visibility = Visibility.Visible;
        }

        private void Novi_Tip(object sender, RoutedEventArgs e)
        {
            RightRectangle.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Hidden;
            PanelTip.Visibility = Visibility.Visible;

            rctSlikaa.Visibility = Visibility.Visible;
            idTipa.Text = "";
            idTipa.IsEnabled = true;
            imeTipa.Text = "";
            opisTipa.Text = "";
            Ikonica.Source = null;

            idTipa.Focus();

            nazivListe.Content = "Lista Tipova";
            zivotinje.Visibility = Visibility.Hidden;
            tipovi.Visibility = Visibility.Visible;
            etikete.Visibility = Visibility.Hidden;
            TipProzor.brojacTip++;
        }


        // Selektovani element liste
        private void Selekcija_Liste(object sender, SelectionChangedEventArgs e)
        {
            if (Animals.Count > 0)
            {
                Animal animal = new Animal();
                if (zivotinje.SelectedItems.Count > 0)
                {
                    animal = (Animal)zivotinje.SelectedItems[0];
                }
                else
                {
                    //zivotinje.SelectAll();
                    zivotinje.SelectedIndex = 0;
                    animal = (Animal)zivotinje.SelectedItems[0];
                }

                animalIndex = zivotinje.SelectedIndex;
                IdZivotinje.Text = animal.Id;
                IdZivotinje.IsEnabled = false;
                ImeZivotinje.Text = animal.Ime;
                OpisZivotinje.Text = animal.Opis;
                StUgrZivotinje.Text = animal.StUgr.ToString();
                StTurZivotinje.Text = animal.StTur.ToString();
                cbOpasna.IsChecked = animal.Opasna;
                cbNaseljeniRegion.IsChecked = animal.NaseljeniRegion;
                cbCrvenaLista.IsChecked = animal.CrvenaLista;
                pickDatum.SelectedDate = animal.Datum;
                SlikaZivotinje.Source = animal.Image;
                godPrihod.Text = animal.GodisnjiPrihod;
                TipZivotinje.SelectedItem = animal.TipZiv;

                rctSlika.Visibility = Visibility.Hidden;
                btnDodajUListu.Visibility = Visibility.Hidden;
                btnAzurirajListu.Visibility = Visibility.Visible;
                btnObrisi.Visibility = Visibility.Visible;
                RightRectangle.Visibility = Visibility.Visible;
                PanelTip.Visibility = Visibility.Hidden;
                EtiketaPanel.Visibility = Visibility.Hidden;
            } 
            else
            {
                RightRectangle.Visibility = Visibility.Hidden;
            }

            //zivotinje.UnselectAll();
        }

        private void Selekcija_Liste_Etikete(object sender, SelectionChangedEventArgs e)
        {
            Model.Etiketa et = (Model.Etiketa)etikete.SelectedItems[0];
            idEtiketa.Text = et.Id.ToString();
            idEtiketa.IsEnabled = false;
            opisEtiketa.Text = et.Opis.ToString();
        }

        private void Selekcija_Liste_Tipovi(object sender, SelectionChangedEventArgs e)
        {
            Model.Tip t = (Model.Tip)tipovi.SelectedItems[0];
            idTipa.Text = t.Id.ToString();
            idTipa.IsEnabled = false;
            imeTipa.Text = t.Ime.ToString();
            opisTipa.Text = t.Opis.ToString();
        }


        // Dugmici za dodavanje etikete i tipa u listu etiketa i listu tipova
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


        // Uredjivanje dugmica pri prelazu misa
        private void HoverZ(object sender, MouseEventArgs e)
        {
            btnZ.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void HoverZLeave(object sender, MouseEventArgs e)
        {
            btnZ.Foreground = new SolidColorBrush(Colors.White);
        }

        private void HoverT(object sender, MouseEventArgs e)
        {
            btnT.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void HoverTLeave(object sender, MouseEventArgs e)
        {
            btnT.Foreground = new SolidColorBrush(Colors.White);
        }

        private void HoverE(object sender, MouseEventArgs e)
        {
            btnE.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void HoverELeave(object sender, MouseEventArgs e)
        {
            btnE.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
