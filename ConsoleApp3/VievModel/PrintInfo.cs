using WarehouseWithDb.Model;

namespace WarehouseWithDb.VievModel
{
    public class PrintInfo
    {
        public void PrintWarehouse(ApplicationContext context)
        {            
            var warehouses = context.Warehouses.ToList();
            foreach (WarehouseDb w in warehouses)
            {
                w.Print();
            }
            
        }
        public void PrintCompany(ApplicationContext context)
        {
            var companies = context.Companies.ToList();
            foreach (CompanyDb c in companies)
            {
                c.Print();
            }
        }
    }
}