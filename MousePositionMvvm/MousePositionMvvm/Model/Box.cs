using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MousePositionMvvm
{
    public class Box : INotifyPropertyChanged
    {
        //public static int idValue = 0;

        private int _id = 0;
        private int _size = 25;
        private int _margin = 5;
        private double _canvasLeft = 0;
        private double _canvasTop = 0;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged();
            }
        }
        public int Margin
        {
            get { return _margin; }
            set
            {
                _margin = value;
                OnPropertyChanged();
            }
        }

        public double CanvasLeft
        {
            get
            {
                return _canvasLeft;

            }

            set
            {
                _canvasLeft = value;
                OnPropertyChanged();
            }
        }

        public double CanvasTop
        {
            get
            {
                return _canvasTop;
            }

            set
            {
                _canvasTop = value;
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