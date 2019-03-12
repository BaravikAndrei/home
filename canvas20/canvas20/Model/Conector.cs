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
        private int posX;
        private int posY;
        private int sizeOfConector;
        private int idOfBox;

        public List<int> IdOfOtherConector
        {
            get { return idOfOtherConector; }
            set
            {
                idOfOtherConector = value;
                OnPropertyChanged();
            }
        }
        public int PosX
        {
            get { return posX; }
            set
            {
                posX = value;
                OnPropertyChanged();
            }
        }
        public int PosY
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
        public string GetIdOfBox()
        {
            string str = IdOfBox.ToString();
            return str;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
