using WarehouseWithDb.Controller;
namespace WarehouseWithDb.Viev
{
    public class VievDb
    {
        private WarehouseController _wh = new WarehouseController();
        public void Viev()
        {
            while (true)
            {
                Console.WriteLine($"Какие действия совершить с базой данных?\n1 - Добавление\n2 - Чтение данных\n3 - Редактирование\n4 - Удаление\n5 - Выход");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    _wh.AddProduct();
                }
                if (i == 2)
                {
                    _wh.ReadProduct();
                }
                if (i == 3)
                {
                    _wh.UpdateProduct();
                }
                if (i == 4)
                {
                    _wh.DeleteProduct();
                }
                if (i == 5)
                {
                    break;
                }
            }
        }
    }
}
