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
            
           
        }

        public Window1(ObservableCollection<Animal> a, ObservableCollection<Etiketa> e, ObservableCollection<Tip> t)
        {
            InitializeComponent();

            Animals = a;
            Tipovi = t;
            Etikete = e;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Species species = new Species(Etikete,Tipovi,Animals,this);
            Species.brojac++;
            ((Button)sender).Cursor = Cursors.Wait;
            species.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Map map = new Map(Animals,this);
            ((Button)sender).Cursor = Cursors.Wait;
            map.ShowDialog();
        }

        /*protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }*/
 
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

        public void updateCursors()
        {
            btnAS.Cursor = Cursors.Hand;
            btnM.Cursor = Cursors.Hand;
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\jelen\Documents\TmpHtml\ProjektniZadatak-Help.chm");
        }
    }

}
