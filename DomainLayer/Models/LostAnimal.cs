using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enums;

namespace DomainLayer.Models;

public class LostAnimal : BaseEntity
{
    public AnimalTypeEnum AnimalType { get; set; }
    public string? AnimalName { get; set; }
    public string? Info { get; set; }
    public Guid? DistrictId { get; set; }
    public string Phone { get; set; }
    public DateTime LostDate { get; set; }
    public string? PhotoPath { get; set; }

    [ForeignKey("DistrictId")]
    public virtual District? District { get; set; }
}