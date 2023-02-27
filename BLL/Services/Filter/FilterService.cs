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
}
