namespace BLL.Services.Account;

public interface IAccountService
{
    public Task<IList<string>> GetUserRoles(string id);

    public Task<IdentityResult> Register(RegisterViewModel registerDto);

    public Task<SignInResult> Login(LoginViewModel registerDto);

    public Task Logout();
}
