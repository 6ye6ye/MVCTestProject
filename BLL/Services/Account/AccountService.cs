namespace BoardGameManager1.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    //public AccountService()
    //{
    //}

    public AccountService(IMapper mapper, UserManager<User> userManager,
        SignInManager<User> signInManager, AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<string>> GetUserRoles(string id)
    {
        var user = await _context.Users.FindAsync(new Guid(id));
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<IdentityResult> Register(RegisterViewModel registerDTO)
    {
        var user = _mapper.Map<User>(registerDTO);
        var result = await _userManager.CreateAsync(user, registerDTO.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, UserRoleEnum.User.ToString());
            await _signInManager.SignInAsync(user, false);
        }

        return result;
    }

    public async Task<SignInResult> Login(LoginViewModel registerViewModel)
    {
        var user = _mapper.Map<User>(registerViewModel);
        return await _signInManager.PasswordSignInAsync(
            user.UserName, registerViewModel.Password, true, false);
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}