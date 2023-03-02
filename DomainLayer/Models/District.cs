namespace DomainLayer.Models;

public class District : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set;}

    public virtual ICollection<LostAnimal>? LostAnimals { get; set; }
}
