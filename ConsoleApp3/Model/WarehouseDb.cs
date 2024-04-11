using System;
using System.Collections.Generic;
using WarehouseWithDb.Interfaces;

namespace WarehouseWithDb.Model
{
    public class WarehouseDb : IPrintable
    {
        int id;
        int quantity;
        string name;
        string? description;
        string? supplier;
        public int Id => id;
        public int Quantity => quantity;
        public string Name => name;
        public string? Description => description;
        public string? Supplier => supplier;
        public CompanyDb? Company { get; set; }
        public WarehouseDb(int quantity, string name, string supplier, string description)
        {
            this.name = name;
            this.quantity = quantity;
            this.description = description;
            this.supplier = supplier;
        }
        public void Set(int quantity, string name, string supplier, string description)
        {
            this.name = name;
            this.quantity = quantity;
            this.description = description;
            this.supplier = supplier;
        }
        public void Print()
        {
            Console.WriteLine("\nСписок товаров:");
            Console.WriteLine($"{id}.{name}\nКоличество:{quantity}\nОписание:{description}\nПоставщик:{supplier}\n");
        }
    }
}