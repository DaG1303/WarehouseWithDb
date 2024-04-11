using WarehouseWithDb.Interfaces;
using WarehouseWithDb.Model;

namespace WarehouseWithDb.VievModel
{
    public class CompanyModel : IControllable
    {
        private Connect _connect = new Connect();
        private PrintInfo _printInfo = new PrintInfo();

        public void AddProduct()
        {
            using (var context = new ApplicationContext())
            {
                _connect.IsConnected(context);
                Console.WriteLine("Введите значения:\n1.Количество\n2.Адресс компании\n");

                context.Companies.Add(new CompanyDb(Console.ReadLine(), Console.ReadLine()));
                context.SaveChanges();

                _printInfo.PrintCompany(context);
            }
        }
        public void ReadProduct()
        {
            using (var context = new ApplicationContext())
            {
                _connect.IsConnected(context);
                _printInfo.PrintCompany(context);
            }
        }
        public void UpdateProduct()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                _connect.IsConnected(context);
                Console.WriteLine("Какую вы строку хотите редактировать?\n");
                _printInfo.PrintCompany(context);

                string idToUpdate = Console.ReadLine();
                if (int.TryParse(idToUpdate, out int id))
                {
                    var product = context.Companies.FirstOrDefault(e => e.Id == id);

                    Console.WriteLine("Введите значения:\n1.Количество\n2.Адресс компании\n");
                    if (product != null)
                    {
                        product.Set(Console.ReadLine(), Console.ReadLine());
                        context.SaveChanges();
                        _printInfo.PrintCompany(context);
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
                _printInfo.PrintCompany(context);

                string idToDelete = Console.ReadLine();
                if (int.TryParse(idToDelete, out int id))
                {
                    var product = context.Companies.FirstOrDefault(e => e.Id == id);

                    if (product != null)
                    {
                        context.Companies.Remove(product);
                        context.SaveChanges();
                        Console.WriteLine("Строка успешно удалена.\n");
                    }
                    else
                    {
                        Console.WriteLine("Строка с указанным Id не найдена.\n");
                        _printInfo.PrintCompany(context);
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

