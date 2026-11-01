using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Project
{
    internal class Product
    {
        public int Id;
        public string Name;
        public string Barcode;
        public string SellPrice;
        public string QtyInstock;
        public string Photo;
        public string CategoryId;
        public DateTime CreateAt;
        public string CreateBy;
        public DateTime UpdateAt;
        public string UpdateBy;
        public int i;

        List<Product> product = new List<Product>();

        //Add Option
        public void AddProductInfor()
        {
            int n;
            Console.WriteLine("__________Add Prodcut Information----------");
            Console.Write("Input Number of ]Product: ");
            n = int.Parse(Console.ReadLine());
        again:
            for (i = 0; i < n; i++)
            {
                Product newProduct = new Product();

                Console.Write("ID: ");
                newProduct.Id = int.Parse(Console.ReadLine());

                bool dubplicate = false;
                for (int i = 0; i < product.Count; i++)
                {
                    if (newProduct.Id == product[i].Id)
                    {
                        dubplicate = true;
                        break;

                    }
                }
                if (dubplicate)
                {
                    Console.WriteLine("Duplicate please enter again.");
                    goto again;
                }


                Console.Write("Name: ");
                newProduct.Name = Console.ReadLine();

                Console.Write("Barcode: ");
                newProduct.Barcode = Console.ReadLine();

                Console.Write("Price: ");
                newProduct.SellPrice = Console.ReadLine();

                Console.Write("Qty Instock: ");
                newProduct.QtyInstock = Console.ReadLine();

                Console.Write("Photo: ");
                newProduct.Photo = Console.ReadLine();
            again1:
                Console.Write("Category Id: ");
                newProduct.CategoryId = Console.ReadLine();
                bool dubplicated = false;
                for (int i = 0; i < product.Count; i++)
                {
                    if (newProduct.CategoryId == product[i].CategoryId)
                    {
                        dubplicated = true;
                        break;

                    }
                }
                if (dubplicated)
                {
                    Console.WriteLine("Duplicate please enter again.");
                    goto again1;
                }


                Console.Write("Create At: ");
                Console.Write(DateTime.Now);
                Console.WriteLine();
                Console.Write("CreateBy: ");
                newProduct.CreateBy = Console.ReadLine();

                product.Add(newProduct);
            }
            Console.WriteLine("------------------------------------------");
        }


        //Show Option
        public void ShowProductInfor()
        {
            Console.WriteLine("__________Show Product Information----------");
            for (i = 0; i < product.Count; i++)
            {
                Console.WriteLine($"ID:{product[i].Id}");
                Console.WriteLine($"Full Name:{product[i].Name}");
                Console.WriteLine($"Barcode:{product[i].Barcode}");
                Console.WriteLine($"Price:{product[i].SellPrice}");
                Console.WriteLine($"Qty Instock:{product[i].QtyInstock}");
                Console.WriteLine($"Photo:{product[i].Photo}");
                Console.WriteLine($"Category ID:{product[i].CategoryId}");
                Console.WriteLine($"Create At:{product[i].CreateAt}");
                Console.WriteLine($"Create By:{product[i].CreateBy}");
            }
            Console.WriteLine("-----------------------------------------");
        }
            //Update Option
        public void UpdateProductInfor()
        {
            Console.WriteLine("__________Update Product Information-----------");
            Console.Write("Search by ID:");
            int SearchId = int.Parse(Console.ReadLine());
            bool check = false;
            for (i = 0; i < product.Count; i++)
            {
                if (product[i].Id == SearchId)
                {
                    check = true;
                    break;
                }
            }
            if (check)
            {
                Console.Write("Input New Name:");
                this.Name = Console.ReadLine();
                if (!(this.Name.Equals("")))
                {
                    product[i].Name = this.Name;
                }
                Console.Write("Input New Barcode:");
                this.Barcode = Console.ReadLine();
                if (!(this.Barcode.Equals("")))
                {
                    product[i].Barcode = this.Barcode;
                }
                Console.Write("Input New SellPrice:");
                this.SellPrice = Console.ReadLine();
                if (!(this.SellPrice.Equals("")))
                {
                    product[i].SellPrice = this.SellPrice;
                }
                Console.Write("Input New Qty Instock:");
                this.QtyInstock = Console.ReadLine();
                if (!(this.QtyInstock.Equals("")))
                {
                    product[i].QtyInstock = this.QtyInstock;
                }
                Console.Write("Input New Photo:");
                this.Photo = Console.ReadLine();
                if (!(this.Photo.Equals("")))
                {
                    product[i].Photo = this.Photo;
                }
            a:
                Console.Write("Input New CategoryId:");
                this.CategoryId = Console.ReadLine();
                bool dup = false;
                for (int i = 0; i < product.Count; i++)
                {
                    if (this.CategoryId == product[i].CategoryId)
                    {
                        dup = true;
                        break;

                    }
                }
                if (dup)
                {
                    Console.WriteLine("Duplicate please enter again.");
                    goto a;
                }
                if (!(this.CategoryId.Equals("")))
                {
                    product[i].CategoryId = this.CategoryId;
                }
                Console.Write("New CreateAt:");
                Console.Write(DateTime.Now);
                this.CreateAt = DateTime.Now;
                if (!(this.CreateAt.Equals("")))
                {
                    product[i].CreateAt = this.CreateAt;
                }
                Console.WriteLine();
                if (!(this.CreateAt.Equals("")))
                {
                    product[i].CreateAt = this.CreateAt;
                    Console.Write("Input New Create By:");
                    this.CreateBy = Console.ReadLine();
                    if (!(this.CreateBy.Equals("")))
                    {
                        product[i].CreateBy = this.CreateBy;
                    }
                    Console.Write($"Update At:{DateTime.Now}");
                    UpdateAt = DateTime.Parse(Console.ReadKey().ToString());
                    Console.WriteLine();
                    Console.Write("Update By:");
                    UpdateBy = Console.ReadLine();
                    Console.WriteLine("Product Information is Updated");
                }
                else
                {
                    Console.WriteLine("ID Not Found!");
                }

                Console.WriteLine("------------------------------------------");
            }
        }

        //Delete Option
        public void DeleteProductInfor()
        {
            Console.WriteLine("----------Delete Product Information-----------");
            Console.Write("Search ID to Delete: ");
            int SearchId = int.Parse(Console.ReadLine());
            bool check = false;
            for (i = 0; i < product.Count; i++)
            {
                if (product[i].Id == SearchId)
                {
                    check = true;
                    break;
                }
            }
            if (check)
            {
                product.RemoveAt(i);
                Console.WriteLine("Product Information is Deleted");
            }
            else
            {
                Console.WriteLine("ID Not Found!");
            }
            Console.WriteLine("----------------------------------------------");
        }

        //Search Option 
        public void SearchProductInfor()
        {
            Console.WriteLine("----------Search Product Information-----------");
            Console.Write("Search ID: ");
            int SearchId = int.Parse(Console.ReadLine());

            bool check = false;

            for (i = 0; i < product.Count; i++)
            {
                if (product[i].Id == SearchId)
                {
                    check = true;

                    Console.WriteLine($"ID:{product[i].Id}");
                    Console.WriteLine($"Full Name:{product[i].Name}");
                    Console.WriteLine($"Barcode:{product[i].Barcode}");
                    Console.WriteLine($"Price:{product[i].SellPrice}");
                    Console.WriteLine($"Qty Instock:{product[i].QtyInstock}");
                    Console.WriteLine($"Photo:{product[i].Photo}");
                    Console.WriteLine($"Category ID:{product[i].CategoryId}");
                    Console.WriteLine($"Create At:{product[i].CreateAt}");
                    Console.WriteLine();
                    Console.WriteLine($"Create By:{product[i].CreateBy}");

                    break;
                }
            }

            if (!check)
            {
                Console.WriteLine("ID Not Found!");
            }
            Console.WriteLine("-----------------------------------------------");
        }

        public void MenuItem()
        {
        Start:
            Console.WriteLine("----------Product Management ---------");
            Console.WriteLine("1.Add Product ");
            Console.WriteLine("2.Show Product ");
            Console.WriteLine("3.Update Product  ");
            Console.WriteLine("4.Delete Product  ");
            Console.WriteLine("5.Search Product ");
            Console.WriteLine("6.Exit");
            Console.WriteLine("----------------------------------------");
            int options;
            Console.Write(" Choose Option : ");
            options = int.Parse(Console.ReadLine());
            switch (options)
            {
                case 1:
                    this.AddProductInfor();
                    break;
                case 2:
                    this.ShowProductInfor();
                    break;
                case 3:
                    this.UpdateProductInfor();
                    break;
                case 4:
                    this.DeleteProductInfor();
                    break;
                case 5:
                    this.SearchProductInfor();
                    break;
                case 6:
                    return;
            }
            goto Start;

        }
    }
}

