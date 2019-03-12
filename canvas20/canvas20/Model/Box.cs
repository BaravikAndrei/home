using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace canvas20
{
    public class Box : INotifyPropertyChanged
    {
        private int id = 0;
        private int size = 0;
        private Conector allconector = new Conector();

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public int Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }
        public Conector AllConector
        {
            get { return allconector; }
            set
            {
                allconector = value;
                OnPropertyChanged(nameof(AllConector));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
