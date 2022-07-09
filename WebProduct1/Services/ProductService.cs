using Microsoft.EntityFrameworkCore;
using WebProduct1.Data;
using WebProduct1.Models;

namespace WebProduct1.Services
{
    public class ProductService : IProductService
    {

        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateProduct(Product product)
        {
            //_dataContext.Add<Product>(product);
            _dataContext.Product.Add(product);
            _dataContext.SaveChanges();
        }

        public bool DeleteProduct(int productId)
        {
            var ProductDel = GetProductId(productId);
            if(ProductDel == null)
            {
                return false;
            }
            else
            {
                _dataContext.Product.Remove(ProductDel);
                _dataContext.SaveChanges();
                return true;
            }
        }

        public Product GetProductId(int productId)
        {
            return _dataContext.Product
                .FirstOrDefault(p => p.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return _dataContext.Product
                .Include( product => product.Category)
                .ToList();
        }

        public List<Product> SearchProduct(ProductSearch productSearch)
        {
            return _dataContext.Product
                .Include(product => product.Category)
                .Where(product =>
                string.IsNullOrEmpty(productSearch.Keyword)
                || ((product.Name == null || product.Name.Contains(productSearch.Keyword))
                    || (product.Description == null || product.Description.Contains(productSearch.Keyword))
                    || (product.Size == null || product.Size.Contains(productSearch.Keyword))
                    || product.Price.ToString().Contains(productSearch.Keyword)))
                .Where(product =>
                    productSearch.categoryId == null
                    || productSearch.categoryId == product.CategoriesId)
                .ToList();
        }

        public void UpdateProduct(Product product)
        {
            var productUpdate = GetProductId(product.Id);
            if(productUpdate == null)
            {
                return;
            }
            else
            {
                productUpdate.Name = product.Name;
                productUpdate.Size = product.Size;
                productUpdate.Description = product.Description;
                productUpdate.Price = product.Price;
                productUpdate.CategoriesId = product.CategoriesId;
                _dataContext.SaveChanges();
            }
        }
    }

}
