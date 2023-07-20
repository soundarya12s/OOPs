using Newtonsoft.Json;
using System;
namespace OOPs.DataInventoryManagement
{
    public class InventoryDetailsOperation
    {
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            List<InventoryDetails> list = JsonConvert.DeserializeObject<List<InventoryDetails>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.Name + " " + data.Weight + " " + data.PricePerKg); ;
            }
        }
    }
}