using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace canvas3
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int _idValue = 0;
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

        //public ViewModel()
        //{
        //    _selectedBox = new Box {Id = IdValue, Size = 55 };
        //    Boxes.Add(_selectedBox);
        //}

        private ICommand _addBox;

        public ICommand AddBox
        {
            get
            {
                return _addBox ?? (_addBox = new RelayCommand(() =>
              {
                  SelectedBox = new Box();
                  SelectedBox.Id = IdValue;
                  SelectedBox.Margin += IdValue*10;
                  SelectedBox.Size += IdValue;
                  Boxes.Insert(0, SelectedBox);
                  IdValue++;
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
