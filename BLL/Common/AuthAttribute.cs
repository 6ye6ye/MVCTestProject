namespace BLL.Common;

public class AuthAttribute : AuthorizeAttribute
{
    private readonly string[] _roles;

    public AuthAttribute(params UserRoleEnum[] roles) : base()
    {
        Roles = string.Join(",", roles.Select(r => r));
    }
}
