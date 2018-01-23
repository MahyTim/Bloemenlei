using System.Collections.Generic;

namespace Beveiliging
{
    public static class IListHelper
    {
        public static TItem AddAndReturn<TList,TItem>(this IList<TList> list, TItem item) where TItem : TList
        {
            list.Add(item);
            return item;
        }
    }
}