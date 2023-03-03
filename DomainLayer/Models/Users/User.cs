using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Models;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public virtual IEnumerable<LostAnimal> LostAnimalRecords { get; set; }
}