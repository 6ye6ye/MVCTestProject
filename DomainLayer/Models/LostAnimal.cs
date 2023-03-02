using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enums;

namespace DomainLayer.Models;

public class LostAnimal : IBaseEntity
{
    public Guid Id { get; set; }
    public AnimalTypeEnum AnimalType { get; set; }
    public string? AnimalName { get; set; }
    public string? Info { get; set; }
    public Guid? DistrictId { get; set; }
    public string Phone { get; set; }
    public DateTime LostDate { get; set; }
    public string? PhotoPath { get; set; }

    public DateTime AddDate { get; set; }

    [ForeignKey("DistrictId")]
    public virtual District? District { get; set; }
}