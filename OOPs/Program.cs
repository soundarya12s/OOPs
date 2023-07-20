using OOPs.DataInventoryManagement;
using OOPs.InventoryManagement;
using System;
namespace OOPs
{
    class Program
    {
        static string INVENTORY_DETAILS_FILE = @"D:\gittestrep\OOPs\OOPs\DataInventoryManagement\InventoryData.json";
        static string INVENTORY_MANAGEMENT_FILE = @"D:\gittestrep\OOPs\OOPs\InventoryManagement\InventoryDataManagementData.json";
        public static void Main(string[] args)
        {
            //InventoryDetailsOperation inventory = new InventoryDetailsOperation();
            //inventory.ReadInventoryJson(INVENTORY_DETAILS_FILE);
            InventoryManagementDetailsOperation management = new InventoryManagementDetailsOperation();
            bool flag = true;
            Console.WriteLine("1.Read Inventory(display)\n2.Add to inventory\n3.Write to json\n4.delete\n5.Exit");

            while (flag)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        management.ReadInventoryJson(INVENTORY_MANAGEMENT_FILE);
                        break;
                    case 2:
                        Console.WriteLine("Enter where you want to add:");
                        string str = Console.ReadLine();
                        management.AddInventoryManagement(str, INVENTORY_MANAGEMENT_FILE);
                        break;
                    case 3:
                        management.WriteToJsonFile(INVENTORY_MANAGEMENT_FILE);
                        Console.WriteLine("Added to Json");
                        break;
                    case 4:
                        Console.WriteLine("Enter from where you want to delete:");
                        string objName = Console.ReadLine();
                        Console.WriteLine("Enter name to delete:");
                        string InventoryName = Console.ReadLine();
                        management.DeleteInventoryManagement(objName, InventoryName);
                        break;
                    case 5:
                        flag = false;
                        break;


                }
            }
        }
    }
}