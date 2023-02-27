using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DomainLayer.Filters;

public interface IFilterableViewModel<TFilter>
{
    [Display(Name = "Фильтр")]
    public TFilter ListFilter { get; set; }
}
