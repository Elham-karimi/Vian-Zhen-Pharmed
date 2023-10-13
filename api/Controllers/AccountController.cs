
namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMongoCollection<Signup> _collection;
    // Dependency Injection
    public AccountController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Signup>("users");
    }

    [HttpPost("register")]
    public ActionResult<Signup> Create(Signup userInput)
    {
        bool hasDocs = _collection.AsQueryable().Where<Signup>(p => p.Name == userInput.Name).Any();

        if (hasDocs)
            return BadRequest($"A User with Name {userInput.Name} is already registered.");

        Signup user = new Signup(
            Id: null,
            Name: userInput.Name?.Trim(),
            Email: userInput.Email.ToLower().Trim(),
            Password: userInput.Password.Trim(),
            ConfirmPassword: userInput.ConfirmPassword.Trim()
        );

        _collection.InsertOne(user);

        return user;
    }

    [HttpPost("login")]
    public ActionResult<Signup> Login(Login userInput)
    {
        Signup user = _collection.Find<Signup>(doc => doc.Email == userInput.Email && doc.Password == userInput.Password).FirstOrDefault();

        if (user is null)
            return Unauthorized("Wrong username or password");

        return user;
    }

    [HttpGet("get-all")]
    public ActionResult<IEnumerable<Signup>> GetAll()
    {
        List<Signup> signUps = _collection.Find<Signup>(new BsonDocument()).ToList();

        if (!signUps.Any())
            return NoContent();

        return signUps;
    }

    [HttpPut("update/{userId}")]
    public ActionResult<UpdateResult> UpdateUserById(string userId, Signup signUpIn)
    {
        var UpdatedUser = Builders<Signup>.Update
        .Set((Signup doc) => doc.Name, signUpIn.Name)
        .Set(doc => doc.Email, signUpIn.Email.ToLower().Trim())
        .Set(doc => doc.Password, signUpIn.Password);

        return _collection.UpdateOne<Signup>(doc => doc.Id == userId, UpdatedUser);
    }

    [HttpDelete("delete/{userId}")]
    public ActionResult<DeleteResult> DeleteUserById(string userId)
    {
        return _collection.DeleteOne<Signup>(doc => doc.Id == userId);
    }
}
