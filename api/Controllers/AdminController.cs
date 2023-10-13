namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IMongoCollection<Admin> _collection;
    // Dependency Injection
    public AdminController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Admin>("admins");
    }

    [HttpPost("register")]
    public ActionResult<Admin> Create(Admin adminIn)
    {
        Admin admin = new Admin(
            Id: null,
            Email: adminIn.Email,
            Password: adminIn.Password,
            ConfirmPassword: adminIn.ConfirmPassword
        );

        _collection.InsertOne(admin);

        return admin;
    }

    [HttpPost("login")]
    public ActionResult<Admin> Login(Admin adminIn)
    {
        Admin admin = _collection.Find<Admin>(doc => doc.Email == adminIn.Email && doc.Password == adminIn.Password).FirstOrDefault();

        if (admin is null)
            return Unauthorized("Wrong username or password");

        return admin;
    }
}
