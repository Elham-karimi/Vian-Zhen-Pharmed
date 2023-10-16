namespace api.Controllers;


public class ProductController : BaseApiController
{
    private readonly IMongoCollection<Product> _collection;
    //Dependency Injection
    public ProductController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Product>("products");
    }

    [HttpPost("add-product")]
    public ActionResult<Product> Create(Product product)
    {
        Product pro = new Product(
            Id: null,
            Name: product.Name,
            ShortDescription: product.ShortDescription,
            SpecificSpecification: new SpecificSpecification(
                ProductType: product.SpecificSpecification.ProductType,
                ConsumerGroup: product.SpecificSpecification.ConsumerGroup,
                UsageCases: product.SpecificSpecification.UsageCases,
                Dosage: product.SpecificSpecification.Dosage,
                Combination: product.SpecificSpecification.Combination
            )
        );
        _collection.InsertOne(pro);

        return pro;
    }

    [HttpGet("get-by-name/{productName}")]
    public ActionResult<Product> GetByName(string productName)
    {
        Product product = _collection.Find<Product>(doc => doc.Name == productName).FirstOrDefault();

        if (product == null)
        {
            return NotFound("The Desired Product was not Found.");
        }
        return product;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        List<Product> products = _collection.Find<Product>(new BsonDocument()).ToList();

        if (!products.Any())
        {
            return NoContent();
        }
        return products;
    }
    [HttpPut("update/{prodectId}")]
    public ActionResult<UpdateResult> UpdateProductById(string productId, Product productIn)
    {
        var updatedProduct = Builders<Product>.Update
        .Set((Product doc) => doc.Name, productIn.Name)
        .Set(doc => doc.ShortDescription, productIn.ShortDescription)
        .Set(doc => doc.SpecificSpecification.ProductType , productIn.SpecificSpecification.ProductType)
        .Set(doc => doc.SpecificSpecification.ConsumerGroup , productIn.SpecificSpecification.ConsumerGroup)
        .Set(doc => doc.SpecificSpecification.UsageCases , productIn.SpecificSpecification.UsageCases)
        .Set(doc => doc.SpecificSpecification.Dosage , productIn.SpecificSpecification.Dosage)
        .Set(doc => doc.SpecificSpecification.Combination , productIn.SpecificSpecification.Combination);
 
        return _collection.UpdateOne<Product>(doc => doc.Id == productId , updatedProduct);
    }

    [HttpDelete("delete/{productId}")]
    public ActionResult<DeleteResult> Delete(string prodectId)
    {
        return _collection.DeleteOne<Product>(doc => doc.Id == prodectId);
    }
}

