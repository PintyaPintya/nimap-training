using Crud.Models;

public interface IProductRepository
{
    public Task<List<Product>> GetProducts(int page, int pageSize);
    public Task<bool> CheckProduct(Product product);
    public Task<bool> AddProduct(Product product);
    public Task<Product?> GetProduct(int id);
    public Task<bool> UpdateProduct(Product product);
    public Task<bool> DeleteProduct(Product product);
    public Task<int> GetProductCount();
}
