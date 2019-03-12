using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace canvas20
{
    public class Point : INotifyPropertyChanged
    {
        private double x;
        private double y;
        public double X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged();
            }
        }
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        }
    }
    public class ConectorLine : INotifyPropertyChanged
    {
        private string startedId;
        private string finishedId;
        private int lineId;
        private Point start = new Point();
        private Point finish = new Point();

        public int LineId
        {
            get { return lineId; }
            set
            {
                lineId = value;
                OnPropertyChanged();
            }
        }
        public string StartedId
        {
            get { return startedId; }
            set
            {
                startedId = value;
                OnPropertyChanged();
            }
        }
        public string FinishedId
        {
            get { return finishedId; }
            set
            {
                finishedId = value;
                OnPropertyChanged();
            }
        }

        public Point Start
        {
            get { return start; }
            set
            {
                start = value;
                OnPropertyChanged();
            }
        }
        public Point Finish
        {
            get { return finish; }
            set
            {
                finish = value;
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
