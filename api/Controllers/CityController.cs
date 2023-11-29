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
    public async Task<ActionResult<City?>> Create(CityDto userInput,CancellationToken cancellationToken)
    {
       City? city = await _cityRepository.CreateAsync(userInput, cancellationToken);

       if(city is null)
       return BadRequest("This City has already been Registered");

       return city;
    }

    [HttpGet("get-by-name/{cityName}")]

    public async Task<ActionResult<City>> GetByName (string cityName, CancellationToken cancellationToken)
    {
        City? city = await _cityRepository.GetByNameAsync(cityName, cancellationToken);

        if(city is null)
           return NotFound("The Desired City is not Found."); 

        return city;
    }

    [HttpGet("get-all-cities")]
    public async Task<ActionResult<IEnumerable<City>>> GetAll(CancellationToken cancellationToken)
    {
        List<City> cities = await _cityRepository.GetAllAsync(cancellationToken);

        if(!cities.Any())
            return NoContent();
            
        return cities;
    }
}
