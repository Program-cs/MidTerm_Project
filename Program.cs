using Add_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<LoginUser> users = new List<LoginUser>

            { new LoginUser("Admin", "admin123"),
              new LoginUser("Vatta", "vatta123")
            };

        again:
            Console.WriteLine("————————Log In System———————-");
            Console.Write("User Name : ");
            string username = Console.ReadLine();
            Console.Write("Password  : ");
            string password = Console.ReadLine();

            bool isLoggedIn = false;
            string loggedInUser = "";

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName.ToLower() == username.ToLower() && users[i].Password == password)
                {
                    isLoggedIn = true;
                    loggedInUser = users[i].UserName;
                    break;
                }
            }

            if (isLoggedIn)
            {
                Console.WriteLine("\nLogin Successful!\n");
                ShowMainMenu(loggedInUser);
            }
            else
            {
                Console.WriteLine("\nInvalid Username or Password.");
                goto again;
            }
        }
        

        
       

        static void ShowMainMenu(string currentUser)
        {
            int option = 0;
            do
            {
                Console.WriteLine("——————POS System—————————");

                if (currentUser.ToLower() == "admin")
                {
                    Console.WriteLine("1. User Management");
                    Console.WriteLine("2. Role Management");
                    Console.WriteLine("3. Product Management");
                    Console.WriteLine("4. Category Management");
                    Console.WriteLine("5. Supplier Management");
                    Console.WriteLine("6. Add Stock Management");
                    Console.WriteLine("7. Customer Management");
                    Console.WriteLine("8. Exit");
                    Console.WriteLine("—————————————————————");
                    Console.Write("Please choose option: ");

                    option = int.Parse(Console.ReadLine());
                }


                if (currentUser.ToLower() == "vatta")
                {
                    Console.WriteLine("1. Product Management");
                    Console.WriteLine("2. Category Management");
                    Console.WriteLine("3. Supplier Management");
                    Console.WriteLine("4. Add Stock Management");
                    Console.WriteLine("5. Customer Management");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("—————————————————————");
                    Console.Write("Please choose option: ");

                    option = int.Parse(Console.ReadLine());
                }

                switch (option)
                {
                    case 1:
                        User user = new User();
                        user.MenuItem();
                        break;
                    case 2:
                        Role role = new Role();
                        role.MenuItem();
                        break;
                    case 3:
                        Product product = new Product();
                        product.MenuItem();
                        break;
                    case 4:
                        Category category = new Category();
                        category.MenuItem();
                        break;
                    case 5:
                        Supplier supplierManager = new Supplier();
                        supplierManager.MenuItem();
                        break;
                    case 6:
                        AddStock addStock = new AddStock();
                        addStock.MenuItem();
                        break;

                    case 7:
                        Customer customer = new Customer();
                        customer.MenuItem();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            } while (option != 9);
        }


        }
    }
