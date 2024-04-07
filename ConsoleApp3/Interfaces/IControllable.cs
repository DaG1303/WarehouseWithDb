namespace WarehouseWithDb.Interfaces
{
    public interface IControllable
    {
        abstract void AddProduct();
        abstract void ReadProduct();
        abstract void UpdateProduct();
        abstract void DeleteProduct();
    }
}
