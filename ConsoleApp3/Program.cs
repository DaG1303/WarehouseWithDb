using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseWithDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Какие действия совершить с базой данных?\n1 - Добавление\n2 - Чтение данных\n3 - Редактирование\n4 - Удаление\n5 - Выход");
            int i = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (i == 1)
                {
                    AddProduct();
                }
                if (i == 2)
                {
                    ReadProduct();
                }
                if (i == 3)
                {
                    UpdateProduct();
                }
                if (i == 4)
                {
                    DeleteProduct();
                }
                if (i == 5)
                {
                    break;
                }
                Console.WriteLine($"Какие действия совершить с базой данных?\n1 - Добавление\n2 - Чтение данных\n3 - Редактирование\n4 - Удаление\n5 - Выход");
                i = Convert.ToInt32(Console.ReadLine());
            }
        }
        private static void AddProduct()
        {
            using (var context = new ApplicationContext())
            {
                bool isCreated = context.Database.EnsureCreated();
                if (isCreated)
                {
                    Console.WriteLine("База данных успешно создана");
                }
                Console.WriteLine("Работа с базой данных началась");

                Console.WriteLine("Введите значения:\n1.Название\n2.Количество\n3.Описание\n4.Поставщик\n");

                Warehouse? warehouse = new Warehouse
                {
                    Name = Console.ReadLine(),
                    Quantity = Convert.ToInt32(Console.ReadLine()),
                    Description = Console.ReadLine(),
                    Supplier = Console.ReadLine()
                };
                context.Warehouse.Add(warehouse);
                context.SaveChanges();
                Console.WriteLine("Обьекты успешно сохранены!");
            }
        }
        private static void ReadProduct()
        {
            using (var context = new ApplicationContext())
            {
                bool isCreated = context.Database.EnsureCreated();
                if (isCreated)
                {
                    Console.WriteLine("База данных успешно создана");
                }
                Console.WriteLine("Работа с базой данных началась");

                var products = context.Warehouse.ToList();
                Console.WriteLine("Список товаров:");
                foreach (Warehouse p in products)
                {
                    Console.WriteLine($"{p.Id}.{p.Name}\nКоличество:{p.Quantity}\nОписание:{p.Description}\nПоставщик:{p.Supplier}\n");
                }
            }
        }
        private static void UpdateProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                bool isCreated = context.Database.EnsureCreated();
                if (isCreated)
                {
                    Console.WriteLine("База данных успешно создана");
                }
                Console.WriteLine("Работа с базой данных началась");

                Warehouse? warehouse = context.Warehouse.FirstOrDefault();
                if (warehouse != null)
                {
                    warehouse.Name = Console.ReadLine();
                    warehouse.Quantity = Convert.ToInt32(Console.ReadLine());
                    warehouse.Supplier = Console.ReadLine();
                    warehouse.Description = Console.ReadLine();
                    context.Warehouse.Update(warehouse);
                    context.SaveChanges();
                }
                Console.WriteLine("\nДанные после редактирования:");
                var products = context.Warehouse.ToList();
                foreach (Warehouse product in products)
                {
                    Console.WriteLine($"{product.Id}.{product.Name}\nКоличество:{product.Quantity}\nОписание:{product.Description}\n");
                }
            }
        }
        private static void DeleteProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                bool isCreated = context.Database.EnsureCreated();
                if (isCreated)
                {
                    Console.WriteLine("База данных успешно создана");
                }
                Console.WriteLine("Работа с базой данных началась");

                Warehouse? product = context.Warehouse.FirstOrDefault();
                if (product != null)
                {
                    context.Warehouse.Remove(product);
                    context.SaveChanges();
                }
                Console.WriteLine("\nДанные после удаления:");
                var products = context.Warehouse.ToList();
                foreach (Warehouse p in products)
                {
                    Console.WriteLine($"{p.Id}.{p.Name}\nКоличество:{p.Quantity}\nОписание:{p.Description}");
                }
            }
        }
    }
}
