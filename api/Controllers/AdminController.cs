namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IMongoCollection<AppUser> _collection;
    // Dependency Injection
    public AdminController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("admins");
    }

    [HttpPost("register")]
    public ActionResult<AppUser> Create(AppUser adminIn)
    {
        AppUser admin = new AppUser(
            Id: null,
            Email: adminIn.Email,
            Password: adminIn.Password,
            ConfirmPassword: adminIn.ConfirmPassword
        );

        _collection.InsertOne(admin);

        return admin;
    }

    [HttpPost("login")]
    public ActionResult<AppUser> Login(AppUser adminIn)
    {
        AppUser admin = _collection.Find<AppUser>(doc => doc.Email == adminIn.Email && doc.Password == adminIn.Password).FirstOrDefault();

        if (admin is null)
            return Unauthorized("Wrong username or password");

        return admin;
    }
}
