using System.Collections;
using Microsoft.AspNetCore.Components.Web;

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

    public async Task<Product?> CreateAsync(ProductDto adminInput, CancellationToken cancellationToken)
    {
        bool doseProductExist = await _collection.Find<Product>(product =>
            product.PersianName == adminInput.PersianName.ToLower().Trim()).AnyAsync(cancellationToken);

        if (doseProductExist)
            return null;

        Product product = new Product(
         Id: null,
         PersianName: adminInput.PersianName,
         EnglishName: adminInput.EnglishName,
         ShortDescription: adminInput.ShortDescription,
         UsageCases: adminInput.UsageCases,
         ProductType: adminInput.ProductType,
         ConsumerGroup: adminInput.ConsumerGroup,
         Dosage: adminInput.Dosage,
         TypeOfCombination: adminInput.TypeOfCombination,
         Combination: new Combination(
            Title: adminInput.Combination.Title,
            Amount : adminInput.Combination.Amount   
         )
      );

        if (_collection is not null)
            await _collection.InsertOneAsync(product, null, cancellationToken);

        return product;
    }

    public async Task<Product?> GetByNameAsync(string productName, CancellationToken cancellationToken)
    {
        Product product = await _collection.Find<Product>(pro => pro.PersianName == productName).FirstOrDefaultAsync(cancellationToken);

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

    public async Task<UpdateResult?> UpdateByIdAsync(string productId, Product productIn, CancellationToken cancellationToken)
    {
        var updatedProduct = Builders<Product>.Update
       .Set((Product doc) => doc.PersianName, productIn.PersianName)
       .Set(doc => doc.EnglishName, productIn.EnglishName)
       .Set(doc => doc.ShortDescription, productIn.ShortDescription)
       .Set(doc => doc.UsageCases, productIn.UsageCases)
       .Set(doc => doc.ProductType, productIn.ProductType)
       .Set(doc => doc.ConsumerGroup, productIn.ConsumerGroup)
       .Set(doc => doc.TypeOfCombination,productIn.TypeOfCombination)
       .Set(doc => 
            .Set(doc.Combination, productIn.Combination.Title) 
            .Set(doc.Combination, productIn.Combination.Amount)
       );
            if (_collection is not null)
            return await _collection.UpdateOneAsync<Product>((doc => doc.Id == productIn.Id), updatedProduct, null, cancellationToken);

        return null;
       }    
    }

public async Task<DeleteResult> DeleteByIdAsync(string productId, CancellationToken cancellationToken)

 => await ICollection.DeleteOneAsync<Product>(doc => doc.Id == productId);


}
