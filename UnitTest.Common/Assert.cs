using System.Collections.Generic;
using System.Linq;

using VSAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System;

namespace Gongchengshi.UnitTest
{
   public static class Assert
   {
      public static void AreCollectionsEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
      {
         VSAssert.AreEqual(expected.Count(), actual.Count());

         var actualEnumerator = actual.GetEnumerator();

         foreach (var expectedItem in expected)
         {
            actualEnumerator.MoveNext();
            VSAssert.AreEqual(expectedItem, actualEnumerator.Current);
         }
      }

      public static void AreCollectionsEqual<T>(ICollection<T> expected, ICollection<T> actual)
      {
         VSAssert.AreEqual(expected.Count, actual.Count);

         var actualEnumerator = actual.GetEnumerator();

         foreach (var expectedItem in expected)
         {
            actualEnumerator.MoveNext();
            VSAssert.AreEqual(expectedItem, actualEnumerator.Current);
         }
      }

      public static void AreEqual<T>(params T[] args)
      {
         if (args.Length < 2)
         {
            return;
         }

         T arg1 = args[0];

         for (int i = 1; i < args.Length; ++i)
         {
            VSAssert.AreEqual(arg1, args[i]);
         }
      }

      public static void AreEqual<T, P>(IEnumerable<T> collection, Func<T, P> getMember)
      {
         P first = getMember(collection.First());

         foreach (var item in collection)
         {
            var member = getMember(item);
            VSAssert.AreEqual(first, member);
         }
      }
   }
}
