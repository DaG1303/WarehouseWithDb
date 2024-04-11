using WarehouseWithDb.Interfaces;
using WarehouseWithDb.Model;
namespace WarehouseWithDb.VievModel
{
    public class WarehouseModel : IControllable
    {
        private Connect _connect = new Connect();
        private PrintInfo _printInfo = new PrintInfo();

        public void AddProduct()
        {
            using (var context = new ApplicationContext())
            {
                _connect.IsConnected(context);
                Console.WriteLine("Введите значения:\n1.Количество\n2.Название\n3.Поставщик\n4.Описание\n");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int quantity))
                {
                    context.Warehouses.Add(new WarehouseDb(quantity, Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
                    context.SaveChanges();
                    _printInfo.PrintWarehouse(context);
                }
                else
                {
                    Console.WriteLine("Введены неверные значения!\n");
                    _printInfo.PrintWarehouse(context);
                }
            }
        }
        public void ReadProduct()
        {
            using (var context = new ApplicationContext())
            {
                _connect.IsConnected(context);
                _printInfo.PrintWarehouse(context);
            }
        }
        public void UpdateProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                _connect.IsConnected(context);
                Console.WriteLine("Какую вы строку хотите редактировать?\n");
                _printInfo.PrintWarehouse(context);

                string idToUpdate = Console.ReadLine();
                if (int.TryParse(idToUpdate, out int id))
                {
                    var product = context.Warehouses.FirstOrDefault(e => e.Id == id);

                    Console.WriteLine("Введите значения:\n1.Количество\n2.Название\n3.Поставщик\n4.Описание\n");
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out int quantity))
                    {
                        if (product != null)
                        {
                            product.Set(quantity, Console.ReadLine(), Console.ReadLine(), Console.ReadLine());                       
                            context.SaveChanges();
                            _printInfo.PrintWarehouse(context);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введены неверные значения!\n");
                        _printInfo.PrintWarehouse(context);
                    }
                }
                else
                {
                    Console.WriteLine("Значение введено неверно.\n");
                }
            }
        }
        public void DeleteProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {                
                _connect.IsConnected(context);
                Console.WriteLine("Какую вы строку хотите удалить из базы данных?\n");
                _printInfo.PrintWarehouse(context);

                string idToDelete = Console.ReadLine();
                if (int.TryParse(idToDelete, out int id))
                {
                    var product = context.Warehouses.FirstOrDefault(e => e.Id == id);

                    if (product != null)
                    {
                        context.Warehouses.Remove(product);
                        context.SaveChanges();
                        Console.WriteLine("Строка успешно удалена.\n");
                    }
                    else
                    {
                        Console.WriteLine("Строка с указанным Id не найдена.\n");
                        _printInfo.PrintWarehouse(context);
                    }
                }
                else
                {
                    Console.WriteLine("Значение введено неверно.\n");
                }
                
            }
        }    
    }
}
