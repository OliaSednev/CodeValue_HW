using System.Windows.Input;

namespace WiseBuyApplication.Models
{
    public class Product : ObservableObejct
    {
        #region Private Members

        private CommandHandler _increaseCountCommand;
        private CommandHandler _decreaseCountCommand;

        private int _productCount;
        private string _productPriceString;

        #endregion Private Members

        #region Delegates And Events

        public delegate void ProductAddedEventHandler(Product product);
        public delegate void ProductRemovedEventHandler(Product product);

        public event ProductAddedEventHandler ProductAdded;
        public event ProductRemovedEventHandler ProductRemoved;

        #endregion Delegates And Events

        #region Constructor

        public Product(string itemName, long itemCode)
        {
            ProductName = itemName;

            ProductCode = itemCode;
        }

        #endregion Constructor

        #region Properties

        public long ProductCode { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string ProductPriceString
        {
            get
            {
                return _productPriceString;
            }
            set
            {
                _productPriceString = value;
                OnPropertyChanged("ProductPriceString");
            }
        }

        public int ProductCount
        {
            get
            {
                return _productCount;
            }
            set
            {
                _productCount = value;
                OnPropertyChanged("ProductCount");
            }
        }

        #endregion Properties

        #region Commands

        public ICommand IncreaseCountCommand
        {
            get
            {
                return _increaseCountCommand ?? (_increaseCountCommand = new CommandHandler(() => IncreaseCount(), CanIncreaseCountCommand));
            }
        }

        public void IncreaseCount()
        {
            ProductCount++;

            ProductAdded?.Invoke(this);
        }

        private bool CanIncreaseCountCommand
        {
            get { return true; }
        }

        public ICommand DecreaseCountCommand
        {
            get
            {
                return _decreaseCountCommand ?? (_decreaseCountCommand = new CommandHandler(() => DecreaseCount(), CanDecreaseCountCommand));
            }
        }

        public void DecreaseCount()
        {
            if (ProductCount >= 1)
            {
                ProductCount--;
            }

            ProductRemoved?.Invoke(this);
        }

        private bool CanDecreaseCountCommand
        {
            get { return true; }
        }

        #endregion Commands
    }
}
