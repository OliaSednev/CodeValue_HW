using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_WPFapp
{
    class ContactViewModel : ObservableObejct
    {
        private string _item;
        private string _price;

        public string Name
        {
            get { return _item; }
            set
            {
                if (value == _item) return;
                _item = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _price; }
            set
            {
                if (value == _price) return;
                _price = value;
                OnPropertyChanged();
            }
        }
    }
}
