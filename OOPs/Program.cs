using OOPs.DataInventoryManagement;
using OOPs.InventoryManagement;
using OOPs.StockAccountManagement;
using System;
using System.Net.Http.Headers;

namespace OOPs
{
    class Program
    {
        static string INVENTORY_DETAILS_FILE = @"D:\gittestrep\OOPs\OOPs\DataInventoryManagement\InventoryData.json";
        static string INVENTORY_MANAGEMENT_FILE = @"D:\gittestrep\OOPs\OOPs\InventoryManagement\InventoryDataManagementData.json";
        static string STOCK_MANAGEMENT_FILE = @"D:\gittestrep\OOPs\OOPs\StockAccountManagement\CompanyStock.json";
        public static void Main(string[] args)
        {
            InventoryDetailsOperation inventory = new InventoryDetailsOperation();
            
           
            StockOperation stock = new StockOperation();
            bool flag = true;


            Console.WriteLine("Choose: \n1.Inventory details\n2.Inventory Management\n3.Stock\n4.Exit");

            while (flag)
            {
                int choice1=Convert.ToInt32(Console.ReadLine());
             
                switch (choice1)
                {
                    case 1:
                        inventory.ReadInventoryJson(INVENTORY_DETAILS_FILE);
                        break;
                    case 2:
                        bool flag2 = true;
                        InventoryManagementDetailsOperation management = new InventoryManagementDetailsOperation();
                        while (flag2)
                        {
                            Console.WriteLine("1.read files\n2.add values\n3.Write to json\n4.delete Value\n5.Edit");
                            int choice2 = Convert.ToInt32(Console.ReadLine());

                            switch (choice2)
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
                                    Console.WriteLine("Enter from where you want to edit");
                                    objName = Console.ReadLine();
                                    Console.WriteLine("Enter name to edit:");
                                    InventoryName = Console.ReadLine();
                                    management.EditValue(objName, InventoryName);
                                    break;
                                case 6:
                                    flag2 = false;
                                    break;

                            }
                        }
                        break;
                    case 3:
                        stock.ReadStockJson(STOCK_MANAGEMENT_FILE);
                        break;
                      
                    case 4:
                        flag = false;
                        break;


                }
            }
        }
    }
}