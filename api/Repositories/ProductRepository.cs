

namespace api.Repositories;

public class ProductRepository : IProductRepository
{
    private const string _collectionName = "products";

    private readonly IMongoCollection<Product>? _collection;

    public ProductRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Product>(_collectionName);
    }

    public async Task<Product?> CreateAsync(Product adminInput, CancellationToken cancellationToken)
    {
        bool doseProductExist = await _collection.Find<Product>(product =>
            product.Name == adminInput.Name.ToLower().Trim()).AnyAsync(cancellationToken);

        if (doseProductExist)
            return null;

        Product product = new Product(
          Id: null,
          Name: adminInput.Name,
          ShortDescription: adminInput.ShortDescription,
          SpecificSpecification: new SpecificSpecification(
              ProductType: adminInput.SpecificSpecification.ProductType,
              ConsumerGroup: adminInput.SpecificSpecification.ConsumerGroup,
              UsageCases: adminInput.SpecificSpecification.UsageCases,
              Dosage: adminInput.SpecificSpecification.Dosage,
              Combination: adminInput.SpecificSpecification.Combination
          )
      );

        if (_collection is not null)
            await _collection.InsertOneAsync(product, null, cancellationToken);

        return product;
    }

    public async Task<Product?> GetByNameAsync(string productName, CancellationToken cancellationToken)
    {
        Product product = await _collection.Find<Product>(pro => pro.Name == productName).FirstOrDefaultAsync();

        if (product is null)
            return null;

        return product;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<Product> products = await _collection.Find<Product>(new BsonDocument()).ToListAsync(cancellationToken);

        if (products.Any())
            return products;

        return products;
    }

    public async Task<UpdateResult> UpdateByIdAsync(string prodectId, Product productIn, CancellationToken cancellationToken)
    {
        var updatedProduct = Builders<Product>.Update
       .Set((Product doc) => doc.Name, productIn.Name)
       .Set(doc => doc.ShortDescription, productIn.ShortDescription)
       .Set(doc => doc.SpecificSpecification.ProductType, productIn.SpecificSpecification.ProductType)
       .Set(doc => doc.SpecificSpecification.ConsumerGroup, productIn.SpecificSpecification.ConsumerGroup)
       .Set(doc => doc.SpecificSpecification.UsageCases, productIn.SpecificSpecification.UsageCases)
       .Set(doc => doc.SpecificSpecification.Dosage, productIn.SpecificSpecification.Dosage)
       .Set(doc => doc.SpecificSpecification.Combination, productIn.SpecificSpecification.Combination);

        if (_collection is not null)
            return await _collection.UpdateOneAsync<Product>((doc => doc.Id == productIn.Id), updatedProduct, null, cancellationToken);

        return null;
    }

    public async Task<DeleteResult> DeleteByIdAsync(string productId, CancellationToken cancellationToken)
    {
        return await _collection.DeleteOneAsync<Product>(doc => doc.Id == productId);
    }


}
