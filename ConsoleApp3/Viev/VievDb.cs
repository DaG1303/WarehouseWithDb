using WarehouseWithDb.VievModel;
namespace WarehouseWithDb.Viev
{
    public class VievDb
    {
        private WarehouseModel _wh = new WarehouseModel();
        private CompanyModel _company = new CompanyModel();
        public void Viev()
        {
            Console.WriteLine("С какой из моделей начать работу?\n1 - Склад\n2 - Компания ");
            string i = Console.ReadLine();
            if (int.TryParse(i, out int result))
            {                
                VievWarehouse(result);
                VievCompany(result);
            }
            else
            {
                Console.WriteLine("Введено неверное значение");
            }
            
        }
        private void VievWarehouse(int i)
        {
            while (true)
            {
                if (i == 1)
                {
                    Console.WriteLine("Какие действия совершить с базой данных?\n1 - Добавление\n2 - Чтение данных\n3 - Редактирование\n4 - Удаление\n5 - Выход");
                    string j = Console.ReadLine();
                    if (int.TryParse(j, out int result))
                    {
                        if (result == 1)
                        {
                            _wh.AddProduct();
                        }
                        else if (result == 2)
                        {
                            _wh.ReadProduct();
                        }
                        else if (result == 3)
                        {
                            _wh.UpdateProduct();
                        }
                        else if (result == 4)
                        {
                            _wh.DeleteProduct();
                        }
                        else if (result == 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введено неверное значение, попрубуйте еще раз!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введено неверное значение, попрубуйте еще раз!");
                    }
                }
                else
                {
                    break;
                }
            }
        }
        private void VievCompany(int i)
        {
            while (true)
            {
                if (i == 2)
                {
                    Console.WriteLine("Какие действия совершить с базой данных?\n1 - Добавление\n2 - Чтение данных\n3 - Редактирование\n4 - Удаление\n5 - Выход");
                    string j = Console.ReadLine();
                    if (int.TryParse(j, out int result))
                    {
                        if (result == 1)
                        {
                            _company.AddProduct();
                        }
                        else if (result == 2)
                        {
                            _company.ReadProduct();
                        }
                        else if (result == 3)
                        {
                            _company.UpdateProduct();
                        }
                        else if (result == 4)
                        {
                            _company.DeleteProduct();
                        }
                        else if (result == 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введено неверное значение, попрубуйте еще раз!");
                        }
                    }
                    else
                    {
                        break;
                    }
                }                    
            }
        }
    }
}
