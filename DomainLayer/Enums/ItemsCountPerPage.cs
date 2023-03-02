using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace DomainLayer.Enums;

public enum ItemsCountPerPage
{
    [Display(Name = "20")]
    Twenty = 20,
    [Display(Name = "40")]
    Forty = 40,
    [Display(Name = "60")]
    Sixty = 60,
}
