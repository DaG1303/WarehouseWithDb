namespace WarehouseWithDb
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Supplier { get; set; }
        public Company? Company { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
