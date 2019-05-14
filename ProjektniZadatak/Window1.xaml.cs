using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjektniZadatak.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static int brojac = 0;

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

        public Window1()
        {
            InitializeComponent();
            Animals = new ObservableCollection<Animal>();
            Tipovi = new ObservableCollection<Tip>();
            Etikete = new ObservableCollection<Etiketa>();

            //Tipovi.Add(new Tip { Id = "1", Ime = "Ptice", Opis = "Pernate zivotinje", Image = new BitmapImage(new Uri("C:\\Users\\jelen\\Pictures\\Projekat\\pticaTip.png")) });
            //Tipovi.Add(new Tip { Id = "2", Ime = "Kopnene", Opis = "Zive na kopnu", Image = new BitmapImage(new Uri("C:\\Users\\jelen\\Pictures\\Projekat\\slonTip.png")) });
            //Tipovi.Add(new Tip { Id = "3", Ime = "Vodene", Opis = "Zive u vodi", Image = new BitmapImage(new Uri("C:\\Users\\jelen\\Pictures\\Projekat\\ribaTip.png")) });

            //Etikete.Add(new Etiketa { Id = 1, Opis = "Opis 1", Boja = Colors.DarkRed });
            //Etikete.Add(new Etiketa { Id = 2, Opis = "Opis 2", Boja = Colors.RoyalBlue });
            //Etikete.Add(new Etiketa { Id = 3, Opis = "Opis 3", Boja = Colors.Gold });


            /*Animal prva = new Animal
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
                Image = new BitmapImage(new Uri("https://images.unsplash.com/photo-1532226994725-7b63013bd1d7?ixlib=rb-1.2.1&auto=format&fit=crop&w=967&q=80")),
                Datum = new DateTime(2018, 6, 7),
                EtiketeZiv = new List<Etiketa>()
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
                Image = new BitmapImage(new Uri("https://images.unsplash.com/photo-1550741442-4c6d93cc55d8?ixlib=rb-1.2.1&auto=format&fit=crop&w=682&q=80")),
                Datum = new DateTime(2018, 6, 5),
                EtiketeZiv = new List<Etiketa>()
            };
            */
            //Animals.Add(prva);
            //Animals.Add(druga);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Species species = new Species(Etikete,Tipovi,Animals);
            Species.brojac++;
            species.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Map map = new Map(Animals);
            map.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
 
        private void HoverT(object sender, MouseEventArgs e)
        {
            //btnTutorial.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void HoverTLeave(object sender, MouseEventArgs e)
        {
            //btnTutorial.Foreground = new SolidColorBrush(Colors.White);
        }

        private void HoverAS(object sender, MouseEventArgs e)
        {
            btnAS.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void HoverASLeave(object sender, MouseEventArgs e)
        {
            btnAS.Foreground = new SolidColorBrush(Colors.White);
        }

        private void HoverH(object sender, MouseEventArgs e)
        {
            btnHelp.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void HoverHLeave(object sender, MouseEventArgs e)
        {
            btnHelp.Foreground = new SolidColorBrush(Colors.White);
        }

        private void HoverM(object sender, MouseEventArgs e)
        {
            btnM.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void HoverMLeave(object sender, MouseEventArgs e)
        {
            btnM.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            saveFileDialog.Title = "Save As...";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter file = File.CreateText(saveFileDialog.FileName))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    List<object> podaci = new List<object>();

                    podaci.Add(Animals);
                    podaci.Add(Etikete);
                    podaci.Add(Tipovi);

                    serializer.Serialize(file, podaci);

                }
            }
            
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a file";
            op.Filter = "JSON files (*.json)|*.json";

            if (op.ShowDialog() == true)
            {
                StreamReader file = File.OpenText(op.FileName);

                using (file)
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<object> podaci = new List<object>();
                    podaci = (List<object>)serializer.Deserialize(file, typeof(List<object>));
                    List<Array> podaci_izvuceni = new List<Array>();

                    int i = -1;
                    foreach (var o in podaci)
                    {
                        i++;
                        if (i == 0)
                        {
                            JArray animals = (JArray)o;
                            Animals = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Animal>>(animals.ToString());
                        }
                        else if (i == 1)
                        {
                            JArray etikete = (JArray)o;
                            Etikete = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Etiketa>>(etikete.ToString());
                        }
                        else if (i == 2)
                        {
                            JArray tipovi = (JArray)o;
                            Tipovi = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Tip>>(tipovi.ToString());
                        }
                        
                    }
                    
                }
            }
            
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Prozori.Start s = new Prozori.Start();
            s.ShowDialog();
        }
    }

}
