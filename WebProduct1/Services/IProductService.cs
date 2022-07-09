using WebProduct1.Models;

namespace WebProduct1.Services
{
    public interface IProductService
    {

        Product GetProductId(int productId);

        List<Product> GetProducts();

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        bool DeleteProduct(int productId);

        List<Product> SearchProduct(ProductSearch productSearch);
    }
}
