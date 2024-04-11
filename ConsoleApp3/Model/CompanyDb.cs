using WarehouseWithDb.Interfaces;

namespace WarehouseWithDb.Model
{
    public class CompanyDb : IPrintable
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
        public void Set(string name, string address)
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
