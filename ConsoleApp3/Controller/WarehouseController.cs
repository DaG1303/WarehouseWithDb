using WarehouseWithDb.Viev;
using WarehouseWithDb.Model;
using System.Threading.Channels;
namespace WarehouseWithDb.Controller
{
    public class WarehouseController
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
                    WarehouseDb warehouse = new(quantity, Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                    context.Warehouses.Add(warehouse);
                    context.SaveChanges();
                    _printInfo.Print(context);
                }
                else
                {
                    Console.WriteLine("Введены неверные значения!\n");
                    _printInfo.Print(context);
                }
            }
        }
        public void ReadProduct()
        {
            using (var context = new ApplicationContext())
            {
                _connect.IsConnected(context);
                _printInfo.Print(context);
            }
        }
        public void UpdateProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                _connect.IsConnected(context);
                Console.WriteLine("Какую вы строку хотите редактировать?\n");
                _printInfo.Print(context);

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
                            product.quantity = quantity;
                            product.name = Console.ReadLine();
                            product.supplier = Console.ReadLine();
                            product.description = Console.ReadLine();                            
                            context.SaveChanges();
                            _printInfo.Print(context);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введены неверные значения!\n");
                        _printInfo.Print(context);
                    }
                }
                else
                {
                    Console.WriteLine("Значение введено неверно.");
                }
            }
        }
        public void DeleteProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {                
                _connect.IsConnected(context);
                Console.WriteLine("Какую вы строку хотите удалить из базы данных?\n");
                _printInfo.Print(context);

                string idToDelete = Console.ReadLine();
                if (int.TryParse(idToDelete, out int id))
                {
                    var product = context.Warehouses.FirstOrDefault(e => e.Id == id);

                    if (product != null)
                    {
                        context.Warehouses.Remove(product);
                        context.SaveChanges();
                        Console.WriteLine("Строка успешно удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Строка с указанным Id не найдена.");
                        _printInfo.Print(context);
                    }
                }
                else
                {
                    Console.WriteLine("Значение введено неверно.");
                }
                
            }
        }    
    }
}
