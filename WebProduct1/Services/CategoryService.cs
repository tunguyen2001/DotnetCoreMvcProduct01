using WebProduct1.Data;
using WebProduct1.Models;

namespace WebProduct1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dataContext;

        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Category> GetCategories()
        {
            return _dataContext.Categories.ToList();
        }
    }
}
