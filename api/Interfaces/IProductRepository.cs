namespace api.Interfaces;

public interface IProductRepository
{
    public Task<Product?> CreateAsync(Product adminInput, CancellationToken cancellationToken);

    public Task<Product?> GetByNameAsync(string productName, CancellationToken cancellationToken);

    public Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);

    public Task<UpdateResult> UpdateByIdAsync(string productId,Product product, CancellationToken cancellationToken);
    
    public Task<DeleteResult> DeleteByIdAsync(string productId, CancellationToken cancellationToken);
}
