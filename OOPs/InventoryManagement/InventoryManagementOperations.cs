using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.InventoryManagement
{
    public class InventoryManagementDetailsOperation
    {
        InventoryManagementDetails list;
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            list = JsonConvert.DeserializeObject<InventoryManagementDetails>(json);

            Display(list.RiceList);
            Display(list.WheatList);
            Display(list.PulsesList);


        }
        public void AddInventoryManagement(string objectName, string filePath)
        {

            //list.RiceList.Add(details);
            var json = File.ReadAllText(filePath);
            list = JsonConvert.DeserializeObject<InventoryManagementDetails>(json);

            InventoryDetails details = new InventoryDetails()
            {
                Name = Console.ReadLine(),
                Weight = Convert.ToInt32(Console.ReadLine()),
                PricePerKg = Convert.ToInt32(Console.ReadLine()),
            };

            if (objectName.ToLower().Equals("rice"))
            {

                list.RiceList.Add(details);
                Console.WriteLine("Added Rice");

            }
            else if (objectName.ToLower().Equals("wheat"))
            {

                list.RiceList.Add(details);
                Console.WriteLine("added wheat");
            }
            else if (objectName.ToLower().Equals("pulses"))
            {
                list.RiceList.Add(details);
                Console.WriteLine("added pulses");
            }




        }
        public void WriteToJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, json);

        }
        public void Display(List<InventoryDetails> list)
        {
            foreach (var data in list)
            {

                Console.WriteLine(data.Name + " " + data.Weight + " " + data.PricePerKg); ;
            }
        }

        public void DeleteInventoryManagement(string ObjectName, string inventoryName)
        {
            InventoryDetails details = new InventoryDetails();
            if (ObjectName.ToLower().Equals("rice"))
            {
                foreach (var data in list.RiceList)
                {
                    if (data.Name.Equals(inventoryName))
                    {
                        details = data;
                    }

                }
                if (details != null)
                {
                    list.RiceList.Remove(details);
                }
                Console.WriteLine("Deleted! Write to Json to update..");
            }
            if (ObjectName.ToLower().Equals("wheat"))
            {
                foreach (var data in list.WheatList)
                {
                    if (data.Name.Equals(inventoryName))
                    {
                        details = data;
                    }

                }
                if (details != null)
                {
                    list.WheatList.Remove(details);
                }

            }
            if (ObjectName.ToLower().Equals("pulses"))
            {
                foreach (var data in list.PulsesList)
                {
                    if (data.Name.Equals(inventoryName))
                    {
                        details = data;
                    }

                }
                if (details != null)
                {
                    list.PulsesList.Remove(details);
                }

            }
            if (details == null)
                Console.WriteLine("No inventory details exists");
        }
    }
}
