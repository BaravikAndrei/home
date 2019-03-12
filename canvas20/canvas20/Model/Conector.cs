using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace canvas20
{
    public class Conector: INotifyPropertyChanged
    {
        private List<int> idOfOtherConector = new List<int>();
        private double posX;
        private double posY;
        private int sizeOfConector;
        private int idOfBox;
        private Box boxOfConnector;
        public bool IsDrag = false;
        //public delegate void ConectorPosChangedd(Box sender, double dX);
        //public event ConectorPosChangedd IsChangedXX;
        //public event ConectorPosChangedd IsChangedYY;


        public Box BoxOfConnector
        {
            get { return boxOfConnector; }
            set
            {
                boxOfConnector = value;
                OnPropertyChanged();
            }
        }
        public List<int> IdOfOtherConector
        {
            get { return idOfOtherConector; }
            set
            {
                idOfOtherConector = value;
                OnPropertyChanged();
            }
        }
        public double PosX
        {
            get { return posX; }
            set
            {
                posX = value;
                OnPropertyChanged();
            }
        }
        public double PosY
        {
            get { return posY; }
            set
            {
                posY = value;
                OnPropertyChanged();
            }
        }
        public int SizeOfConector
        {
            get { return sizeOfConector; }
            set
            {
                sizeOfConector = value;
                OnPropertyChanged();
            }
        }
        public int IdOfBox
        {
            get { return idOfBox; }
            set
            {
                idOfBox = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
