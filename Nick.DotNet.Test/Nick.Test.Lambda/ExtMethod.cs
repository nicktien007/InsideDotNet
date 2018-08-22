using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test.Lambda
{
   public  static class ExtMethod
    {
        /// <summary>
        /// 自訂一個where
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereExt2<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
