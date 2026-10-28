using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Project
{
    internal class User
    {
        public int Id;
        public string UserName;
        public string Gender;
        public string Password;
        public string Email;
        public string Status;
        public DateTime CreateAt;
        public string CreateBy;
        public DateTime UpdateAt;
        public string UpdateBy;

        int i;

        List<User> user = new List<User>();

        // Add User
        public void AddUserInfor()
        {
            Console.WriteLine("---------- Add User Information ----------");
            Console.Write("Input Number of User: ");
            int n = int.Parse(Console.ReadLine());

            for (i = 0; i < n; i++)
            {
                User newUser = new User();

                Console.Write("ID: ");
                newUser.Id = int.Parse(Console.ReadLine());

                Console.Write("User Name: ");
                newUser.UserName = Console.ReadLine();

                Console.Write("Gender: ");
                newUser.Gender = Console.ReadLine();

                Console.Write("Password: ");
                newUser.Password = Console.ReadLine();

                Console.Write("Email: ");
                newUser.Email = Console.ReadLine();

                Console.Write("Status: ");
                newUser.Status = Console.ReadLine();

                Console.Write("Create At:");
                newUser.CreateAt = DateTime.Now;
                Console.WriteLine(newUser.CreateAt);

                Console.Write("Create By: ");
                newUser.CreateBy = Console.ReadLine();

                Console.Write("Update At:");
                newUser.UpdateAt = DateTime.Now;
                Console.WriteLine(newUser.UpdateAt);

                Console.Write("Update By: ");
                newUser.UpdateBy = Console.ReadLine();


                bool duplicate = false;

                foreach (User u in user)
                {
                    if (u.Id == newUser.Id ||
                        u.UserName == newUser.UserName ||
                        u.Gender == newUser.Gender ||
                        u.Password == newUser.Password ||
                        u.Email == newUser.Email)
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
                    user.Add(newUser);
                    Console.WriteLine("User added successfully!");
                }
            }

            Console.WriteLine("------------------------------------------");
        }

        // Show User
        public void ShowUserInfor()
        {
            Console.WriteLine("---------- Show User Information ----------");

            if (user.Count == 0)
            {
                Console.WriteLine("No User Found!");
            }

            for (i = 0; i < user.Count; i++)
            {
                Console.WriteLine($"ID: {user[i].Id}");
                Console.WriteLine($"User Name: {user[i].UserName}");
                Console.WriteLine($"Gender: {user[i].Gender}");
                Console.WriteLine($"Password: {new string('*', user[i].Password.Length)}");
                Console.WriteLine($"Email: {user[i].Email}");
                Console.WriteLine($"Status: {user[i].Status}");
                Console.WriteLine($"Create At: {user[i].CreateAt}");
                Console.WriteLine($"Create By: {user[i].CreateBy}");
                Console.WriteLine($"Update At: {user[i].UpdateAt}");
                Console.WriteLine($"Update By: {user[i].UpdateBy}");

                Console.WriteLine("------------------------------------------");
            }
        }
        // Update User
        public void UpdateUserInfor()
        {
            Console.WriteLine("----------Update User Information-----------");
            Console.Write("Search by ID: ");
            int SearchId = int.Parse(Console.ReadLine());

            bool check = false;

            for (i = 0; i < user.Count; i++)
            {
                if (user[i].Id == SearchId)
                {
                    check = true;
                    break;
                }
            }

            if (check)
            {
                Console.Write("Input New User Name: ");
                this.UserName = Console.ReadLine();
                if (!(this.UserName.Equals("")))
                {
                    user[i].UserName = this.UserName;
                }

                Console.Write("Input New Gender: ");
                this.Gender = Console.ReadLine();
                if (!(this.Gender.Equals("")))
                {
                    user[i].Gender = this.Gender;
                }

                Console.Write("Input New Password: ");
                this.Password = Console.ReadLine();
                if (!(this.Password.Equals("")))
                {
                    user[i].Password = this.Password;
                }

                Console.Write("Input New Email: ");
                this.Email = Console.ReadLine();
                if (!(this.Email.Equals("")))
                {
                    user[i].Email = this.Email;
                }

                Console.Write("Input New Status: ");
                this.Status = Console.ReadLine();
                if (!(this.Status.Equals("")))
                {
                    user[i].Status = this.Status;
                }
                Console.Write("New Create At: ");
                this.CreateAt = DateTime.Now;
                if (!(this.CreateAt.Equals("")))
                {
                    user[i].CreateAt = this.CreateAt;
                    Console.WriteLine(user[i].CreateAt);
                }

                Console.Write("Input New Create By: ");
                this.CreateBy = Console.ReadLine();
                if (!(this.CreateBy.Equals("")))
                {
                    user[i].CreateBy = this.CreateBy;
                }

                Console.Write("New Update At: ");
                this.UpdateAt = DateTime.Now;
                if (!(this.UpdateAt.Equals("")))
                {
                    user[i].UpdateAt = this.UpdateAt;
                    Console.WriteLine(user[i].UpdateAt);
                }

                Console.Write("Input New Update By: ");
                this.UpdateBy = Console.ReadLine();
                if (!(this.UpdateBy.Equals("")))
                {
                    user[i].UpdateBy = this.UpdateBy;
                }

                user[i].UpdateAt = DateTime.Now;

                Console.WriteLine("User Information is Updated");
            }
            else
            {
                Console.WriteLine(" Not Found!");
            }

            Console.WriteLine("------------------------------------------");
        }

        // Delete User
        public void DeleteUserInfor()
        {
            Console.WriteLine("---------- Delete User Information ----------");
            Console.Write("Search ID to Delete: ");
            int SearchId = int.Parse(Console.ReadLine());

            bool check = false;

            for (i = 0; i < user.Count; i++)
            {
                if (user[i].Id == SearchId)
                {
                    check = true;
                    break;
                }
            }

            if (check)
            {
                user.RemoveAt(i);
                Console.WriteLine("User Information Deleted!");
            }
            else
            {
                Console.WriteLine("ID Not Found!");
            }

            Console.WriteLine("------------------------------------------");
        }

        // Search User
        public void SearchUserInfor()
        {
            Console.WriteLine("---------- Search User Information ----------");
            Console.Write("Search ID: ");
            int SearchId = int.Parse(Console.ReadLine());

            bool check = false;

            for (i = 0; i < user.Count; i++)
            {
                if (user[i].Id == SearchId)
                {
                    check = true;

                    Console.WriteLine("User Found!");
                    Console.WriteLine($"ID: {user[i].Id}");
                    Console.WriteLine($"User Name: {user[i].UserName}");
                    Console.WriteLine($"Gender: {user[i].Gender}");
                    Console.WriteLine($"Password: {new string('*', user[i].Password.Length)}");
                    Console.WriteLine($"Email: {user[i].Email}");
                    Console.WriteLine($"Status: {user[i].Status}");
                    Console.WriteLine($"Create At: {user[i].CreateAt}");
                    Console.WriteLine($"Create By: {user[i].CreateBy}");
                    Console.WriteLine($"Update At: {user[i].UpdateAt}");
                    Console.WriteLine($"Update By: {user[i].UpdateBy}");

                    break;
                }
            }

            if (!check)
            {
                Console.WriteLine("ID Not Found!");
            }

            Console.WriteLine("------------------------------------------");
        }

        // User Menu
        public void UserInfor()
        {
        Start:
            Console.WriteLine("---------- User Management ----------");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. Search User");
            Console.WriteLine("6. Back Home");
            Console.WriteLine("------------------------------------");

            Console.Write("Choose Option: ");
            int options = int.Parse(Console.ReadLine());

            switch (options)
            {
                case 1:
                    AddUserInfor();
                    break;

                case 2:
                    ShowUserInfor();
                    break;

                case 3:
                    UpdateUserInfor();
                    break;

                case 4:
                    DeleteUserInfor();
                    break;

                case 5:
                    SearchUserInfor();
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
