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
        public string UpdateBy;
        public string UpdateAt;
        public List<Role> Roles = new List<Role>();
        public void MenuItem()
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
                    return;
            }
            goto start;
        }
        public void AddRole()
        {
            Console.WriteLine("----------------1.Add Role-------------------");
        add:
            Role s = new Role();
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
        public void ShowRole()
        {
            for (int i = 0; i < Roles.Count; i++)
            {
                Console.WriteLine("---------------------2.Show Role------------------------");
                Console.WriteLine($"Id:{Roles[i].Id}");
                Console.WriteLine($"Name:{Roles[i].Name}");
                Console.WriteLine($"Status:{Roles[i].Status}");
                Console.WriteLine($"Create By:{Roles[i].CreateBy}");
                Console.WriteLine($"Create Date:{Roles[i].CreateDate}");
                if (Roles[i].UpdateAt != "")
                {
                    Console.WriteLine($"Update By: {Roles[i].UpdateBy}");
                    Console.WriteLine($"Update At: {Roles[i].UpdateAt}");
                }
            }


        }
        public void UpdateRole()
        {
            Console.WriteLine("--------------------------2.Update Role-----------------------");
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
                    Console.Write("Name:");
                    Roles[i].Name = Console.ReadLine();
                    Console.Write("Update By:");
                    Roles[i].UpdateBy = Console.ReadLine();
                    Roles[i].UpdateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
            Console.WriteLine("-----------------3.Delete Role------------------");
            if (Roles.Count == 0)
            {
                Console.WriteLine("Role not found!");
            }
            for (int i = 0; i < Roles.Count; i++)
            {
                Console.Write("Search by Id:");
                int DeleteId;
                DeleteId = int.Parse(Console.ReadLine());
                bool Ischeacked = false;
                if (Roles[i].Id == DeleteId)
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
        public void SearchRole()
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
                bool Ischeacked = false;
                if (Roles[i].Id == SearchId)
                {

                    Console.WriteLine($"Id:{Roles[i].Id}");
                    Console.WriteLine($"Name:{Roles[i].Name}");
                    Console.WriteLine($"Status:{Roles[i].Status}");
                    Console.WriteLine($"Create By:{Roles[i].CreateBy}");
                    Console.WriteLine($"Create Date:{Roles[i].CreateDate}");
                    break;
                }
                if (!Ischeacked)
                {
                    Console.WriteLine("Not found Id!");
                }
            }
        }
       

    }
}

