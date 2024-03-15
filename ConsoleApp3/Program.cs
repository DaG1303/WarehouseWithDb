namespace WarehouseWithDb
{
   public class Program
   {
        static void Main(string[] args)
        {
            //using (var context = new ApplicationContext())
            //{
            //    Warehouse warehouse = new Warehouse { Name = "a" };
            //    context.Warehouses.Add(warehouse);
            //    context.SaveChanges();
            //    Console.WriteLine("Обьекты сохранены");
            //}
            while (true)
            {
                Console.WriteLine($"Какие действия совершить с базой данных?\n1 - Добавление\n2 - Чтение данных\n3 - Редактирование\n4 - Удаление\n5 - Выход");
                int i = Convert.ToInt32(Console.ReadLine());
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
            }
        }
        private static void AddProduct()
        {
            using (var context = new ApplicationContext())
            {
                IsConnected(context);

                Console.WriteLine("Введите значения:\n1.Название\n2.Количество\n3.Описание\n4.Поставщик\n");

                Warehouse? warehouse = new()
                {
                    Name = Console.ReadLine(),
                    Quantity = Convert.ToInt32(Console.ReadLine()),
                    Description = Console.ReadLine(),
                    Supplier = Console.ReadLine(),
                    Company = new() { Name =  Console.ReadLine()}
                };
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
                Console.WriteLine("Обьекты успешно сохранены!");
                                
            }
        }

        private static void ReadProduct()
        {
            using (var context = new ApplicationContext())
            {
                IsConnected(context);
                Read(context);
            }
        }
        private static void UpdateProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                IsConnected(context);

                Console.WriteLine("Какую вы строку хотите редактировать?\n");
                int idToUpdate = Convert.ToInt32(Console.ReadLine());
                Warehouse? warehouse = context.Warehouses.Find(idToUpdate);
                Console.WriteLine("Введите значения:\n1.Название\n2.Количество\n3.Описание\n4.Поставщик\n");

                if (warehouse != null)
                {
                    warehouse.Name = Console.ReadLine();
                    warehouse.Quantity = Convert.ToInt32(Console.ReadLine());
                    warehouse.Supplier = Console.ReadLine();
                    warehouse.Description = Console.ReadLine();
                    context.Warehouses.Update(warehouse);
                    context.SaveChanges();
                }
                Read(context);
            }
        }

        private static void DeleteProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                IsConnected(context);
                Console.WriteLine("Какую вы строку хотите удалить из базы данных?\n");
                int idToDelete = Convert.ToInt32(Console.ReadLine());
                var product = context.Warehouses.FirstOrDefault(e => e.Id == idToDelete);
                if (product != null)
                {
                    context.Warehouses.Remove(product);
                    context.SaveChanges();
                    Console.WriteLine("Строка успешно удалена.");
                }
                else
                {
                    Console.WriteLine("Строка с указанным Id не найдена.");
                }
                Read(context);
            }
        }
        private static void IsConnected(ApplicationContext context)
        {
            bool isCreated = context.Database.EnsureCreated();
            if (isCreated)
            {
                Console.WriteLine("База данных успешно создана");
            }
            Console.WriteLine("Работа с базой данных началась");
        }
        private static void Read(ApplicationContext context)
        {
            Console.WriteLine("\nСписок товаров:");
            var warehouseProducts = context.Warehouses.ToList();
            foreach (Warehouse p in warehouseProducts)
            {
                Console.WriteLine($"{p.Id}.{p.Name}\nКоличество:{p.Quantity}\nОписание:{p.Description}\nПоставщик:{p.Supplier}\n");
            }
            var companyProducts = context.Companies.ToList();
            foreach (Company c in companyProducts)
            {
                Console.WriteLine($"{c.Id}.{c.Name}");
            }
        }
    }
}

