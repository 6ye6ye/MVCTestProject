using BLL.UnitOfWorks;
using BoardGameManager1.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BLL;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        container.RegisterType<IAccountService, AccountService>();
        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
}