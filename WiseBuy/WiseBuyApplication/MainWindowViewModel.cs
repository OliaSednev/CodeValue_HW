using DbCreator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using WiseBuyApplication.Models;

namespace WiseBuyApplication
{
    public class MainWindowViewModel : ObservableObejct
    {
        #region Private Members

        private ObservableCollection<ChainShoppingCart> _chainShoppingCarts;

        #endregion Private Members

        #region Constructor

        public MainWindowViewModel()
        {
            UpdateCollections();
        }
        #endregion Constructor

        #region Collection Properties

        public ObservableCollection<Chain> Chains { get; set; }

        public ObservableCollection<ChainShoppingCart> ChainShoppingCarts
        {
            get
            {
                return _chainShoppingCarts;
            }
            set
            {
                _chainShoppingCarts = value;
                OnPropertyChanged("ChainShoppingCarts");
            }
        }

        public ObservableCollection<Chain3Items> MostExpensive3Items { get; set; }

        public ObservableCollection<Chain3Items> Cheapest3Items { get; set; }

        public ObservableCollection<Product> Products { get; set; }

        private ObservableCollection<Price> Prices { get; set; }

        #endregion Collections Properties

        #region Private Methods

        private void RemoveProduct(Product product)
        {
            foreach (ChainShoppingCart chainShoppingCart in ChainShoppingCarts)
            {
                Product deletedProduct = chainShoppingCart.Products.FirstOrDefault(x => x.ProductCode == product.ProductCode);

                if (deletedProduct != null)
                {
                    Price priceInChain = Prices.FirstOrDefault(x => x.Store.Chain.ChainId == chainShoppingCart.ChainId && x.Item.ItemId == deletedProduct.ProductCode);

                    if (priceInChain != null)
                    {
                        deletedProduct.ProductPrice -= priceInChain.ItemPrice;
                        deletedProduct.ProductPriceString = deletedProduct.ProductPrice.ToString();
                        chainShoppingCart.TotalPrice -= priceInChain.ItemPrice;
                    }

                    if (product.ProductCount == 0)
                    {
                        chainShoppingCart.Products.Remove(deletedProduct);
                    }
                }
            }
        }

        private void UpdateProductPriceInShoppingCart(Product chainProduct, ChainShoppingCart chainShoppingCart)
        {
            Price priceInChain = Prices.FirstOrDefault(x => x.Store.Chain.ChainId == chainShoppingCart.ChainId && x.Item.ItemId == chainProduct.ProductCode);

            if (priceInChain != null)
            {
                chainProduct.ProductPrice = priceInChain.ItemPrice * chainProduct.ProductCount;
                chainProduct.ProductPriceString = chainProduct.ProductPrice.ToString();
                chainShoppingCart.TotalPrice += priceInChain.ItemPrice;
            }
            else
            {
                chainProduct.ProductPrice = 0;
                chainProduct.ProductPriceString = "לא קיים ברשת";
            }
        }

        private void AddProduct(Product product)
        {
            foreach (ChainShoppingCart chainShoppingCart in ChainShoppingCarts)
            {
                Product updatedProduct = chainShoppingCart.Products.FirstOrDefault(x => x.ProductCode == product.ProductCode);

                if (updatedProduct == null)
                {
                    //If product isn't included - add it to the chain shopping cart
                    updatedProduct = new Product(product.ProductName, product.ProductCode);

                    updatedProduct.ProductCount = 1;

                    chainShoppingCart.Products.Add(updatedProduct);
                }
                else
                {
                    updatedProduct.ProductCount = product.ProductCount;
                }

                UpdateProductPriceInShoppingCart(updatedProduct, chainShoppingCart);
            }
        }

        private void UpdateCollections()
        {
            try
            {
                ChainShoppingCarts = new ObservableCollection<ChainShoppingCart>();

                using (SuperMarketDb context = new SuperMarketDb())
                {
                    Chains = new ObservableCollection<Chain>(context.Chains);

                    CreateProducts(context.Items);

                    Prices = new ObservableCollection<Price>(context.Prices);

                    FindMostExpensiveAndCheapestItems();
                }

                foreach (Chain chain in Chains)
                {
                    ChainShoppingCarts.Add(new ChainShoppingCart { ChainName = chain.ChainName, ChainId = chain.ChainId });
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error occured in the application: " + exception.Message);
            }
        }

        private void CreateProducts(DbSet<Item> Items)
        {
            Products = new ObservableCollection<Product>();

            foreach (Item item in Items)
            {
                Product product = new Product(item.ItemName, item.ItemId);

                Products.Add(product);

                product.ProductAdded += Product_ProductAdded;

                product.ProductRemoved += Product_ProductRemoved;
            }
        }

        private void Product_ProductRemoved(Product product)
        {
            RemoveProduct(product);
        }

        private void Product_ProductAdded(Product product)
        {
            AddProduct(product);
        }

        private void FindMostExpensiveAndCheapestItems()
        {
            MostExpensive3Items = new ObservableCollection<Chain3Items>();

            Cheapest3Items = new ObservableCollection<Chain3Items>();

            foreach (Chain chain in Chains)
            {
                var topItems = Prices.Where(x => x.Store.ChainId == chain.ChainId).OrderByDescending(y => y.ItemPrice).Take(3);

                List<string> topItemsList = new List<string>(topItems.Select(x => x.Item.ItemName));

                MostExpensive3Items.Add(new Chain3Items { ChainName = chain.ChainName, Ordered3Items = topItemsList });

                var cheapestItems = Prices.Where(x => x.Store.ChainId == chain.ChainId).OrderBy(y => y.ItemPrice).Take(3);

                List<string> cheapestItemsList = new List<string>(cheapestItems.Select(x => x.Item.ItemName));

                Cheapest3Items.Add(new Chain3Items { ChainName = chain.ChainName, Ordered3Items = cheapestItemsList });
            }
        }

        #endregion Private Methods
    }
}