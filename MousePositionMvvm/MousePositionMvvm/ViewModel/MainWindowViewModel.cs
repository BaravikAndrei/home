using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MousePositionMvvm
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private double _panelX;
        private double _panelY;

        public double PanelX
        {
            get { return _panelX; }
            set
            {
                if (value.Equals(_panelX)) return;
                _panelX = value;
                OnPropertyChanged();
            }
        } 

        public double PanelY
        {
            get { return _panelY; }
            set
            {
                if (value.Equals(_panelY)) return;
                _panelY = value;
                OnPropertyChanged();
            }
        }

        private int _idValue = 1;
        private Box _selectedBox;
        private ObservableCollection<Box> _boxes = new ObservableCollection<Box>();

        public int IdValue
        {
            get { return _idValue; }
            set
            {
                _idValue++;
                OnPropertyChanged();
            }
        }
        public Box SelectedBox
        {
            get { return _selectedBox; }
            set
            {
                _selectedBox = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Box> Boxes
        {
            get { return _boxes; }
            set
            {
                _boxes = value;
                OnPropertyChanged();
            }
        }

        private ICommand _addBox;

        public ICommand AddBox
        {
            get
            {
                return _addBox ?? (_addBox = new RelayCommand(() =>
                {
                    SelectedBox = new Box { Id = IdValue, Margin = IdValue * 50, Size = 25, CanvasLeft = IdValue*20, CanvasTop =0};
                    Boxes.Add(SelectedBox);
                    IdValue++;
                }));
            }
        }

        private ICommand _drag;

        public ICommand Drag
        {
            get
            {
                return _drag ?? (_drag = new RelayCommand(() =>
                {
                    foreach (Box b in Boxes)
                    {
                        b.CanvasLeft +=20;
                        b.CanvasTop += 20;
                    }
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}