using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DomainLayer.SortParameters;

public enum BaseAdSortParameter
{
    [Display(Name = "Сначала новые")]
    DateAddNew,
    [Display(Name = "Сначала старые")]
    DateAddOld,
    [Display(Name = "Сначала недавно потерявшиеся")]
    LostDateNew,
    [Display(Name = "Сначала давно потерявшиеся")]
    LostDateOld,
}