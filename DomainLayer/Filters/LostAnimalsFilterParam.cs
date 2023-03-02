using DomainLayer.Enums;
using DomainLayer.SortParameters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Filters;

public class LostAnimalsFilterParam
{
    [Display(Name = "Начало периода")]
    [BindProperty, DataType(DataType.Date)]
    public DateTime? PeriodBegin { get; set; }

    [Display(Name = "Конец периода")]
    [BindProperty, DataType(DataType.Date)]
    public DateTime? PeriodEnd { get; set; }


    [Display(Name = "Количество на странице")]
    public ItemsCountPerPage ItemsCount { get; set; }

    [Display(Name = "Сортировка")]
    public BaseAdSortParameter Sort { get; set; }
}
