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

namespace ProjektniZadatak.Prozori
{
    /// <summary>
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static int brojac = 0;
        private int animalIndex;
        private int brojacKoraka = 0;

        //dozvole za izvrsavanje dugmica...
        private bool dozT = false;
        private bool dozE = false;
        private bool dozZ = false;
        private bool dozLT = false;
        private bool dozLE = false;
        private bool dozZE = false;

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

        public Tutorial()
        {
            InitializeComponent();

            this.Animals = new ObservableCollection<Animal>();
            this.Etikete = new ObservableCollection<Etiketa>();
            this.Tipovi = new ObservableCollection<Tip>();
            //this.win1 = w;

            RightRectangle.Visibility = Visibility.Hidden;
            EtiketaPanel.Visibility = Visibility.Hidden;
            PanelTip.Visibility = Visibility.Hidden;
            DobrodosliPanel.Visibility = Visibility.Visible;
            korak2.Visibility = Visibility.Hidden;
            dobLab2.Visibility = Visibility.Hidden;
            korak3.Visibility = Visibility.Hidden;
            dobLab3.Visibility = Visibility.Hidden;
            korak4.Visibility = Visibility.Hidden;
            dobLab4.Visibility = Visibility.Hidden;
            btnPokreni.Visibility = Visibility.Hidden;

            this.DataContext = this;

            EtiketeZivotinje.ItemsSource = Etikete;
            TipZivotinje.ItemsSource = Tipovi;
            zivotinje.ItemsSource = Animals;
            etikete.ItemsSource = Etikete;
            etikete.Visibility = Visibility.Hidden;
            tipovi.ItemsSource = Tipovi;
            tipovi.Visibility = Visibility.Hidden;

            //btnZ.IsEnabled = false;
            //btnE.IsEnabled = false;
            
            btnT.BorderBrush = new SolidColorBrush(Colors.White);
            btnT.BorderThickness = new Thickness(5,5,5,5);
            dozT = true;
            dozE = false;
            dozZ = false;


        }

        // Dugme za prikaz panela za dodavanje zivotinje
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (dozZ)
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
                btnZ.BorderThickness = new Thickness(0, 1, 0, 1);
                visibility_settings((Button)sender);
            }
            
        }


        // Dugmici za dodavanje, azuriranje i brisanje zivotinje iz liste
        private void Dodavanje_Zivotinje(object sender, RoutedEventArgs e)
        {
            if (pickDatum.SelectedDate == null || TipZivotinje.SelectedItem == null || StTurZivotinje.SelectedItem == null || StUgrZivotinje.SelectedItem == null
                || IdZivotinje.Text.Equals("") || ImeZivotinje.Text.Equals("") || godPrihod.Text.Equals(""))
            {
                lDatum.Foreground = new SolidColorBrush(Colors.White);
                lTip.Foreground = new SolidColorBrush(Colors.White);
                lStTur.Foreground = new SolidColorBrush(Colors.White);
                lStUgr.Foreground = new SolidColorBrush(Colors.White);
                lId.Foreground = new SolidColorBrush(Colors.White);
                lIme.Foreground = new SolidColorBrush(Colors.White);
                godPrihod.Foreground = new SolidColorBrush(Colors.White);

                if (pickDatum.SelectedDate == null)
                {
                    lDatum.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (TipZivotinje.SelectedItem == null)
                {
                    lTip.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (StTurZivotinje.SelectedItem == null)
                {
                    lStTur.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (StUgrZivotinje.SelectedItem == null)
                {
                    lStUgr.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (IdZivotinje.Text.Equals(""))
                {
                    lId.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (ImeZivotinje.Text.Equals(""))
                {
                    lIme.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (godPrihod.Text.Equals(""))
                {
                    lGodPrihod.Foreground = new SolidColorBrush(Colors.Red);
                }

                return;
            }

            lDatum.Foreground = new SolidColorBrush(Colors.White);
            lTip.Foreground = new SolidColorBrush(Colors.White);
            lStTur.Foreground = new SolidColorBrush(Colors.White);
            lStUgr.Foreground = new SolidColorBrush(Colors.White);
            lId.Foreground = new SolidColorBrush(Colors.White);
            lIme.Foreground = new SolidColorBrush(Colors.White);
            lGodPrihod.Foreground = new SolidColorBrush(Colors.White);

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


            Animals.Add(new Animal
            {
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
                EtiketeZiv = lista
            });

            RightRectangle.Visibility = Visibility.Hidden;
            dozZ = false;
            DobrodosliPanel.Visibility = Visibility.Visible;
            korak1.Visibility = Visibility.Hidden;
            dobLab1.Visibility = Visibility.Hidden;
            korak2.Visibility = Visibility.Hidden;
            dobLab2.Visibility = Visibility.Hidden;
            korak3.Visibility = Visibility.Hidden;
            dobLab3.Visibility = Visibility.Hidden;
            korak4.Visibility = Visibility.Visible;
            dobLab4.Visibility = Visibility.Visible;
            btnPokreni.Visibility = Visibility.Visible;

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
            if (dozE)
            {
                idEtiketa.Text = "";
                idEtiketa.IsEnabled = true;
                opisEtiketa.Text = "";
                cbBoja.SelectedColor = null;
                idEtiketa.Focus();
                nazivListe.Content = "Lista Etiketa";
                btnE.BorderThickness = new Thickness(0, 1, 0, 1);
                visibility_settings((Button)sender);
            }
            
        }

        private void Novi_Tip(object sender, RoutedEventArgs e)
        {
            if (dozT)
            {
                idTipa.Text = "";
                idTipa.IsEnabled = true;
                imeTipa.Text = "";
                opisTipa.Text = "";
                Ikonica.Source = null;
                idTipa.Focus();
                nazivListe.Content = "Lista Tipova";
                btnT.BorderThickness = new Thickness(0, 1, 0, 1);
                visibility_settings((Button)sender);
            }
            
        }


        // Selektovani element liste
        private void Selekcija_Liste(object sender, SelectionChangedEventArgs e)
        {
            if (dozZE)
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
            
        }

        private void Selekcija_Liste_Etikete(object sender, SelectionChangedEventArgs e)
        {
            if (dozLE)
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
            

        }

        private void Selekcija_Liste_Tipovi(object sender, SelectionChangedEventArgs e)
        {
            if (dozLT)
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
            

        }


        // Dugmici za dodavanje etikete i tipa u listu etiketa i listu tipova
        private void Dodaj_Etiketu(object sender, RoutedEventArgs e)
        {
            if (idEtiketa.Text.Equals("") || opisEtiketa.Text.Equals("") || cbBoja.SelectedColor == null)
            {
                lIdE.Foreground = new SolidColorBrush(Colors.White);
                lOpisE.Foreground = new SolidColorBrush(Colors.White);
                lBoja.Foreground = new SolidColorBrush(Colors.White);

                if (idEtiketa.Text.Equals(""))
                {
                    lIdE.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (cbBoja.SelectedColor == null)
                {
                    lBoja.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (opisEtiketa.Text.Equals(""))
                {
                    lOpisE.Foreground = new SolidColorBrush(Colors.Red);
                }

                return;
            }

            lIdE.Foreground = new SolidColorBrush(Colors.White);
            lOpisE.Foreground = new SolidColorBrush(Colors.White);
            lBoja.Foreground = new SolidColorBrush(Colors.White);

            Etikete.Add(new Model.Etiketa { Id = double.Parse(idEtiketa.Text), Opis = opisEtiketa.Text, Boja = (Color)cbBoja.SelectedColor });

            EtiketaPanel.Visibility = Visibility.Hidden;
            DobrodosliPanel.Visibility = Visibility.Visible;
            korak1.Visibility = Visibility.Hidden;
            korak2.Visibility = Visibility.Hidden;
            dobLab1.Visibility = Visibility.Hidden;
            dobLab2.Visibility = Visibility.Hidden;
            korak3.Visibility = Visibility.Visible;
            dobLab3.Visibility = Visibility.Visible;
            btnPokreni.Visibility = Visibility.Hidden;
            btnZ.BorderThickness = new Thickness(5, 5, 5, 5);
            dozZ = true;
            dozT = false;
            dozE = false;

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
            if (idTipa.Text.Equals("") || imeTipa.Text.Equals("") || Ikonica.Source == null)
            {
                lab1.Foreground = new SolidColorBrush(Colors.White);
                lab2.Foreground = new SolidColorBrush(Colors.White);
                lab4.Foreground = new SolidColorBrush(Colors.White);

                if (idTipa.Text.Equals(""))
                {
                    lab1.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (Ikonica.Source == null)
                {
                    lab4.Foreground = new SolidColorBrush(Colors.Red);
                }

                if (imeTipa.Text.Equals(""))
                {
                    lab2.Foreground = new SolidColorBrush(Colors.Red);
                }

                return;
            }

            lab1.Foreground = new SolidColorBrush(Colors.White);
            lab2.Foreground = new SolidColorBrush(Colors.White);
            lab4.Foreground = new SolidColorBrush(Colors.White);

            Uri myUri = new Uri(Ikonica.Source.ToString(), UriKind.RelativeOrAbsolute);
            BitmapDecoder decoder = BitmapDecoder.Create(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];


            Tipovi.Add(new Model.Tip { Id = idTipa.Text, Ime = imeTipa.Text, Opis = opisTipa.Text, Image = bitmapSource });
            TipZivotinje.ItemsSource = Tipovi;
            idTipa.Text = "";
            imeTipa.Text = "";
            opisTipa.Text = "";
            PanelTip.Visibility = Visibility.Hidden;
            btnE.BorderThickness = new Thickness(5, 5, 5, 5);
            dozE = true;
            dozZ = false;
            dozT = false;
            DobrodosliPanel.Visibility = Visibility.Visible;
            korak1.Visibility = Visibility.Hidden;
            dobLab1.Visibility = Visibility.Hidden;
            korak2.Visibility = Visibility.Visible;
            dobLab2.Visibility = Visibility.Visible;
            korak3.Visibility = Visibility.Hidden;
            dobLab3.Visibility = Visibility.Hidden;
            btnPokreni.Visibility = Visibility.Hidden;

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
            
            //win1.updateCursors();
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
                DobrodosliPanel.Visibility = Visibility.Hidden;

                zivotinje.Visibility = Visibility.Hidden;
                tipovi.Visibility = Visibility.Visible;
                etikete.Visibility = Visibility.Hidden;

                idTipa.Visibility = Visibility.Visible;
                imeTipa.Visibility = Visibility.Hidden;
                opisTipa.Visibility = Visibility.Hidden;
                Ikonica.Visibility = Visibility.Hidden;
                rctSlikaa.Visibility = Visibility.Hidden;
                uvozIkonice.Visibility = Visibility.Hidden;
                lab1.Visibility = Visibility.Visible;
                lab2.Visibility = Visibility.Hidden;
                lab3.Visibility = Visibility.Hidden;
                lab4.Visibility = Visibility.Hidden;

                noviT.Visibility = Visibility.Visible;
                btnKreirajTip.Visibility = Visibility.Hidden;
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
                DobrodosliPanel.Visibility = Visibility.Hidden;

                zivotinje.Visibility = Visibility.Hidden;
                tipovi.Visibility = Visibility.Hidden;
                etikete.Visibility = Visibility.Visible;

                novaE.Visibility = Visibility.Visible;
                btnNextE.Visibility = Visibility.Visible;
                btnKreirajEtiketu.Visibility = Visibility.Hidden;
                btnAzurirajEtiketu.Visibility = Visibility.Hidden;
                btnObrisiEtiketu.Visibility = Visibility.Hidden;

                idEtiketa.Visibility = Visibility.Visible;
                lIdE.Visibility = Visibility.Visible;
                cbBoja.Visibility = Visibility.Hidden;
                lBoja.Visibility = Visibility.Hidden;
                opisEtiketa.Visibility = Visibility.Hidden;
                lOpisE.Visibility = Visibility.Hidden;
            }
            else if (sender.Name.Equals("btnZ"))
            {
                PanelTip.Visibility = Visibility.Hidden;
                EtiketaPanel.Visibility = Visibility.Hidden;
                RightRectangle.Visibility = Visibility.Visible;
                DobrodosliPanel.Visibility = Visibility.Hidden;

                btnDodajUListu.Visibility = Visibility.Visible;
                btnAzurirajListu.Visibility = Visibility.Hidden;
                btnObrisi.Visibility = Visibility.Hidden;

                zivotinje.Visibility = Visibility.Visible;
                tipovi.Visibility = Visibility.Hidden;
                etikete.Visibility = Visibility.Hidden;

                IdZivotinje.Visibility = Visibility.Visible;
                lId.Visibility = Visibility.Visible;
                ImeZivotinje.Visibility = Visibility.Hidden;
                lIme.Visibility = Visibility.Hidden;
                OpisZivotinje.Visibility = Visibility.Hidden;
                lOpis.Visibility = Visibility.Hidden;
                StTurZivotinje.Visibility = Visibility.Hidden;
                lStTur.Visibility = Visibility.Hidden;
                StUgrZivotinje.Visibility = Visibility.Hidden;
                lStUgr.Visibility = Visibility.Hidden;
                godPrihod.Visibility = Visibility.Hidden;
                lGodPrihod.Visibility = Visibility.Hidden;
                pickDatum.Visibility = Visibility.Hidden;
                lDatum.Visibility = Visibility.Hidden;
                lSlika.Visibility = Visibility.Hidden;
                rctSlika.Visibility = Visibility.Hidden;
                SlikaZivotinje.Visibility = Visibility.Hidden;
                btnDodajSliku.Visibility = Visibility.Hidden;
                cbCrvenaLista.Visibility = Visibility.Hidden; 
                cbNaseljeniRegion.Visibility = Visibility.Hidden; 
                cbOpasna.Visibility = Visibility.Hidden;
                lCrvenaLista.Visibility = Visibility.Hidden;
                lNasReg.Visibility = Visibility.Hidden;
                lOpasna.Visibility = Visibility.Hidden;
                lTip.Visibility = Visibility.Hidden;
                TipZivotinje.Visibility = Visibility.Hidden;
                lEtikete.Visibility = Visibility.Hidden;
                EtiketeZivotinje.Visibility = Visibility.Hidden;
                btnDodajUListu.Visibility = Visibility.Hidden;

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
                    btnNext.Visibility = Visibility.Hidden;
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

        private void Next(object sender, RoutedEventArgs e)
        {
            brojacKoraka++;

            if (brojacKoraka == 1)
            {
                imeTipa.Visibility = Visibility.Visible;
                lab2.Visibility = Visibility.Visible;
                
                return;
            } 
            else if (brojacKoraka == 2)
            {
                opisTipa.Visibility = Visibility.Visible;
                lab3.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 3)
            {
                rctSlikaa.Visibility = Visibility.Visible;
                Ikonica.Visibility = Visibility.Visible;
                uvozIkonice.Visibility = Visibility.Visible;
                lab4.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 4)
            {
                btnKreirajTip.Visibility = Visibility.Visible;
                brojacKoraka = 0;
                return;
            }
            else
            {
                brojacKoraka = 0;
                ((Button)sender).IsEnabled = false;
                return;
            }

        }

        private void NextE(object sender, RoutedEventArgs e)
        {
            brojacKoraka++;

            if (brojacKoraka == 1)
            {
                cbBoja.Visibility = Visibility.Visible;
                lBoja.Visibility = Visibility.Visible;

                return;
            }
            else if (brojacKoraka == 2)
            {
                opisEtiketa.Visibility = Visibility.Visible;
                lOpisE.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 3)
            {
                btnKreirajEtiketu.Visibility = Visibility.Visible;
                brojacKoraka = 0;
                return;
            }
            else
            {
                brojacKoraka = 0;
                ((Button)sender).IsEnabled = false;
                return;
            }
        }

        private void NextZ(object sender, RoutedEventArgs e)
        {
            brojacKoraka++;

            if (brojacKoraka == 1)
            {
                ImeZivotinje.Visibility = Visibility.Visible;
                lIme.Visibility = Visibility.Visible;

                return;
            }
            else if (brojacKoraka == 2)
            {
                OpisZivotinje.Visibility = Visibility.Visible;
                lOpis.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 3)
            {
                StUgrZivotinje.Visibility = Visibility.Visible;
                lStUgr.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 4)
            {
                StTurZivotinje.Visibility = Visibility.Visible;
                lStTur.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 5)
            {
                godPrihod.Visibility = Visibility.Visible;
                lGodPrihod.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 6)
            {
                pickDatum.Visibility = Visibility.Visible;
                lDatum.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 7)
            {
                lSlika.Visibility = Visibility.Visible;
                rctSlika.Visibility = Visibility.Visible;
                SlikaZivotinje.Visibility = Visibility.Visible;
                btnDodajSliku.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 8)
            {
                cbCrvenaLista.Visibility = Visibility.Visible; 
                cbNaseljeniRegion.Visibility = Visibility.Visible; 
                cbOpasna.Visibility = Visibility.Visible;
                lCrvenaLista.Visibility = Visibility.Visible;
                lNasReg.Visibility = Visibility.Visible;
                lOpasna.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 9)
            {
                lTip.Visibility = Visibility.Visible;
                TipZivotinje.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 10)
            {
                lEtikete.Visibility = Visibility.Visible;
                EtiketeZivotinje.Visibility = Visibility.Visible;
                return;
            }
            else if (brojacKoraka == 11)
            {
                btnDodajUListu.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                brojacKoraka = 0;
                ((Button)sender).IsEnabled = false;
                return;
            }
        }

        private void Pokreni(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1(Animals,Etikete,Tipovi);
            w.Show();
            ((Button)sender).Cursor = Cursors.Wait;
            this.Visibility = Visibility.Hidden;
        }
    }
}
