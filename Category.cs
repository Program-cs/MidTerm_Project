using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Project
{
    internal class Category
    {
        public int Id;
        public string Name;
        public string Status;
        public DateTime CreateAt;
        public string CreateBy;
        public DateTime UpdateAt;
        public string UpdateBy;

        int i;

        List<Category> category = new List<Category>();

        // Add info
        public void AddInfor()
        {
            Console.WriteLine("---------- Add Information ----------");
            Console.Write("Input Number of Category: ");
            int n = int.Parse(Console.ReadLine());

            for (i = 0; i < n; i++)
            {
                Category newCategory = new Category();

                Console.Write("ID: ");
                newCategory.Id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                newCategory.Name = Console.ReadLine();

                Console.Write("Status: ");
                newCategory.Status = Console.ReadLine();

                Console.Write("Create At:");
                newCategory.CreateAt = DateTime.Now;
                Console.WriteLine(newCategory.CreateAt);

                Console.Write("Create By: ");
                newCategory.CreateBy = Console.ReadLine();

                Console.Write("Update At:");
                newCategory.UpdateAt = DateTime.Now;
                Console.WriteLine(newCategory.UpdateAt);

                Console.Write("Update By: ");
                newCategory.UpdateBy = Console.ReadLine();


                bool duplicate = false;

                foreach (Category u in category)
                {
                    if (u.Id == newCategory.Id ||
                        u.Name == newCategory.Name)

                    {
                        duplicate = true;
                        break;
                    }
                }

                if (duplicate)
                {
                    Console.WriteLine("Error: Duplicate value!");
                }
                else
                {
                    category.Add(newCategory);
                    Console.WriteLine(" added successfully!");
                }
            }

            Console.WriteLine("------------------------------------------");
        }

        // Show info
        public void ShowInfor()
        {
            Console.WriteLine("---------- Show Category Information ----------");

            if (category.Count == 0)
            {
                Console.WriteLine("No Category Found!");
            }

            for (i = 0; i < category.Count; i++)
            {
                Console.WriteLine($"ID: {category[i].Id}");
                Console.WriteLine($"Name: {category[i].Name}");
                Console.WriteLine($"Status: {category[i].Status}");
                Console.WriteLine($"Create At: {category[i].CreateAt}");
                Console.WriteLine($"Create By: {category[i].CreateBy}");
                Console.WriteLine($"Update At: {category[i].UpdateAt}");
                Console.WriteLine($"Update By: {category[i].UpdateBy}");

                Console.WriteLine("------------------------------------------");
            }
        }
        // Update Info
        public void UpdateInfor()
        {
            Console.WriteLine("----------Update Category Information-----------");
            Console.Write("Search by ID: ");
            int SearchId = int.Parse(Console.ReadLine());

            bool check = false;

            for (i = 0; i < category.Count; i++)
            {
                if (category[i].Id == SearchId)
                {
                    check = true;
                    break;
                }
            }

            if (check)
            {
                Console.Write("Input New  Name: ");
                this.Name = Console.ReadLine();
                if (!(this.Name.Equals("")))
                {
                    category[i].Name = this.Name;
                }

                Console.Write("Input New Status: ");
                this.Status = Console.ReadLine();
                if (!(this.Status.Equals("")))
                {
                    category[i].Status = this.Status;
                }
                Console.Write("New Create At: ");
                this.CreateAt = DateTime.Now;
                if (!(this.CreateAt.Equals("")))
                {
                    category[i].CreateAt = this.CreateAt;
                    Console.WriteLine(category[i].CreateAt);
                }

                Console.Write("Input New Create By: ");
                this.CreateBy = Console.ReadLine();
                if (!(this.CreateBy.Equals("")))
                {
                    category[i].CreateBy = this.CreateBy;
                }

                Console.Write("New Update At: ");
                this.UpdateAt = DateTime.Now;
                if (!(this.UpdateAt.Equals("")))
                {
                    category[i].UpdateAt = this.UpdateAt;
                    Console.WriteLine(category[i].UpdateAt);
                }

                Console.Write("Input New Update By: ");
                this.UpdateBy = Console.ReadLine();
                if (!(this.UpdateBy.Equals("")))
                {
                    category[i].UpdateBy = this.UpdateBy;
                }

                category[i].UpdateAt = DateTime.Now;

                Console.WriteLine("Category Information is Updated");
            }
            else
            {
                Console.WriteLine(" Not Found!");
            }

            Console.WriteLine("------------------------------------------");
        }

        // Delete Info
        public void DeleteInfor()
        {
            Console.WriteLine("---------- Delete Category Information ----------");
            Console.Write("Search ID to Delete: ");
            int SearchId = int.Parse(Console.ReadLine());

            bool check = false;

            for (i = 0; i < category.Count; i++)
            {
                if (category[i].Id == SearchId)
                {
                    check = true;
                    break;
                }
            }

            if (check)
            {
                category.RemoveAt(i);
                Console.WriteLine("Category Information Deleted!");
            }
            else
            {
                Console.WriteLine("ID Not Found!");
            }

            Console.WriteLine("------------------------------------------");
        }

        // Search Info
        public void SearchInfor()
        {
            Console.WriteLine("---------- Search Category Information ----------");
            Console.Write("Search ID: ");
            int SearchId = int.Parse(Console.ReadLine());

            bool check = false;

            for (i = 0; i < category.Count; i++)
            {
                if (category[i].Id == SearchId)
                {
                    check = true;

                    Console.WriteLine("Category Found!");
                    Console.WriteLine($"ID: {category[i].Id}");
                    Console.WriteLine($"Name: {category[i].Name}");
                    Console.WriteLine($"Status: {category[i].Status}");
                    Console.WriteLine($"Create At: {category[i].CreateAt}");
                    Console.WriteLine($"Create By: {category[i].CreateBy}");
                    Console.WriteLine($"Update At: {category[i].UpdateAt}");
                    Console.WriteLine($"Update By: {category[i].UpdateBy}");

                    break;
                }
            }

            if (!check)
            {
                Console.WriteLine("ID Not Found!");
            }

            Console.WriteLine("------------------------------------------");
        }

        // Category Menu
        public void MenuItem()
        {
        Start:
            Console.WriteLine("---------- Category Management ----------");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Show Category");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Delete Category");
            Console.WriteLine("5. Search Category");
            Console.WriteLine("6. Back Home");
            Console.WriteLine("------------------------------------");

            Console.Write("Choose Option: ");
            int options = int.Parse(Console.ReadLine());

            switch (options)
            {
                case 1:
                    AddInfor();
                    break;

                case 2:
                    ShowInfor();
                    break;

                case 3:
                    UpdateInfor();
                    break;

                case 4:
                    DeleteInfor();
                    break;

                case 5:
                    SearchInfor();
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }

            goto Start;
        }
    }
}