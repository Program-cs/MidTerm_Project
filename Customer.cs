using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Project
{
    internal class Customer
    {
        public int Id;
        public string Name;
        public string Gender;
        public string Tel;
        public string Address;
        public List<Customer> customers = new List<Customer>();
        public void MenuItem()
        {
        start:
            Console.WriteLine("--------------------Customer Management-------------------------");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Show customer");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. Delete Customer");
            Console.WriteLine("5. Search Customer");
            Console.WriteLine("6. Back home");
            int option;
            Console.Write("Choose Option:");
            option = int.Parse(Console.ReadLine());
            if (option < 1 || option > 6)
            {
                Console.WriteLine("Invalid option! Please try again.");
            }
            switch (option)
            {
                case 1:
                    AddRole();
                    break;
                case 2:
                    ShowRole();
                    break;
                case 3:
                    UpdateRole();
                    break;
                case 4:
                    DeleteRole();
                    break;
                case 5:
                    SearchRole();
                    break;
                case 6:
                    return;
            }
            goto start;
        }
        public void AddRole()
        {
            Console.WriteLine("----------------1.Add Customer-------------------");
        add:
            Customer s = new Customer();
            Console.Write("Id:");
            s.Id = int.Parse(Console.ReadLine());
            if (s.Id != customers.Count)
            {

                Console.Write("Name:");
                s.Name = Console.ReadLine();
                Console.Write("Gender:");
                s.Gender = Console.ReadLine();
                Console.Write("Tel:");
                s.Tel = Console.ReadLine();
                Console.Write("Address:");
                s.Address = Console.ReadLine();
                customers.Add(s);
            }
            else
            {
                Console.WriteLine("Input Id again");
                goto add;
            }
        }
        public void ShowRole()
        {
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("---------------------2.Show Customer------------------------");
                Console.WriteLine($"Id:{customers[i].Id}");
                Console.WriteLine($"Name:{customers[i].Name}");
                Console.WriteLine($"Gender:{customers[i].Gender}");
                Console.WriteLine($"Tel:{customers[i].Tel}");
                Console.WriteLine($"Address:{customers[i].Address}");
            }


        }
        public void UpdateRole()
        {
            Console.WriteLine("--------------------------2.Update Customer-----------------------");
            if (customers.Count == 0)
            {
                Console.WriteLine(" not found!");
            }
            Console.Write("Search by Id:");
            int UpdateId;
            UpdateId = int.Parse(Console.ReadLine());
            for (int i = 0; i < customers.Count; i++)
            {

                bool Ischeacked = false;
                if (customers[i].Id == UpdateId)
                {

                    Ischeacked = true;
                    Console.Write("Name:");
                    customers[i].Name = Console.ReadLine();
                    Console.Write("Gender:");
                    customers[i].Gender = Console.ReadLine();
                    Console.Write("Tel:");
                    customers[i].Tel = Console.ReadLine();
                    Console.Write("Address:");
                    customers[i].Address = Console.ReadLine();
                    break;
                }
                if (!Ischeacked)
                {
                    Console.WriteLine("Not found Id!");
                }

            }
        }
        public void DeleteRole()
        {
            Console.WriteLine("-----------------3.Delete Customer------------------");
            if (customers.Count == 0)
            {
                Console.WriteLine(" not found!");
            }
            Console.Write("Search by Id:");
            int DeleteId;
            DeleteId = int.Parse(Console.ReadLine());
            for (int i = 0; i < customers.Count; i++)
            {

                bool Ischeacked = false;
                if (customers[i].Id == DeleteId)
                {
                    Ischeacked = true;
                    customers.RemoveAt(i);
                    Console.WriteLine(" remove successfuly!");
                    break;
                }
                if (!Ischeacked)
                {
                    Console.WriteLine("Not found Id!");
                }

            }
        }
        public void SearchRole()
        {
            Console.WriteLine("-------------5.Search Customer-----------------");
            if (customers.Count == 0)
            {
                Console.WriteLine("not found!");
            }
            Console.Write("Search by Id:");
            int SearchId;
            SearchId = int.Parse(Console.ReadLine());
            bool Ischeacked = false;
            for (int i = 0; i < customers.Count; i++)
            {

                if (customers[i].Id == SearchId)
                {

                    Console.WriteLine($"Id:{customers[i].Id}");
                    Console.WriteLine($"Name:{customers[i].Name}");
                    Console.WriteLine($"Gender:{customers[i].Gender}");
                    Console.WriteLine($"Tel:{customers[i].Tel}");
                    Console.WriteLine($"Address:{customers[i].Address}");
                    break;
                }
                if (!Ischeacked)
                {
                    Console.WriteLine("Not found Id!");
                }
            }

        }
        public void Back()
        {
            Environment.Exit(0);
        }

    }
}
