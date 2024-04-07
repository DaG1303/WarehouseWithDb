using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseWithDb.Interfaces;

namespace WarehouseWithDb.Model
{
    public class CompanyDb : IPrintable
    {
        int id;
        public string? name;
        public string? address;
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
            Console.WriteLine($"{id}.Название компании:{name}\nАдресс компании:{address}\n");
        }
    }
        
}
