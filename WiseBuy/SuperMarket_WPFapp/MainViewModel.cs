using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_WPFapp
{
    class MainViewModel : ObservableObejct
    {
        public ObservableCollection<ICommandEx> Commands { get; }
        public ObservableCollection<object> ItemsCollection { get; }
    }
}
