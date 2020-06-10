using System.Collections.Generic;
using System.Reflection;

namespace RawEngine.Extensions
{
    public static class ListExtensions
    {
        public static T[] GetRawElements<T>(this List<T> list)
        {
            return (T[])
                typeof(List<T>)
                   .GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance)
                   .GetValue(list);
        }
    }
}