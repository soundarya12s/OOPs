using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using OOPs.InventoryManagement;
using System;
using System.Collections.Generic;

namespace OOPs.StockAccountManagement
{
    public class StockOperation
    {
          InventoryManagementDetails list;
        public void ReadStockJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            List<StockDetails> list = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.StockName + " " + data.NoOfShares + " " + data.SharePrice);
            }
        }
       

    }
}

