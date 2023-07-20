using OOPs.DataInventoryManagement;
using System;
namespace OOPs
{
    class Program
    {
        static string INVENTORY_DETAILS_FILE = @"D:\gittestrep\OOPs\OOPs\DataInventoryManagement\InventoryData.json";
        public static void Main(string[] args)
        {
            InventoryDetailsOperation inventory = new InventoryDetailsOperation();
            inventory.ReadInventoryJson(INVENTORY_DETAILS_FILE);

        }
    }
}