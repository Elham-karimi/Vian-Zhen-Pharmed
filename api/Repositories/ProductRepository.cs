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

    public async Task<Product> CreateAsync(Product adminInput, CancellationToken cancellationToken)
    {
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

      if(_collection is not null)
         await _collection.InsertOneAsync(product, null, cancellationToken);

        return product;

    }

}
