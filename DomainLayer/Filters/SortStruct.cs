using DomainLayer.Models;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DomainLayer.Filters;

public struct SortingStruct
{
    public ListSortDirection Direction;
    public Expression<Func<LostAnimal, object>> Expression;
}