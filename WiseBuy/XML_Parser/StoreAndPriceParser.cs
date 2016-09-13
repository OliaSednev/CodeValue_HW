using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Xml.Linq;
using DbCreator;
using InterfaceXmlToDb;

namespace XML_Parser
{
    public class StoreAndPriceParser : IXmlManager
    {
        #region StoreXmlFile
        public void LoadStoreXmlDataToDb(Chain chain, IEnumerable<Store> stores)
        {
            using (SuperMarketDb context = new SuperMarketDb())
            {
                context.Chains.AddOrUpdate(chain);
                context.SaveChanges();

                foreach (var store in stores)
                {
                    context.Stores.AddOrUpdate(s => new { s.StoreId, s.ChainId }, store);
                    context.SaveChanges();
                }
            }
        }

        public void ParseStoreXmlFile(XDocument doc)
        {
            var chain = new Chain();
            long chainId = long.Parse(doc.Root.Element("ChainId").Value);
            string chainName = doc.Root.Element("ChainName").Value;
            chain.ChainId = chainId;
            chain.ChainName = chainName;

            var stores = doc.Descendants("StoreId")
                .Select(storeElement => storeElement.Parent)
                .Select(store => new Store
                {
                    ChainId = chainId,
                    StoreId = long.Parse(store.Element("StoreId").Value),
                    StoreName = store.Element("StoreName").Value,
                    Address = store.Element("Address").Value,
                    City = store.Element("City").Value
                });
            LoadStoreXmlDataToDb(chain, stores);
        }
        #endregion StoreXmlFile

        #region PriceXmlFile
        public void ParsePriceXmlFiles(XDocument doc)
        {
            long storeID = long.Parse(doc.Root.Element("StoreId").Value);
            long chainID = long.Parse(doc.Root.Element("ChainId").Value);

            var itemsData = from item in doc.Descendants("ItemCode")
                .Select(priceElement => priceElement.Parent)
                            where long.Parse(item.Element("ItemCode").Value) > 99999999
                            select ParseElements
                                (
                                    storeID,
                                    chainID,
                                    long.Parse(item.Element("ItemCode").Value),
                                    item.Element("ItemType").Value,
                                    item.Element("ItemName").Value,
                                    item.Element("ManufacturerItemDescription").Value,
                                    item.Element("UnitQty").Value,
                                    item.Element("Quantity").Value,
                                    item.Element("bIsWeighted").Value,
                                    double.Parse(item.Element("ItemPrice").Value)
                                );
            itemsData.ToList();
        }

        private bool ParseElements(long storeID, long chainID, long itemId, string itemType, string itemName,
            string itemDescription, string unitQuantity, string quantity, string isWeighted, double itemPrice)
        {
            using (SuperMarketDb context = new SuperMarketDb())
            {
                Item item = CreateItem(context, itemId, itemType, itemName, itemDescription);
                CreatePrice(context, item, storeID, chainID, unitQuantity, quantity, isWeighted, itemPrice);
            }
            return true;
        }

        private Item CreateItem(SuperMarketDb context, long itemId, string itemType, string itemName, string itemDescription)
        {
            Item item = new Item()
            {
                ItemId = itemId,
                ItemName = itemName,
                ItemType = itemType,
                ItemDescription = itemDescription
            };
            if (context.Items.Find(item.ItemId) != null) return item;
            context.Items.AddOrUpdate(i => i.ItemId, item);
            context.SaveChanges();

            return item;
        }

        private void CreatePrice(SuperMarketDb context, Item item, long storeID, long chainID, string unitQuantity, string quantity,
            string isWeighted, double itemPrice)
        {
            Price price = new Price();
            price.ItemPrice = itemPrice;
            price.UnitQuantity = unitQuantity;
            price.Quantity = quantity;
            price.IsWeighted = isWeighted;

            price.Item = context.Items.Find(item.ItemId);
            price.Store = context.Stores.Find(storeID, chainID);

            context.Prices.Add(price);
            context.SaveChanges();
        }
        #endregion PriceXmlFile

        #region ClearDb
        public void ClearDb()
        {
            using (var context = new SuperMarketDb())
            {
                try
                {
                    context.Chains.RemoveRange(context.Chains);
                    context.Stores.RemoveRange(context.Stores);
                    context.Items.RemoveRange(context.Items);
                    context.Prices.RemoveRange(context.Prices);

                    context.SaveChanges();
                }

                catch (Exception e)
                {
                    Console.WriteLine("Removing Db has failed!!!" + e.Message);
                }
            }
        }
        #endregion ClearDb
    }
}
