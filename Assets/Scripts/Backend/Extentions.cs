using System.Collections.Generic;
using System.Linq;

public static class Extentions {
    public static IDictionary<string, object> ToFirebaseDictionary<T>(this IEnumerable<T> items)
    {
        var resDictionary = new Dictionary<string, object>();
        var index = 0;
        foreach (var item in items)
        {
            resDictionary[index.ToString()] = item;
            index++;
        }

        return resDictionary;
    }

    public static IEnumerable<T> ToIEnumerable<T>(this IDictionary<string, object> items)
    {
        return items.Values.Cast<T>();
    }
}
