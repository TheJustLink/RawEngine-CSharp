using System;

namespace RawEngine.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsImplementation(this Type my, Type type)
        {
            return my.Equals(type) || type.IsAssignableFrom(my);
        }
    }
}