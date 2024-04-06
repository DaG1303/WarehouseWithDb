using WarehouseWithDb.Model;

namespace WarehouseWithDb.Viev
{
    public class PrintInfo
    {
        public void Print(ApplicationContext context)
        {
            var companies = context.Companies.ToList();
            var warehouses = context.Warehouses.ToList();
            foreach (WarehouseDb w in warehouses)
            {
                w.Print();
            }
            foreach (CompanyDb c in companies)
            {
                c.Print();
            }
        }
    }
}
