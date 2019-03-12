using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace canvas20
{
    public class Box : INotifyPropertyChanged
    {
        private int id = 0;
        private int size = 0;
        private Point posOfBox = new Point();
        private List<Conector> listConector = new List<Conector>();
        private string title;
        //private Conector leftconector = new Conector();
        //private Conector topconector = new Conector();
        //private Conector rightconector = new Conector();
        //private Conector bottomconector = new Conector();
        //public delegate void ConectorPosChanged(Box sender, double dX);
        //public event ConectorPosChanged IsChangedX;
        //public event ConectorPosChanged IsChangedY;
        public List<Conector> ListConector
        {
            get { return listConector; }
            set
            {
                listConector = value;
                OnPropertyChanged();
            }
        }
        public double PosOfBoxX
        {
            get { return posOfBox.X; }
            set
            {
                posOfBox.X = value;
                OnPropertyChanged("PosOfBox");
            }
        }
        public double PosOfBoxY
        {
            get { return posOfBox.Y; }
            set
            {
                posOfBox.Y = value;
                OnPropertyChanged("PosOfBox");
            }
        }
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

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        //public Conector LeftConector
        //{
        //    get { return leftconector; }
        //    set
        //    {
        //        leftconector = value;
        //        OnPropertyChanged(nameof(LeftConector));
        //    }
        //}
        //public Conector TopConector
        //{
        //    get { return topconector; }
        //    set
        //    {
        //        topconector = value;
        //        OnPropertyChanged(nameof(TopConector));
        //    }
        //}
        //public Conector RightConector
        //{
        //    get { return rightconector; }
        //    set
        //    {
        //        rightconector = value;
        //        OnPropertyChanged(nameof(RightConector));
        //    }
        //}
        //public Conector BottomConector
        //{
        //    get { return bottomconector; }
        //    set
        //    {
        //        bottomconector = value;
        //        OnPropertyChanged(nameof(BottomConector));
        //    }
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
