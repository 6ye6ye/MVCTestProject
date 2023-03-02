using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace DomainLayer.Enums;

public enum AnimalTypeEnum
{
    [Display(Name = "Кошка")]
    Cat,
    [Display(Name = "Собака")]
    Dog,
    [Display(Name = "Птица")]
    Bird
}
