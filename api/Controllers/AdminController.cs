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
    public async Task<ActionResult<IEnumerable<AdminDto?>>> GetAll(CancellationToken cancellationToken)
    {
        List<AdminDto>? appUsers = await _adminRepository.GetAllAsync(cancellationToken);

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
    public async Task<ActionResult<AdminDto>> GetUserById(string userId, CancellationToken cancellationToken)
    {

        AdminDto? adminDto = await _adminRepository.GetَUserbyIdAsync(userId, cancellationToken);

        if (adminDto is null)
            return NotFound("No user with This Id found");

        return adminDto;
    }
}
