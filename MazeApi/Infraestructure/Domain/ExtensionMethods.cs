using System.Collections;
using System.Collections.Generic;

namespace Extensions
{
    public static class ExtensionMethods
    {
        public static T GetRandomElement<T>(this IList source, Random rnd)
        {
            return (T)source[rnd.Next(source.Count)];
        }
        public static bool IsEven(this int source)
        {
            return source % 2 != 0;
        }
        public static bool IsOdd(this int source)
        {
            return source % 2 == 0;
        }
    }
}