namespace AnimalFinder.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;
    private readonly IAccountService _accountService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(AppDbContext dbContextContext, IAccountService accountService, ILogger<AccountController> logger)
    {
        _logger = logger;
        _context = dbContextContext;
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var rezult = await _accountService.Login(model);
                if (rezult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Нет пользователя с таким логином и паролем");
            }
            catch
            {
                ModelState.AddModelError("", "Невозможно выполнить вход");
            }
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        var viewModel = new RegisterViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == viewModel.UserName);
            if (user == null)
            {
                await _accountService.Register(viewModel);

                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", "Пользователь с данным логином уже зарегестрирован");
        }
        return View(viewModel);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _accountService.Logout();
        return RedirectToAction("Login", "Account");
    }
}
