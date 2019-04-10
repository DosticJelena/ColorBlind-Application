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
    /// Interaction logic for EtiketaProzor.xaml
    /// </summary>
    public partial class EtiketaProzor : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static int brojacEtikete=0;

        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public static ObservableCollection<Model.Etiketa> Etikete
        {
            get;
            set;
        }

        public EtiketaProzor()
        {
            InitializeComponent();

            this.DataContext = this;

            if (brojacEtikete == 0)
            {
                Etikete = new ObservableCollection<Model.Etiketa>();

                Etikete.Add(new Model.Etiketa { Id = 1, Opis = "Pernate zivotinje" });
                Etikete.Add(new Model.Etiketa { Id = 2, Opis = "Zive na kopnu" });
                Etikete.Add(new Model.Etiketa { Id = 3, Opis = "Zive u vodi" });
            }
           
        }

        private void Dodaj_Etiketu(object sender, RoutedEventArgs e)
        {
            if (idEtiketa.Equals("") && opisEtiketa.Equals(""))
            {
                
            }
            else
            {
                Etikete.Add(new Model.Etiketa { Id = int.Parse(idEtiketa.Text), Opis = opisEtiketa.Text });
                // POVEZI XAML SA LISTOM !!!
                this.Hide();
            }
        }
    }
}
