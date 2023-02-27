using DomainLayer.Dtos;
using DomainLayer.Filters;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels;

public class LostAnimalListViewModel : IValidatableObject, IFilterableViewModel<LostAnimalsFilterParam>
{
    [Display(Name = "Наименование")]
    public IEnumerable<LostAnimalDtoGetShort>? LostAnimals { get; set; }
    public LostAnimalsFilterParam ListFilter { get; set; } = new();

    IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
        List<ValidationResult> res = new List<ValidationResult>();
        if (ListFilter.PeriodEnd < ListFilter.PeriodBegin)
        {
            ValidationResult mss = new ValidationResult("Начало периода не может быть пойже конца  периода");
            res.Add(mss);
        }
        return res;
    }
}
