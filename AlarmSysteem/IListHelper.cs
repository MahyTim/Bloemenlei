using System.Collections.Generic;

namespace Beveiliging
{
    public static class IListHelper
    {
        public static T AddAndReturn<T>(this IList<T> list, T item)
        {
            list.Add(item);
            return item;
        }
    }
}