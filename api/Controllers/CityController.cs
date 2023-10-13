namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly IMongoCollection<City> _collection;
    //Dependency Injection
    public CityController(IMongoClient client, IMongoDbSettings dbSettings)
    {
         var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<City>("cities");
    }
    [HttpPost("add-city")]
    public ActionResult<City> Create(City userInput)
    {
        City city = new City(
            Id : null,
            StateName : userInput.StateName
        );

        _collection.InsertOne(city);

        return city;
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
