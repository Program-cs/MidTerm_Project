using System;
using System.Collections.Generic;

namespace Add_Stock
{
    internal class AddStock
    {
        // Fields
        private string id;
        private string supplierId;
        private string productId;
        private int qty;
        private double cost;
        private double total;
        private DateTime createAt;
        private string createBy;
        private DateTime? updateAt;
        private string updateBy;

        // Store stock information
        private static List<AddStock> addStocks = new List<AddStock>();

        // Constructor
        // Constructor ទទេ
        public AddStock()
        { }
        public AddStock(string id, string supplierId,
                        string productId, int qty,
                        double cost, string createBy)
        {
            this.id = id;
            this.supplierId = supplierId;
            this.productId = productId;
            this.qty = qty;
            this.cost = cost;
            this.total = qty * cost;
            this.createAt = DateTime.Now;
            this.createBy = createBy;
            this.updateAt = null;
            this.updateBy = null;
        }
 
        // Find stock by ID
        public static AddStock FindById(string id)
        {
            foreach (AddStock stock in addStocks)
            {
                if (stock.id == id)
                {
                    return stock;
                }
            }

            return null;
        }

        // Add new stock
        public static void AddNewStock()
        {
            Console.WriteLine("\n---------- Add New Stock ----------");

            Console.Write("Input Stock Id : ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Stock ID cannot be empty!");
                return;
            }

            if (FindById(id) != null)
            {
                Console.WriteLine("Stock ID already exists!");
                return;
            }

            Console.Write("Input Supplier Id : ");
            string supplierId = Console.ReadLine();

            Console.Write("Input Product Id : ");
            string productId = Console.ReadLine();

            int qty;
            Console.Write("Input Quantity : ");

            while (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
            {
                Console.Write("Invalid quantity! Enter again : ");
            }

            double cost;
            Console.Write("Input Cost : ");

            while (!double.TryParse(Console.ReadLine(), out cost) || cost < 0)
            {
                Console.Write("Invalid cost! Enter again : ");
            }

            Console.Write("Input Create By : ");
            string createBy = Console.ReadLine();

            // Create stock using constructor
            AddStock stock = new AddStock(
                id, supplierId, productId, qty, cost, createBy
            );

            addStocks.Add(stock);

            Console.WriteLine("\nStock added successfully!");
        }

        // Print stock information
        public static void PrintAddStock(AddStock stock)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Stock ID    : " + stock.id);
            Console.WriteLine("Supplier ID : " + stock.supplierId);
            Console.WriteLine("Product ID  : " + stock.productId);
            Console.WriteLine("Quantity    : " + stock.qty);
            Console.WriteLine("Cost        : " + stock.cost);
            Console.WriteLine("Total       : " + stock.total);
            Console.WriteLine("Create At   : " + stock.createAt);
            Console.WriteLine("Create By   : " + stock.createBy);
            Console.WriteLine("Update At   : " +
                (stock.updateAt.HasValue
                    ? stock.updateAt.ToString()
                    : "N/A"));
            Console.WriteLine("Update By   : " +
                (stock.updateBy ?? "N/A"));
            Console.WriteLine("------------------------------------------");
        }

        // Show all stock information
        public static void ShowStockInformation()
        {
            Console.WriteLine("\n---------- Stock Information ----------");

            if (addStocks.Count == 0)
            {
                Console.WriteLine("No stock information found!");
                return;
            }

            foreach (AddStock stock in addStocks)
            {
                PrintAddStock(stock);
            }
        }

        // Search stock by ID
        public static void SearchStock()
        {
            Console.WriteLine("\n---------- Search Stock ----------");

            Console.Write("Input Stock Id : ");
            string id = Console.ReadLine();

            AddStock stock = FindById(id);

            if (stock == null)
            {
                Console.WriteLine("Stock not found!");
            }
            else
            {
                PrintAddStock(stock);
            }
        }
        public void MenuItem()
        {
            int option = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("             ADD STOCK MANAGEMENT");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Add Stock");
                Console.WriteLine("2. Show Stock");
                Console.WriteLine("3. Search Stock");
                Console.WriteLine("4. Back to Main Option");
                Console.WriteLine("==============================================");

                Console.Write("Please choose option: ");

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option! Please enter a number.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        AddNewStock();
                        break;

                    case 2:
                        ShowStockInformation();
                        break;

                    case 3:
                        SearchStock();
                        break;

                    case 4:
                        Console.WriteLine("Back to Main Option...");
                        break;

                    default:
                        Console.WriteLine("Invalid option! Please choose 1-4.");
                        break;
                }

                if (option != 4)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

            } while (option != 4);
        }
    }
}