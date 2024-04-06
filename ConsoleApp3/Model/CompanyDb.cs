using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseWithDb.Model
{
    public class CompanyDb
    {
        int id;
        string? name;
        string? address;
        public int Id => id;
        public string? Name => name;
        public string? Address => address;
        public CompanyDb(string name, string address)
        {
            this.address = address;
            this.name = name;
        }
        public void Print()
        {
            Console.WriteLine($"{id}.{name}\nАдресс компании:{address}");
        }
    }
        
}
