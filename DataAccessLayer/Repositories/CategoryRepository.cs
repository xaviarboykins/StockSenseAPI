using StockSense.DbContextFolder;
using StockSense.Model;

namespace StockSense.Repositories
{
    public class CategoryRepository
    {
        private readonly ProductDbContext _dbContext;

        public CategoryRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
    }

}
