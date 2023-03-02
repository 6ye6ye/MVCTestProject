using DomainLayer.SortParameters;
using System.ComponentModel;

namespace BLL.Services.Filter;

public static class FilterService
{
    public static Expression<Func<LostAnimal, bool>> GetFilterExpression(LostAnimalsFilterParam filterParam)
    {
        Expression<Func<LostAnimal, bool>> filter = animal =>
            (filterParam.PeriodBegin == null || animal.LostDate >= filterParam.PeriodBegin)
            && (filterParam.PeriodEnd == null || animal.LostDate <= filterParam.PeriodEnd);
        return filter;
    }

    //public static Expression<Func<LostAnimal, object>> GetSortExpression(LostAnimalsFilterParam filterParam)
    //{
    //    var sort = filterParam.SelectedSort;

    //    Expression<Func<LostAnimal, object>> sortExpression = sort switch
    //    {
    //        BaseAdSortParameter.LostDateNew => animal => animal.LostDate,
    //        BaseAdSortParameter.LostDateOld => animal => animal.LostDate,
    //        BaseAdSortParameter.DateAddNew => animal => animal.AddDate,
    //        BaseAdSortParameter.DateAddOld => animal => animal.AddDate,
    //        _ => throw new NotImplementedException()
    //    };

    //    return sortExpression;
    //}

    public static SortingStruct GetSortingStruct(BaseAdSortParameter param)
    {
        Expression<Func<LostAnimal, object>> sortExpression;
        ListSortDirection direction;
        switch (param)
        {
            case BaseAdSortParameter.LostDateNew:
                sortExpression = animal => animal.LostDate;
                direction = ListSortDirection.Descending;
                break;
            case BaseAdSortParameter.LostDateOld:
                sortExpression = animal => animal.LostDate;
                direction = ListSortDirection.Ascending;
                break;
            case BaseAdSortParameter.DateAddNew: 
                sortExpression = animal => animal.AddDate;
                direction = ListSortDirection.Descending;
                break;
            case BaseAdSortParameter.DateAddOld: 
                sortExpression = animal => animal.AddDate;
                direction = ListSortDirection.Ascending;
                break;
            default: throw new NotImplementedException();
        }

        return new SortingStruct
        {
            Expression = sortExpression,
            Direction = direction
        };

    }

}
