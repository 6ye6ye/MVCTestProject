using DomainLayer.Dtos;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels;

public class DistrictViewModel : DistrictDtoGet
{
    [Display(Name = "Наименование")]
    public string Name { get; set; }
}
