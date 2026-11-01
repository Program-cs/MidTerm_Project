using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Project
{
    internal class Role
    {
        public int Id;
        public string Name;
        public string CreateDate;
        public string CreateBy;
        public string Status;
        public static string UpdateDate;
        public static string UpdateBy;
        public static int UpdateId;
        public static List<Role> Roles = new List<Role>();
        static void Main(string[] args)
        {
        start:
            Console.WriteLine("--------------------Role Management-------------------------");
            Console.WriteLine("1. Add Role");
            Console.WriteLine("2. Show Role");
            Console.WriteLine("3. Update Role");
            Console.WriteLine("4. Delete Role");
            Console.WriteLine("5. Search Role");
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
                    Back();
                    break;
            }
            goto start;

        }
        public static void AddRole()
        {
            Console.WriteLine("----------------1.Add Role-------------------");
            Role s = new Role();
        add:
            Console.Write("Id:");
            s.Id = int.Parse(Console.ReadLine());
            if (s.Id != Roles.Count)
            {

                Console.Write("Name:");
                s.Name = Console.ReadLine();
                Console.Write("Create By:");
                s.CreateBy = Console.ReadLine();
                s.Status = "Active";
                s.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Roles.Add(s);
            }
            else
            {
                Console.WriteLine("Input Id again");
                goto add;
            }
        }
        public static void ShowRole()
        {
            for (int i = 0; i < Roles.Count; i++)
            {
                Console.WriteLine("---------------------2.Show Role------------------------");
                Console.WriteLine($"Id:{Roles[i].Id}");
                Console.WriteLine($"Name:{Roles[i].Name}");
                Console.WriteLine($"Status:{Roles[i].Status}");
                Console.WriteLine($"Create By:{Roles[i].CreateBy}");
                Console.WriteLine($"Create Date:{Roles[i].CreateDate}");
            }

        }
        public static void UpdateRole()
        {
            Console.WriteLine("--------------------------2.Update Role-----------------------");
            if (Roles.Count == 0)
            {
                Console.WriteLine("Role not found!");
            }
            for (int i = 0; i < Roles.Count; i++)
            {
                Console.Write("Search by Id:");

                UpdateId = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------------");
                bool Ischeacked = false;
                if (Roles[i].Id == UpdateId)
                {
                    Ischeacked = true;
                    Console.WriteLine("Name:");
                    Roles[i].Name = Console.ReadLine();
                    Console.WriteLine("Update By");
                    Roles[i].CreateBy = Console.ReadLine();

                    UpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                }
                if (!Ischeacked)
                {
                    Console.WriteLine("Not found Id!");
                }

            }
        }
        public static void DeleteRole()
        {
            Console.WriteLine("-----------------3.Delete Role------------------");
            if (Roles.Count == 0)
            {
                Console.WriteLine("Role not found!");
            }
            for (int i = 0; i < Roles.Count; i++)
            {
                Console.Write("Search by Id:");
                int UpdateId;
                UpdateId = int.Parse(Console.ReadLine());
                bool Ischeacked = false;
                if (Roles[i].Id == UpdateId)
                {
                    Ischeacked = true;
                    Roles.RemoveAt(i);
                    Console.WriteLine("Role remove successfuly!");
                    break;
                }
                if (!Ischeacked)
                {
                    Console.WriteLine("Not found Id!");
                }

            }
        }
        public static void SearchRole()
        {
            Console.WriteLine("-------------5.Search Role-----------------");
            if (Roles.Count == 0)
            {
                Console.WriteLine("Role not found!");
            }
            for (int i = 0; i < Roles.Count; i++)
            {
                Console.Write("Search by Id:");
                int SearchId;
                SearchId = int.Parse(Console.ReadLine());
                if (Roles[i].Id == SearchId)
                {

                    Console.WriteLine($"Id:{Roles[i].Id}");
                    Console.WriteLine($"User Name:{Roles[i].Name}");
                    Console.WriteLine($"Status:{Roles[i].Status}");
                    Console.WriteLine($"Create By:{Roles[i].CreateBy}");
                    Console.WriteLine($"Create Date:{Roles[i].CreateDate}");
                    break;
                }
                else
                {
                    Console.WriteLine("Not found Id!");
                }
            }
        }
        public static void Back()
        {
            Environment.Exit(0);
        }
    }
}
