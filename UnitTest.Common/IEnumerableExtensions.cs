using System;
using System.Collections.Generic;

namespace Gongchengshi.UnitTest
{
    public static class IEnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> @this)
        {
            foreach (var item in @this)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
