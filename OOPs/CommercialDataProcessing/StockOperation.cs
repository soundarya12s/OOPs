using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using OOPs.InventoryManagement;
using OOPs.StockAccountManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.CommercialDataProcessing
{
    public class StockOperations
    {
        List<StockDetails> CompanyStock = new List<StockDetails>();
        List<CustomerStock> CustomerStock = new List<CustomerStock>();


        public void ReadCustomerJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            CustomerStock = JsonConvert.DeserializeObject<List<CustomerStock>>(json);
            displayCustomerStock(CustomerStock);
        }
        public void ReadCompanyJson(string filePath)
        {


            var json = File.ReadAllText(filePath);
            CompanyStock = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            displayCompanyStock(CompanyStock);

        }

        public void displayCompanyStock(List<StockDetails> CompanyStock)
        {
            foreach (var data in CompanyStock)
            {
                Console.WriteLine("Stock:" + data.StockName + "\nNo Of Shares:" + data.NoOfShares + "\nShare Price:" + data.SharePrice+"\n");
            }

        }

        public void displayCustomerStock(List<CustomerStock> customerStock)
        {
            Console.WriteLine("Customer Stock: ");
            foreach (var data in customerStock)
            {
                Console.WriteLine("Stock Symbol:" + data.StockSymbol + " " + "No.of Shares:" + data.NoOfShares + " " + "Share Price:" + data.SharePrice);
            }
        }


        public void CustomerBuyStockFromCompany(int amount)
        {
            Console.WriteLine("Enter the stock name to buy");
            string stockName = Console.ReadLine();
            Console.WriteLine("Enter the No.of Shares");
            int shares = Convert.ToInt32(Console.ReadLine());
            StockDetails buyStock = new StockDetails();
            foreach (var data in CompanyStock)
            {
                if (data.StockName.Equals(stockName))
                {
                    buyStock = data;
                    if (data.NoOfShares >= shares && data.NoOfShares * shares >= amount)
                    {
                        data.NoOfShares -= shares;
                        amount -= data.NoOfShares * shares;
                    }
                    else
                    {
                        Console.WriteLine("Stock limit exceeded");
                    }
                }
            }
            if (buyStock == null)
                Console.WriteLine("Stock Name doesnt exists");
            else
            {
                CustomerStock buyCustomerStock = new CustomerStock();
                foreach (var stock in CustomerStock)
                {
                    if (stock.StockSymbol.Equals(stockName))
                    {
                        buyCustomerStock = stock;
                        stock.NoOfShares += shares;
                    }
                    else
                    {
                        buyCustomerStock.StockSymbol = stockName;
                        buyCustomerStock.NoOfShares = shares;
                        buyCustomerStock.SharePrice = buyStock.SharePrice;
                    }
                }
                CustomerStock.Add(buyCustomerStock);
            }
        }

      public void CustomerSellStock (int amount)
        {
            Console.WriteLine("Enter the stock name to buy");
            string stockName = Console.ReadLine();
            Console.WriteLine("Enter the No.of Shares");
            int shares = Convert.ToInt32(Console.ReadLine());
            CustomerStock buyStock = new CustomerStock();
            foreach (var data in CustomerStock)
            {
                if (data.StockSymbol.Equals(stockName))
                {
                    buyStock = data;
                    if (data.NoOfShares >= shares && data.NoOfShares * shares >= amount)
                    {
                        data.NoOfShares -= shares;
                        amount -= data.NoOfShares * shares;
                    }
                    else
                    {
                        Console.WriteLine("Stock limit exceeded");
                    }
                }
            }
            if (buyStock == null)
                Console.WriteLine("Stock Name doesnt exists");
            else
            {
                StockDetails buyCustomerStock = new StockDetails();
                foreach (var stock in CompanyStock)
                {
                    if (stock.StockName.Equals(stockName))
                    {
                        buyCustomerStock = stock;
                        stock.NoOfShares += shares;
                    }
                    else
                    {
                        buyCustomerStock.StockName = stockName;
                        buyCustomerStock.NoOfShares = shares;
                        buyCustomerStock.SharePrice = buyStock.SharePrice;
                    }
                }
                CompanyStock.Add(buyCustomerStock);
            }
        } 
        public void WriteToCompanyFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(CompanyStock);
            File.WriteAllText(filePath, json);
        }
        public void WriteToCustomerFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(CustomerStock);
            File.WriteAllText(filePath, json);
        }
    }
}
