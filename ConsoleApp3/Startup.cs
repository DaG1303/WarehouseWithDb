using WarehouseWithDb.Viev;
namespace WarehouseWithDb
{
    public class Startup
    {
        static void Main(string[] args)
        {
            VievDb vievDb = new VievDb();
            vievDb.Viev();
        }
    }
}