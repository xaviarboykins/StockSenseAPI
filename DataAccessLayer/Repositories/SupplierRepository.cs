using StockSense.DbContextFolder;
using StockSense.Model;

namespace StockSense.Repositories
{
    public class SupplierRepository
    {
        private readonly ProductDbContext _dbContext;

        public SupplierRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();
        }

        public Supplier GetSupplierById(int productId)
        {
            return _dbContext.Suppliers.FirstOrDefault(p => p.SupplierId == productId);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _dbContext.Suppliers.ToList();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Update(supplier);
            _dbContext.SaveChanges();
        }

        public void DeleteSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Remove(supplier);
            _dbContext.SaveChanges();
        }
    }
}
