using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RockMelon.Tools.Extension
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Author: Gareth R
        /// Takes a collection any objects and a list of funcs and generates a csv string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static string WriteCsvFileString<T>(this IEnumerable<T> collection, List<Func<T, object>> columns)
        {
            const string comma = ",";
            var sb = new StringBuilder();
            foreach (var item in collection)
            {
                foreach (var column in columns)
                {
                    sb.Append(column.Invoke(item));
                    sb.Append(comma);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// returns true if contains elements
        /// deals with null etc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool ContainsElements<T>(this IEnumerable<T> collection)
        {
            try
            {
                if (collection != null && collection.Any())
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Foreach
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        //public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        //{
        //    foreach (T item in items)
        //    {
        //        action(item);
        //    }
        //}
    }
}
