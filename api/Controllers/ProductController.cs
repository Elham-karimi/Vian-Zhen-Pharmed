namespace api.Controllers;

public class ProductController : BaseApiController
{

    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost("add-product")]
    public async Task<ActionResult<Product>> Register(Product product, CancellationToken cancellationToken)
    {
       Product? product1 = await _productRepository.CreateAsync(product,cancellationToken);

       if(product1 is null)
        return BadRequest("This product has already been Registered");

        return product1;
    }

    [HttpGet("get-by-name/{productName}")]
    public async Task<ActionResult<Product>> GetByName(string productName, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByNameAsync(productName , cancellationToken);

        if (product is null)
            return NotFound("The Desired Product was not Found.");
        
        return product;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product?>>> GetAll(CancellationToken cancellationToken)
    {
        List<Product> products = await _productRepository.GetAllAsync(cancellationToken);

        if (!products.Any())
            return NoContent();
        
        return products;
    }

    [HttpPut("update/{productId}")]
    public async Task<ActionResult<UpdateResult?>> UpdateProductById(string productId, Product productIn, CancellationToken cancellationToken)
    {
       UpdateResult? updateResult =await _productRepository.UpdateByIdAsync(productId, productIn, cancellationToken);

       return updateResult;
    }

    [HttpDelete("delete/{productId}")]
    public async Task<ActionResult<DeleteResult>> DeleteProductById(string productId, CancellationToken cancellationToken)
    {
        DeleteResult deleteResult = await _productRepository.DeleteByIdAsync(productId,cancellationToken);

        return deleteResult;
    }
}

