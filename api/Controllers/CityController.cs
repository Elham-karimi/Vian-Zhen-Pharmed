namespace api.Controllers;

public class CityController : BaseApiController
{
    private readonly ICityRepository _cityRepository;
    //Dependency Injection
    public CityController(ICityRepository cityRepository)
    {
       _cityRepository = cityRepository;
    }
    [HttpPost("add-city")]
    public async Task<ActionResult<City>> Create(City userInput,CancellationToken cancellationToken)
    {
     
    }

    [HttpGet("get-all-cities")]
    public ActionResult<List<City>> GetAll()
    {
        List<City> cities= _collection.Find<City> (new BsonDocument()).ToList();

        if(!cities.Any())
            return NoContent();
            
        return cities;
    }
}
