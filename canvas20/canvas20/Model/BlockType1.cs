using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace canvas20
{
    public class BlockType1 : Box
    {
        private decimal someField1;
        private decimal someField2;
        private decimal multiplay;
        private Visibility multivisibility;
        private bool isMultiplay = false;

        public bool IsMultiplay
        {
            get { return isMultiplay; }
            set
            {
                isMultiplay = value;
                OnPropertyChanged(nameof(IsMultiplay));
            }
        }
        public Visibility MultiVisibility
        {
            get { return multivisibility; }
            set
            {
                multivisibility = value;
                OnPropertyChanged(nameof(MultiVisibility));
            }
        }
        public decimal Multiplay
        {
            get { return multiplay; }
            set
            {
                multiplay = value;
                OnPropertyChanged(nameof(Multiplay));
            }
        }

        public decimal SomeField1
        {
            get => someField1;
            set
            {
                someField1 = value;
                OnPropertyChanged();
            }


        }
        public decimal SomeField2
        {
            get => someField2;
            set
            {
                someField2 = value;
                OnPropertyChanged();
            }


        }
        public void Multiplying()
        {
            Multiplay = SomeField1 * SomeField2;
        }
    }
}
