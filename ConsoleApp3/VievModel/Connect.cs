using WarehouseWithDb.Model;

namespace WarehouseWithDb.VievModel
{
    public class Connect
    {
        public void IsConnected(ApplicationContext context)
        {
            bool isCreated = context.Database.EnsureCreated();
            if (isCreated)
            {
                Console.WriteLine("База данных успешно создана\n");
            }
            Console.WriteLine("Работа с базой данных началась\n");
        }
    }
}
