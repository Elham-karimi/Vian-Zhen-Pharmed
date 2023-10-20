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
    public async Task<ActionResult<IEnumerable<UserDto?>>> GetAll(CancellationToken cancellationToken)
    {
        List<UserDto>? appUsers = await _adminRepository.GetAllAsync(cancellationToken);

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
    public async Task<ActionResult<UserDto>> GetUserById(string userId, CancellationToken cancellationToken)
    {

        UserDto userDto = await _adminRepository.GetَUserbyIdAsync(userId, cancellationToken);

        if (userDto is null)
            return NotFound("No user with This Id found");

        return userDto;
    }
}
