using System;
using System.Collections.Generic;

namespace MyMethods
{
    public static class MyMethods
    {
        internal static T Find<T>(T[] values, Predicate<T> predicate)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (predicate(values[i]))
                {
                    return values[i];
                }
            }
            return default(T);
        }

        internal static T FindLast<T>(T[] values, Predicate<T> predicate)
        {
            int index = -1;
            for (int i = 0; i < values.Length; i++)
            {
                if (predicate(values[i]))
                {
                    index = i;
                }
            }            
            return index >= 0? values[index] : default(T);
        }

        internal static List<T> FindAll<T>(T[] values, Predicate<T> predicate)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < values.Length; i++)
            {
                if (predicate(values[i]))
                {
                    result.Add(values[i]);
                }
            }
            return result;
        }

        internal static bool TrueForAll<T>(T[] values, Predicate<T> predicate)
        {
            int counter = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (predicate(values[i]))
                {
                    counter++;
                }
            }
            return counter == values.Length ? true : false;
        }

        internal static bool Exists<T>(T[] v, Predicate<T> predicate)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (predicate(v[i]))
                {
                    return true;
                }
            }
            return false;
        }

        internal static int FindLastIndex<T>(T[] values, Predicate<T> predicate)
        {
            int index = -1;
            for (int i = 0; i < values.Length; i++)
            {
                if (predicate(values[i]))
                {
                    index = i;
                }
            }
            return index;
        }

        internal static int FindIndex<T>(T[] values, Predicate<T> predicate)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (predicate(values[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
