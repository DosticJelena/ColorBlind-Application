using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjektniZadatak.Model
{
    public class Animal : INotifyPropertyChanged//SAMO POLJA
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public enum StatusUgrozenosti { KriticnoUgrozena = 5, Ugrozena = 4, Ranjiva = 3, ZavisnaOdStanista = 2, BlizuRizika = 1, MinRizika = 0 };
        public enum TuristickiStatus { Izolovana, DelimicnoHabituirana, Habituirana };

        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        private string _opis;
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        private StatusUgrozenosti _stUgr;
        public StatusUgrozenosti StUgr
        {
            get
            {
                return _stUgr;
            }
            set
            {
                if (value != _stUgr)
                {
                    _stUgr = value;
                    OnPropertyChanged("StUgr");
                }
            }
        }

        private TuristickiStatus _stTur;
        public TuristickiStatus StTur
        {
            get
            {
                return _stTur;
            }
            set
            {
                if (value != _stTur)
                {
                    _stTur = value;
                    OnPropertyChanged("StTur");
                }
            }
        }

        private ImageSource _image;
        public ImageSource Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        private bool _opasna;
        public bool Opasna
        {
            get
            {
                return _opasna;
            }
            set
            {
                if (value != _opasna)
                {
                    _opasna = value;
                    OnPropertyChanged("Opasna");
                }
            }
        }

        private bool _crvenaLista;
        public bool CrvenaLista
        {
            get
            {
                return _crvenaLista;
            }
            set
            {
                if (value != _crvenaLista)
                {
                    _crvenaLista = value;
                    OnPropertyChanged("CrvenaLista");
                }
            }
        }

        private bool _naseljeniRegion;
        public bool NaseljeniRegion
        {
            get
            {
                return _naseljeniRegion;
            }
            set
            {
                if (value != _naseljeniRegion)
                {
                    _naseljeniRegion = value;
                    OnPropertyChanged("NaseljeniRegion");
                }
            }
        }

        private string _godisnjiPrihod;
        public string GodisnjiPrihod
        {
            get
            {
                return _godisnjiPrihod;
            }
            set
            {
                if (value != _godisnjiPrihod)
                {
                    _godisnjiPrihod = value;
                    OnPropertyChanged("GodisnjiPrihod");
                }
            }
        }

        private  Tip _tipZiv;
        public  Tip TipZiv
        {
            get
            {
                return _tipZiv;
            }
            set
            {
                if (value != _tipZiv)
                {
                    _tipZiv = value;
                    OnPropertyChanged("TipZiv");
                }
            }
        }

        private List<Etiketa> _etiketeZiv;
        public List<Etiketa> EtiketeZiv
        {
            get
            {
                return _etiketeZiv;
            }
            set
            {
                if (value != _etiketeZiv)
                {
                    _etiketeZiv = value;
                    OnPropertyChanged("EtiketeZiv");
                }
            }
        }

        private DateTime _datum;
        public DateTime Datum
        {
            get
            {
                return _datum;
            }
            set
            {
                if (value != _datum)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

    }

}
