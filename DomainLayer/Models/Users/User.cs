using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models;

public class User : IdentityUser<Guid>
{
}