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
        private int _idValue = 1;
        private Box _selectedBox;
        private ObservableCollection<Box> _boxes = new ObservableCollection<Box>();

        public int IdValue
        {
            get { return _idValue; }
            set
            {
                _idValue++;
                OnPropertyChanged("IdValue");
            }
        }
        public Box SelectedBox
        {
            get { return _selectedBox; }
            set
            {
                _selectedBox = value;
                OnPropertyChanged("SelectedBox");
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
                  //SelectedBox = new Box();
                  //SelectedBox.Id = IdValue;
                  //SelectedBox.Margin += IdValue*55;
                  //SelectedBox.Size += IdValue*10;
                  SelectedBox = new Box {Id = IdValue, Margin = IdValue*25, Size = 20 };
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
