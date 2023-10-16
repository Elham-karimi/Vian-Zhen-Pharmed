namespace api.Controllers;

public class AdminController : BaseApiController
{
    private readonly IAdminRepository _adminRepository;

    public AdminController(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    //  <summary>
    /// GetAll Users
    /// Concurrency => async is used
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>IEnumerable<AppUser></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser?>>> GetAll(CancellationToken cancellationToken)
    {
        List<AppUser>? appUsers = await _adminRepository.GetAll(cancellationToken);

        if (!appUsers.Any())
            return NoContent();

        return appUsers;
    }

    /// <summary>
    ///Get User By Id
    ///Concurrency => async is used
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>AppUser</returns>
    [HttpGet("get-by-id/{userId}")]
    public async Task<ActionResult<AppUser>> GetUserById(string userId, CancellationToken cancellationToken)
    {

        AppUser appUser = await _adminRepository.Get(userId, cancellationToken);

        if (appUser is null)
            return NotFound("No user with This Id found");

        return appUser;
    }
}
