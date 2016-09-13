using System.Collections.ObjectModel;

namespace WiseBuyApplication.Models
{
    public class ChainShoppingCart : ObservableObejct
    {
        #region Private Members

        private double _totalPrice;

        #endregion Private Members

        #region Constructor

        public ChainShoppingCart()
        {
            Products = new ObservableCollection<Product>();
        }

        #endregion Constructor

        #region Properties

        public string ChainName { get; set; }

        public long ChainId { get; set; }

        public ObservableCollection<Product> Products { get; set; }

        public double TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        #endregion Properties
    }
}
