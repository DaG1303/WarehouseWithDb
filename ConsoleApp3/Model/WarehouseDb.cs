﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseWithDb.Model
{
    public class WarehouseDb
    {
        int id;
        public int quantity;
        public string name;
        public string? description;
        public string? supplier;
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
        public void Print()
        {
            Console.WriteLine("\nСписок товаров:");
            Console.WriteLine($"{id}.{name}\nКоличество:{quantity}\nОписание:{description}\nПоставщик:{supplier}\n");
        }
    }
}
