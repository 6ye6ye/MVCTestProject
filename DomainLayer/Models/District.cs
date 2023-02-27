namespace DomainLayer.Models;

public class District : BaseEntity
{
    public string Name { get; set;}

    public virtual ICollection<LostAnimal>? LostAnimals { get; set; }
}
