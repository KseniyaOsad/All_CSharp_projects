using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_tasks
{
    public static class Helper
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> list, Func<T, bool> predicat)
        {
            foreach (var item in list)
            {
                if (predicat.Invoke(item))
                {
                    yield return item;
                }
            }
        }
    }
}
