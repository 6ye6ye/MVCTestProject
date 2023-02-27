namespace BLL.Converters;

public static class EnumToSelectListConverter
{
    public static IEnumerable<SelectListItem> GetEnumSelectList<T>() where T : Enum
    {
        return from T e in Enum.GetValues(typeof(T))
               select new SelectListItem
               {
                   Value = Convert.ToInt32(e).ToString(),
                   Text = e.ToString()
               };
    }
}

