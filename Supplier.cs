using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Project
{
    internal class Supplier
    {
        public int Id;
        public string Name;
        public string Tel;
        public string Address;
        public DateTime CreateAt;
        public string CreateBy;
        public DateTime? UpdateAt;     // empty until first update
        public string UpdateBy;        // optional
        public List<Supplier> suppliers = new List<Supplier>();

        // Add Stock teammate can set this so a supplier that has stock records cannot be deleted:
        //   supplierManager.HasAddStock = supplierId => addStocks.Any(a => a.SupplierId == supplierId);
        public Func<int, bool> HasAddStock;

        public void MenuItem()
        {
        start:
            Console.WriteLine("--------------------Supplier Management-------------------------");
            Console.WriteLine("1. Add Supplier");
            Console.WriteLine("2. Show Supplier");
            Console.WriteLine("3. Update Supplier");
            Console.WriteLine("4. Delete Supplier");
            Console.WriteLine("5. Search Supplier");
            Console.WriteLine("6. Back home");
            int option = ReadInt("Choose Option");
            if (option < 1 || option > 6)
            {
                Console.WriteLine("Invalid option! Please try again.");
                goto start;
            }
            switch (option)
            {
                case 1:
                    AddSupplier();
                    break;
                case 2:
                    ShowSupplier();
                    break;
                case 3:
                    UpdateSupplier();
                    break;
                case 4:
                    DeleteSupplier();
                    break;
                case 5:
                    SearchSupplier();
                    break;
                case 6:
                    return;   // back to the caller (main menu)
            }
            goto start;
        }

        // For other modules (e.g. Add Stock checks that SupplierId exists)
        public Supplier FindById(int id)
        {
            return suppliers.FirstOrDefault(s => s.Id == id);
        }

        public void AddSupplier()
        {
            Console.WriteLine("----------------1.Add Supplier-------------------");

            int id = ReadInt("Id");
            while (FindById(id) != null)
            {
                Console.WriteLine("Id already exists! Input Id again");
                id = ReadInt("Id");
            }

            string name = ReadText("Name", true);
            while (NameExists(name, 0))
            {
                Console.WriteLine("Name already exists! Input Name again");
                name = ReadText("Name", true);
            }

            string tel = ReadText("Tel", true);
            while (TelExists(tel, 0))
            {
                Console.WriteLine("Tel already exists! Input Tel again");
                tel = ReadText("Tel", true);
            }

            string address = ReadText("Address", true);
            string createBy = ReadText("Create By", true);

            Supplier s = new Supplier();
            s.Id = id;
            s.Name = name;
            s.Tel = tel;
            s.Address = address;
            s.CreateAt = DateTime.Now;
            s.CreateBy = createBy;
            suppliers.Add(s);
            Console.WriteLine("Supplier added successfully!");
        }

        public void ShowSupplier()
        {
            if (suppliers.Count == 0)
            {
                Console.WriteLine("Supplier not found!");
                return;
            }
            for (int i = 0; i < suppliers.Count; i++)
            {
                Console.WriteLine("---------------------2.Show Supplier------------------------");
                PrintSupplier(suppliers[i]);
            }
        }

        public void UpdateSupplier()
        {
            Console.WriteLine("--------------------------3.Update Supplier-----------------------");
            if (suppliers.Count == 0)
            {
                Console.WriteLine("Supplier not found!");
                return;
            }

            int updateId = ReadInt("Search by Id");
            Supplier s = FindById(updateId);
            if (s == null)
            {
                Console.WriteLine("Not found Id!");
                return;
            }

            Console.WriteLine("(press Enter to keep the current value)");

            string name = ReadText("Name [" + s.Name + "]", false);
            if (name != "" && NameExists(name, s.Id))
            {
                Console.WriteLine("Name already exists! Nothing changed.");
                return;
            }

            string tel = ReadText("Tel [" + s.Tel + "]", false);
            if (tel != "" && TelExists(tel, s.Id))
            {
                Console.WriteLine("Tel already exists! Nothing changed.");
                return;
            }

            string address = ReadText("Address [" + s.Address + "]", false);
            string updateBy = ReadText("Update By", true);

            if (name != "") s.Name = name;
            if (tel != "") s.Tel = tel;
            if (address != "") s.Address = address;
            s.UpdateBy = updateBy;
            s.UpdateAt = DateTime.Now;
            Console.WriteLine("Supplier updated successfully!");
        }

        public void DeleteSupplier()
        {
            Console.WriteLine("-----------------4.Delete Supplier------------------");
            if (suppliers.Count == 0)
            {
                Console.WriteLine("Supplier not found!");
                return;
            }

            int deleteId = ReadInt("Search by Id");
            Supplier s = FindById(deleteId);
            if (s == null)
            {
                Console.WriteLine("Not found Id!");
                return;
            }

            // Cannot delete a supplier that already has Add Stock records
            if (HasAddStock != null && HasAddStock(s.Id))
            {
                Console.WriteLine("Cannot delete: this supplier has stock records!");
                return;
            }

            Console.Write("Delete '" + s.Name + "'? (y/n): ");
            string answer = (Console.ReadLine() ?? "").Trim().ToLower();
            if (answer == "y")
            {
                suppliers.Remove(s);
                Console.WriteLine("Supplier remove successfuly!");
            }
            else
            {
                Console.WriteLine("Cancelled.");
            }
        }

        public void SearchSupplier()
        {
            Console.WriteLine("-------------5.Search Supplier-----------------");
            if (suppliers.Count == 0)
            {
                Console.WriteLine("Supplier not found!");
                return;
            }

            int searchId = ReadInt("Search by Id");
            Supplier s = FindById(searchId);
            if (s == null)
            {
                Console.WriteLine("Not found Id!");
                return;
            }
            PrintSupplier(s);
        }

        // ---------- helpers ----------
        private void PrintSupplier(Supplier s)
        {
            Console.WriteLine($"Id:{s.Id}");
            Console.WriteLine($"Name:{s.Name}");
            Console.WriteLine($"Tel:{s.Tel}");
            Console.WriteLine($"Address:{s.Address}");
            string createAt = s.CreateAt.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"Create At:{createAt}");
            Console.WriteLine($"Create By:{s.CreateBy}");
            if (s.UpdateAt.HasValue)
            {
                string updateAt = s.UpdateAt.Value.ToString("yyyy-MM-dd HH:mm:ss");
                Console.WriteLine($"Update At:{updateAt}");
                Console.WriteLine($"Update By:{s.UpdateBy}");
            }
        }

        private bool NameExists(string name, int ignoreId)
        {
            return suppliers.Any(s => s.Id != ignoreId && s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private bool TelExists(string tel, int ignoreId)
        {
            return suppliers.Any(s => s.Id != ignoreId && s.Tel == tel);
        }

        private string ReadText(string label, bool required)
        {
            while (true)
            {
                Console.Write(label + ":");
                string value = (Console.ReadLine() ?? "").Trim();
                if (value.Length > 0 || !required) return value;
                Console.WriteLine("Cannot be empty. Try again.");
            }
        }

        private int ReadInt(string label)
        {
            while (true)
            {
                Console.Write(label + ":");
                int n;
                if (int.TryParse(Console.ReadLine(), out n)) return n;
                Console.WriteLine("Please enter a number.");
            }
        }
    }

}

