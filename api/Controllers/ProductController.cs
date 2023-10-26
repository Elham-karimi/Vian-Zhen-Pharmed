namespace api.Controllers;

public class ProductController : BaseApiController
{

    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost("add-product")]
    public async Task<ActionResult<Product>> Create(Product product)
    {
       
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
        .Set(doc => doc.SpecificSpecification.ProductType, productIn.SpecificSpecification.ProductType)
        .Set(doc => doc.SpecificSpecification.ConsumerGroup, productIn.SpecificSpecification.ConsumerGroup)
        .Set(doc => doc.SpecificSpecification.UsageCases, productIn.SpecificSpecification.UsageCases)
        .Set(doc => doc.SpecificSpecification.Dosage, productIn.SpecificSpecification.Dosage)
        .Set(doc => doc.SpecificSpecification.Combination, productIn.SpecificSpecification.Combination);

        return _collection.UpdateOne<Product>(doc => doc.Id == productId, updatedProduct);
    }

    [HttpDelete("delete/{productId}")]
    public ActionResult<DeleteResult> Delete(string prodectId)
    {
        return _collection.DeleteOne<Product>(doc => doc.Id == prodectId);
    }
}

