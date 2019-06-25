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
using ProjektniZadatak.Validation;

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
        private Window1 win1;
        

        private int z_id;
        public int Z_Id
        {
            get
            {
                return z_id;
            }
            set
            {
                if (value != z_id)
                {
                    z_id = value;
                    OnPropertyChanged("Z_Id");
                }
            }
        }

        private string z_ime;
        public string Z_Ime
        {
            get
            {
                return z_ime;
            }
            set
            {
                if (value != z_ime)
                {
                    z_ime = value;
                    OnPropertyChanged("Z_Ime");
                }
            }
        }

        private int e_id;
        public int E_Id
        {
            get
            {
                return e_id;
            }
            set
            {
                if (value != e_id)
                {
                    e_id = value;
                    OnPropertyChanged("E_Id");
                }
            }
        }
        
        private int t_id;
        public int T_Id
        {
            get
            {
                return t_id;
            }
            set
            {
                if (value != t_id)
                {
                    t_id = value;
                    OnPropertyChanged("T_Id");
                }
            }
        }

        private string t_ime;
        public string T_Ime
        {
            get
            {
                return t_ime;
            }
            set
            {
                if (value != t_ime)
                {
                    t_ime = value;
                    OnPropertyChanged("T_Ime");
                }
            }
        }

        private double z_cena;
        public double Z_Cena
        {
            get
            {
                return z_cena;
            }
            set
            {
                if (value != z_cena)
                {
                    z_cena = value;
                    OnPropertyChanged("Z_Cena");
                }
            }
        }

        private DateTime z_datum;
        public DateTime Z_Datum
        {
            get
            {
                return z_datum;
            }
            set
            {
                if (value != z_datum)
                {
                    z_datum = value;
                    OnPropertyChanged("Z_Datum");
                }
            }
        }

        ObservableCollection<Etiketa> Etikete;
        ObservableCollection<Tip> Tipovi;
        ObservableCollection<Animal> Animals;

        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        
        public Species(ObservableCollection<Etiketa> e, ObservableCollection<Tip> t, ObservableCollection<Animal> a,Window1 w)
        {
            InitializeComponent();

            this.Animals = a;
            this.Etikete = e;
            this.Tipovi = t;
            this.win1 = w;

            RightRectangle.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Hidden;
            PanelTip.Visibility = Visibility.Hidden;

            this.DataContext = this;
            
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
            EtiketeZivotinje.SelectedItem = null;
            EtiketeZivotinje.Text = "";
            IdZivotinje.Focus();
            nazivListe.Content = "Lista Zivotinja";
            visibility_settings((Button)sender);
            
        }


        // Dugmici za dodavanje, azuriranje i brisanje zivotinje iz liste
        private void Dodavanje_Zivotinje(object sender, RoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(godPrihod.Text, "[^0-9]") || System.Text.RegularExpressions.Regex.IsMatch(IdZivotinje.Text, "[^0-9]") || Animals.Any(x => x.Id == IdZivotinje.Text) || pickDatum.SelectedDate == null || TipZivotinje.SelectedItem == null|| StTurZivotinje.SelectedItem == null || StUgrZivotinje.SelectedItem == null
                || IdZivotinje.Text.Equals("") || ImeZivotinje.Text.Equals("") || godPrihod.Text.Equals(""))
            {
                lDatum.Foreground = new SolidColorBrush(Colors.White);
                lDatum.Content = " Datum: ";
                lTip.Foreground = new SolidColorBrush(Colors.White);
                lTip.Content = " Tip: ";
                lStTur.Foreground = new SolidColorBrush(Colors.White);
                lStTur.Content = "Turistički Status: ";
                lStUgr.Foreground = new SolidColorBrush(Colors.White);
                lStUgr.Content = "Status Ugroženosti:";
                lId.Foreground = new SolidColorBrush(Colors.White);
                lId.Content = "Id: ";
                lIme.Foreground = new SolidColorBrush(Colors.White);
                lIme.Content = " Ime: ";
                lGodPrihod.Foreground = new SolidColorBrush(Colors.White);
                lGodPrihod.Content = "Godišnji prihod: ";

                if (pickDatum.SelectedDate == null)
                {
                    lDatum.Foreground = new SolidColorBrush(Colors.Red);
                    lDatum.Content = " >>> Datum: ";
                }

                if (TipZivotinje.SelectedItem == null)
                {
                    lTip.Foreground = new SolidColorBrush(Colors.Red);
                    lTip.Content = " >>> Tip: ";
                }

                if (StTurZivotinje.SelectedItem == null)
                {
                    lStTur.Foreground = new SolidColorBrush(Colors.Red);
                    lStTur.Content = ">>T. Status: ";

                }

                if (StUgrZivotinje.SelectedItem == null)
                {
                    lStUgr.Foreground = new SolidColorBrush(Colors.Red);
                    lStUgr.Content = ">> Ugroženost: ";
                }

                if (IdZivotinje.Text.Equals(""))
                {
                    lId.Foreground = new SolidColorBrush(Colors.Red);
                    lId.Content = " >>> Id: ";
                }

                if (ImeZivotinje.Text.Equals(""))
                {
                    lIme.Foreground = new SolidColorBrush(Colors.Red);
                    lIme.Content = " >>> Ime: ";
                }

                if (godPrihod.Text.Equals("") || System.Text.RegularExpressions.Regex.IsMatch(godPrihod.Text, "[^0-9]"))
                {
                    lGodPrihod.Foreground = new SolidColorBrush(Colors.Red);
                    lGodPrihod.Content = ">> Godišnji prihod: ";
                }

                if (Animals.Any(x => x.Id == IdZivotinje.Text))
                {
                    lId.Foreground = new SolidColorBrush(Colors.Red);
                    lId.Content = ">>> Id već postoji: ";
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(IdZivotinje.Text, "[^0-9]"))
                {
                    lId.Foreground = new SolidColorBrush(Colors.Red);
                    lId.Content = " >>> Id: ";
                }

                return;
            }


            lDatum.Foreground = new SolidColorBrush(Colors.White);
            lDatum.Content = " Datum: ";
            lTip.Foreground = new SolidColorBrush(Colors.White);
            lTip.Content = " Tip: ";
            lStTur.Foreground = new SolidColorBrush(Colors.White);
            lStTur.Content = "Turistički Status: ";
            lStUgr.Foreground = new SolidColorBrush(Colors.White);
            lStUgr.Content = "Status Ugroženosti:";
            lId.Foreground = new SolidColorBrush(Colors.White);
            lId.Content = "Id: ";
            lIme.Foreground = new SolidColorBrush(Colors.White);
            lIme.Content = " Ime: ";
            lGodPrihod.Foreground = new SolidColorBrush(Colors.White);
            lGodPrihod.Content = "Godišnji prihod: ";

            Animal.TuristickiStatus st1 = (Animal.TuristickiStatus)Enum.Parse(typeof(Animal.TuristickiStatus), StTurZivotinje.Text);
                Animal.StatusUgrozenosti st2 = (Animal.StatusUgrozenosti)Enum.Parse(typeof(Animal.StatusUgrozenosti), StUgrZivotinje.Text);

                BitmapSource bitmapSource;

                if (SlikaZivotinje.Source != null)
                {
                    Uri myUri = new Uri(SlikaZivotinje.Source.ToString(), UriKind.RelativeOrAbsolute);
                    BitmapDecoder decoder = BitmapDecoder.Create(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    bitmapSource = decoder.Frames[0];
                }
                else
                {
                    Tip t = (Tip)TipZivotinje.SelectedItem;
                    bitmapSource = (BitmapSource)t.Image;
                }

                

                List<Etiketa> lista = new List<Etiketa>();
                for (int i = 0; i < EtiketeZivotinje.SelectedItems.Count; i++)
                {
                    lista.Add((Etiketa)EtiketeZivotinje.SelectedItems[i]);
                }


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
                TipZiv = (Tip)TipZivotinje.SelectedItem,
                EtiketeZiv = lista,
                locationX = "-",
                locationY = "-"
                });
               
                RightRectangle.Visibility = Visibility.Hidden;
            
        }

        private void Azuriranje_Zivotinje(object sender, RoutedEventArgs e)
        {
            if (pickDatum.SelectedDate == null || TipZivotinje.SelectedItem == null || StTurZivotinje.SelectedItem == null || StUgrZivotinje == null)
            {
                return;
            }

            if (Animals.Any(x => x.Id == IdZivotinje.Text))
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

                List<Etiketa> lista = new List<Etiketa>();
                for (int i = 0; i < EtiketeZivotinje.SelectedItems.Count; i++)
                {
                    lista.Add((Etiketa)EtiketeZivotinje.SelectedItems[i]);
                }

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
                animal.TipZiv = (Tip)TipZivotinje.SelectedValue;
                animal.EtiketeZiv = lista;

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
            
            idEtiketa.Text = "";
            idEtiketa.IsEnabled = true;
            opisEtiketa.Text = "";
            cbBoja.SelectedColor = null;
            idEtiketa.Focus();
            nazivListe.Content = "Lista Etiketa";
            visibility_settings((Button)sender);
        }

        private void Novi_Tip(object sender, RoutedEventArgs e)
        {
            
            idTipa.Text = "";
            idTipa.IsEnabled = true;
            imeTipa.Text = "";
            opisTipa.Text = "";
            Ikonica.Source = null;
            idTipa.Focus();
            nazivListe.Content = "Lista Tipova";
            visibility_settings((Button)sender);
            
        }


        // Selektovani element liste
        private void Selekcija_Liste(object sender, SelectionChangedEventArgs e)
        {
            lDatum.Foreground = new SolidColorBrush(Colors.White);
            lTip.Foreground = new SolidColorBrush(Colors.White);
            lStTur.Foreground = new SolidColorBrush(Colors.White);
            lStUgr.Foreground = new SolidColorBrush(Colors.White);
            lId.Foreground = new SolidColorBrush(Colors.White);
            lIme.Foreground = new SolidColorBrush(Colors.White);
            lGodPrihod.Foreground = new SolidColorBrush(Colors.White);

            visibility_settings_list((ListView)sender);
            if (Animals.Count > 0)
            {
                Animal animal = new Animal();
                if (zivotinje.SelectedItems.Count > 0)
                {
                    animal = (Animal)zivotinje.SelectedItems[0];
                }
                else
                {
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

                int index = -1;
                foreach (Tip t in Tipovi)
                {
                    index++;
                    if (t.Id == animal.TipZiv.Id)
                    {
                        break;
                    }
                }
                TipZivotinje.SelectedItem = Tipovi[index];
                TipZivotinje.SelectedValue = Tipovi[index];
                EtiketeZivotinje.SelectedItemsOverride = animal.EtiketeZiv;
                /*String etikete = animal.EtiketeZiv.ToString();
                for (int i = 0; i < animal.EtiketeZiv.Count; i++)
                {
                    EtiketeZivotinje.SelectedItem = animal.EtiketeZiv[i];
                }*/
            } 
            else
            {
                RightRectangle.Visibility = Visibility.Hidden;
            }
        }

        private void Selekcija_Liste_Etikete(object sender, SelectionChangedEventArgs e)
        {
            lIdE.Foreground = new SolidColorBrush(Colors.White);
            lOpisE.Foreground = new SolidColorBrush(Colors.White);
            lBoja.Foreground = new SolidColorBrush(Colors.White);

            if (Etikete.Count > 0)
            {
                Etiketa et = new Etiketa();
                if (etikete.SelectedIndex != -1)
                {
                    et = (Etiketa)etikete.SelectedItems[0];
                }
                else
                {
                    etikete.SelectedIndex = 0;
                    et = (Etiketa)etikete.SelectedItems[0];
                }
                
                idEtiketa.Text = et.Id.ToString();
                idEtiketa.IsEnabled = false;
                opisEtiketa.Text = et.Opis.ToString();
                cbBoja.SelectedColor = et.Boja;
                visibility_settings_list((ListView)sender);
            }
            else
            {
                EtiketaPanel.Visibility = Visibility.Hidden;
            }
            
        }

        private void Selekcija_Liste_Tipovi(object sender, SelectionChangedEventArgs e)
        {
            lab1.Foreground = new SolidColorBrush(Colors.White);
            lab2.Foreground = new SolidColorBrush(Colors.White);
            lab4.Foreground = new SolidColorBrush(Colors.White);

            if (Tipovi.Count > 0)
            {
                Tip t = new Tip();
                if (tipovi.SelectedIndex != -1)
                {
                    t = (Tip)tipovi.SelectedItems[0];
                }
                else
                {
                    tipovi.SelectedIndex = 0;
                    t = (Tip)tipovi.SelectedItems[0];
                }
                
                idTipa.Text = t.Id.ToString();
                idTipa.IsEnabled = false;
                imeTipa.Text = t.Ime.ToString();
                opisTipa.Text = t.Opis.ToString();
                Ikonica.Source = t.Image;
                visibility_settings_list((ListView)sender);
            }
            else
            {
                PanelTip.Visibility = Visibility.Hidden;
            }
            
        }


        // Dugmici za dodavanje etikete i tipa u listu etiketa i listu tipova
        private void Dodaj_Etiketu(object sender, RoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(idEtiketa.Text, "[^0-9]") || Etikete.Any(x => x.Id.ToString() == idEtiketa.Text) || idEtiketa.Text.Equals("") || opisEtiketa.Text.Equals("") || cbBoja.SelectedColor == null)
            {
                lIdE.Foreground = new SolidColorBrush(Colors.White);
                lIdE.Content = "Id: ";
                lOpisE.Foreground = new SolidColorBrush(Colors.White);
                lOpisE.Content = "Opis: ";
                lBoja.Foreground = new SolidColorBrush(Colors.White);
                lBoja.Content = "Boja: ";

                if (idEtiketa.Text.Equals(""))
                {
                    lIdE.Foreground = new SolidColorBrush(Colors.Red);
                    lIdE.Content = ">>> Id: ";
                }

                if (cbBoja.SelectedColor == null)
                {
                    lBoja.Foreground = new SolidColorBrush(Colors.Red);
                    lBoja.Content = ">>> Boja: ";
                }

                if (opisEtiketa.Text.Equals(""))
                {
                    lOpisE.Foreground = new SolidColorBrush(Colors.Red);
                    lOpisE.Content = ">>> Opis: ";
                }

                if (Etikete.Any(x => x.Id.ToString() == idEtiketa.Text))
                {
                    lIdE.Foreground = new SolidColorBrush(Colors.Red);
                    lIdE.Content = ">>> Id već postoji: ";
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(idEtiketa.Text, "[^0-9]"))
                {
                    lIdE.Foreground = new SolidColorBrush(Colors.Red);
                    lIdE.Content = ">>> Id: ";
                }

                return;
            }

            lIdE.Foreground = new SolidColorBrush(Colors.White);
            lIdE.Content = "Id: ";
            lOpisE.Foreground = new SolidColorBrush(Colors.White);
            lOpisE.Content = "Opis: ";
            lBoja.Foreground = new SolidColorBrush(Colors.White);
            lBoja.Content = "Boja: ";

            Etikete.Add(new Model.Etiketa { Id = double.Parse(idEtiketa.Text), Opis = opisEtiketa.Text, Boja = (Color)cbBoja.SelectedColor});
                
             EtiketaPanel.Visibility = Visibility.Hidden;
            
        }

        private void Obrisi_Etiketu(object sender, RoutedEventArgs e)
        {
            Etikete.Remove((Etiketa)etikete.SelectedItems[0]);
            etikete.UnselectAll();
            if (Etikete.Count > 1)
            {
                EtiketaPanel.Visibility = Visibility.Hidden;
            }
            
        }

        private void Azuriraj_Etiketu(object sender, RoutedEventArgs e)
        {
            if (idEtiketa.Text.Equals("") || cbBoja.SelectedColor == null)
            {
                return;
            }

            if (Etikete.Any(x => x.Id.ToString() == idEtiketa.Text))
            {
                List<Etiketa> etList = Etikete.ToList<Etiketa>();
                Etiketa et = etList.Find(x => x.Id.ToString() == idEtiketa.Text);
                int pozicija = Etikete.IndexOf(et);
                et = Etikete.ElementAt(pozicija);

                et.Opis = opisEtiketa.Text;
                et.Boja = (Color)cbBoja.SelectedColor;

                EtiketaPanel.Visibility = Visibility.Hidden;
            }

        }

        private void Dodaj_Tip(object sender, RoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(idTipa.Text, "[^0-9]") || Tipovi.Any(x => x.Id.ToString() == idTipa.Text) || idTipa.Text.Equals("") || imeTipa.Text.Equals("") || Ikonica.Source == null)
            {
                lab1.Foreground = new SolidColorBrush(Colors.White);
                lab1.Content = "Id: ";
                lab2.Foreground = new SolidColorBrush(Colors.White);
                lab2.Content = "Ime: ";
                lab4.Foreground = new SolidColorBrush(Colors.White);
                lab4.Content = "Ikonica: ";

                if (idTipa.Text.Equals(""))
                {
                    lab1.Foreground = new SolidColorBrush(Colors.Red);
                    lab1.Content = ">>> Id: ";
                }

                if (Ikonica.Source == null)
                {
                    lab4.Foreground = new SolidColorBrush(Colors.Red);
                    lab4.Content = ">>> Ikonica: ";
                }

                if (imeTipa.Text.Equals(""))
                {
                    lab2.Foreground = new SolidColorBrush(Colors.Red);
                    lab2.Content = ">>> Ime: ";
                }

                if (Tipovi.Any(x => x.Id.ToString() == idTipa.Text))
                {
                    lab1.Foreground = new SolidColorBrush(Colors.Red);
                    lab1.Content = ">>> Id već postoji: ";
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(idTipa.Text, "[^0-9]"))
                {
                    lab1.Foreground = new SolidColorBrush(Colors.Red);
                    lab1.Content = ">>> Id: ";
                }

                return;
            }

            lab1.Foreground = new SolidColorBrush(Colors.White);
            lab1.Content = "Id: ";
            lab2.Foreground = new SolidColorBrush(Colors.White);
            lab2.Content = "Ime: ";
            lab4.Foreground = new SolidColorBrush(Colors.White);
            lab4.Content = "Ikonica: ";

            Uri myUri = new Uri(Ikonica.Source.ToString(), UriKind.RelativeOrAbsolute);
            BitmapDecoder decoder = BitmapDecoder.Create(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];

            
                Tipovi.Add(new Model.Tip { Id = idTipa.Text, Ime = imeTipa.Text, Opis = opisTipa.Text, Image = bitmapSource });
                TipZivotinje.ItemsSource = Tipovi;
                idTipa.Text = "";
                imeTipa.Text = "";
                opisTipa.Text = "";
                PanelTip.Visibility = Visibility.Hidden;
            
        }

        private void Obrisi_Tip(object sender, RoutedEventArgs e)
        {
            Tip temp = (Tip)tipovi.SelectedItems[0];

            if (Animals.Any(x => x.TipZiv.Id == temp.Id))
            {
                visibility_settings((Button)sender);
            }
            else
            {
                upozorenje.Text = "Da li ste sigurni da zelite da obrisete ovaj tip?";
                visibility_settings((Button)sender);
            }
            
        }

        private void Obrisi_Tip2(object sender, RoutedEventArgs e)
        {
            List<Animal> aList = Animals.ToList();
            Tip temp = (Tip)tipovi.SelectedItems[0];
            foreach (Animal a in aList)
            {
                if (a.TipZiv.Id == temp.Id)
                {
                    Animals.Remove(a);
                }
            }

            Tipovi.Remove((Tip)tipovi.SelectedItems[0]);
            tipovi.UnselectAll();
            if (Tipovi.Count > 1)
            {
                PanelTip.Visibility = Visibility.Hidden;
            }
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            visibility_settings((Button)sender);
        }

        private void Azuriraj_Tip(object sender, RoutedEventArgs e)
        {
            if (idTipa.Text.Equals("") || imeTipa.Text.Equals("") || Ikonica.Source == null)
            {
                return;
            }

            if (Tipovi.Any(x => x.Id.ToString() == idTipa.Text))
            {
                List<Tip> tList = Tipovi.ToList<Tip>();
                Tip t = tList.Find(x => x.Id.ToString() == idTipa.Text);
                int pozicija = Tipovi.IndexOf(t);
                t = Tipovi.ElementAt(pozicija);

                t.Opis = opisTipa.Text;
                t.Ime = imeTipa.Text;
                t.Image = Ikonica.Source;

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
            win1.updateCursors();
        }

        //prikaz
        private void visibility_settings(Button sender)
        {
            if (sender.Content.Equals("Obrisati") && (sender.Name.Equals("btnObrisiTip") || sender.Name.Equals("btnObrisiTip2")))
            {
                idTipa.Visibility = Visibility.Hidden;
                imeTipa.Visibility = Visibility.Hidden;
                opisTipa.Visibility = Visibility.Hidden;
                Ikonica.Visibility = Visibility.Hidden;
                btnAzurirajTip.Visibility = Visibility.Hidden;
                btnObrisiTip.Visibility = Visibility.Hidden;
                uvozIkonice.Visibility = Visibility.Hidden;
                lab1.Visibility = Visibility.Hidden;
                lab2.Visibility = Visibility.Hidden;
                lab3.Visibility = Visibility.Hidden;
                lab4.Visibility = Visibility.Hidden;

                btnObrisiTip2.Visibility = Visibility.Visible;
                btnPonisti.Visibility = Visibility.Visible;
                upozorenje.Visibility = Visibility.Visible;
            }
            else if (sender.Name.Equals("btnT"))
            {
                RightRectangle.Visibility = Visibility.Hidden;
                EtiketaPanel.Visibility = Visibility.Hidden;
                PanelTip.Visibility = Visibility.Visible;

                zivotinje.Visibility = Visibility.Hidden;
                tipovi.Visibility = Visibility.Visible;
                etikete.Visibility = Visibility.Hidden;

                idTipa.Visibility = Visibility.Visible;
                imeTipa.Visibility = Visibility.Visible;
                opisTipa.Visibility = Visibility.Visible;
                Ikonica.Visibility = Visibility.Visible;
                rctSlikaa.Visibility = Visibility.Visible;
                uvozIkonice.Visibility = Visibility.Visible;
                lab1.Visibility = Visibility.Visible;
                lab2.Visibility = Visibility.Visible;
                lab3.Visibility = Visibility.Visible;
                lab4.Visibility = Visibility.Visible;

                noviT.Visibility = Visibility.Visible;
                btnKreirajTip.Visibility = Visibility.Visible;
                btnAzurirajTip.Visibility = Visibility.Hidden;
                btnObrisiTip.Visibility = Visibility.Hidden;
                btnObrisiTip2.Visibility = Visibility.Hidden;
                btnPonisti.Visibility = Visibility.Hidden;
                upozorenje.Visibility = Visibility.Hidden;
            }
            else if (sender.Name.Equals("btnE"))
            {
                RightRectangle.Visibility = Visibility.Hidden;
                PanelTip.Visibility = Visibility.Hidden;
                EtiketaPanel.Visibility = Visibility.Visible;

                zivotinje.Visibility = Visibility.Hidden;
                tipovi.Visibility = Visibility.Hidden;
                etikete.Visibility = Visibility.Visible;

                novaE.Visibility = Visibility.Visible;
                btnKreirajEtiketu.Visibility = Visibility.Visible;
                btnAzurirajEtiketu.Visibility = Visibility.Hidden;
                btnObrisiEtiketu.Visibility = Visibility.Hidden;
            }
            else if (sender.Name.Equals("btnZ"))
            {
                PanelTip.Visibility = Visibility.Hidden;
                EtiketaPanel.Visibility = Visibility.Hidden;
                RightRectangle.Visibility = Visibility.Visible;
                btnDodajUListu.Visibility = Visibility.Visible;
                btnAzurirajListu.Visibility = Visibility.Hidden;
                btnObrisi.Visibility = Visibility.Hidden;

                zivotinje.Visibility = Visibility.Visible;
                tipovi.Visibility = Visibility.Hidden;
                etikete.Visibility = Visibility.Hidden;
            }
            else if (sender.Name.Equals("btnPonisti"))
            {
                noviT.Visibility = Visibility.Hidden;
                PanelTip.Visibility = Visibility.Visible;
                btnKreirajTip.Visibility = Visibility.Hidden;
                btnAzurirajTip.Visibility = Visibility.Visible;
                btnObrisiTip.Visibility = Visibility.Visible;

                idTipa.Visibility = Visibility.Visible;
                imeTipa.Visibility = Visibility.Visible;
                opisTipa.Visibility = Visibility.Visible;
                Ikonica.Visibility = Visibility.Visible;
                uvozIkonice.Visibility = Visibility.Visible;
                rctSlikaa.Visibility = Visibility.Hidden;
                lab1.Visibility = Visibility.Visible;
                lab2.Visibility = Visibility.Visible;
                lab3.Visibility = Visibility.Visible;
                lab4.Visibility = Visibility.Visible;

                btnObrisiTip2.Visibility = Visibility.Hidden;
                btnPonisti.Visibility = Visibility.Hidden;
                upozorenje.Visibility = Visibility.Hidden;
            }
        }

        private void visibility_settings_list(ListView sender)
        {
            if (sender.Items.Count > 0)
            {
                var selected = sender.SelectedItem;

                if (sender.SelectedItems.Count > 0)
                {
                    selected = sender.SelectedItems[0];
                }
                else
                {
                    sender.SelectedIndex = 0;
                    selected = sender.SelectedItems[0];
                }

                if (selected.GetType().ToString() == "ProjektniZadatak.Model.Animal")
                {
                    rctSlika.Visibility = Visibility.Hidden;
                    btnDodajUListu.Visibility = Visibility.Hidden;
                    btnAzurirajListu.Visibility = Visibility.Visible;
                    btnObrisi.Visibility = Visibility.Visible;
                    RightRectangle.Visibility = Visibility.Visible;
                    PanelTip.Visibility = Visibility.Hidden;
                    EtiketaPanel.Visibility = Visibility.Hidden;
                }
                else if (selected.GetType().ToString() == "ProjektniZadatak.Model.Etiketa")
                {
                    novaE.Visibility = Visibility.Hidden;
                    EtiketaPanel.Visibility = Visibility.Visible;
                    btnKreirajEtiketu.Visibility = Visibility.Hidden;
                    btnAzurirajEtiketu.Visibility = Visibility.Visible;
                    btnObrisiEtiketu.Visibility = Visibility.Visible;
                }
                else if (selected.GetType().ToString() == "ProjektniZadatak.Model.Tip")
                {
                    noviT.Visibility = Visibility.Hidden;
                    PanelTip.Visibility = Visibility.Visible;
                    btnKreirajTip.Visibility = Visibility.Hidden;
                    btnAzurirajTip.Visibility = Visibility.Visible;
                    btnObrisiTip.Visibility = Visibility.Visible;

                    idTipa.Visibility = Visibility.Visible;
                    imeTipa.Visibility = Visibility.Visible;
                    opisTipa.Visibility = Visibility.Visible;
                    Ikonica.Visibility = Visibility.Visible;
                    uvozIkonice.Visibility = Visibility.Visible;
                    rctSlikaa.Visibility = Visibility.Hidden;
                    lab1.Visibility = Visibility.Visible;
                    lab2.Visibility = Visibility.Visible;
                    lab3.Visibility = Visibility.Visible;
                    lab4.Visibility = Visibility.Visible;

                    btnObrisiTip2.Visibility = Visibility.Hidden;
                    btnPonisti.Visibility = Visibility.Hidden;
                    upozorenje.Visibility = Visibility.Hidden;
                }
            } 
            else
            {
                RightRectangle.Visibility = Visibility.Hidden;
                PanelTip.Visibility = Visibility.Hidden;
                EtiketaPanel.Visibility = Visibility.Hidden;
            }

            
        }

        private void IdEtiketa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
