using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Extensions
{
    public static class IListExtensions
    {
        public static void AddRange<T>(this IList<T> iList, IEnumerable<T> range)
        {
            foreach (T item in range)
                iList.Add(item);
        }
    }
}
