using System;
using System.Collections.Generic;

namespace uttne.Linq
{
    public static class Enumerable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> PutIn<T>(this IEnumerable<T> source ,T item )
        {
            foreach (var value in source)
            {
                yield return value;
            }
            yield return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> PutIn<T>(this IEnumerable<T> source,int index, T item)
        {
            if(index <= 0)
                yield return item;

            foreach (var value in source)
            {
                yield return value;

                --index;
                if (index == 0)
                    yield return item;
            }

            if(0 < index)
                yield return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> PutIn<T>(this IEnumerable<T> source, int index, IEnumerable<T> items)
        {
            if (index <= 0)
            {
                foreach (var item in items)
                {
                    yield return item;
                }
            }

            foreach (var value in source)
            {
                yield return value;

                --index;
                if (index == 0)
                {
                    foreach (var item in items)
                    {
                        yield return item;
                    }
                }
            }

            if (0 < index)
            {
                foreach (var item in items)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> source,int index, T item)
        {
            foreach (var value in source)
            {
                if (0 <= index && index-- == 0)
                    yield return item;
                else
                    yield return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, Func<T,bool> selector , T item)
        {
            if(selector == null)
                throw new ArgumentNullException($"'{nameof(selector)}' is not nullable.");

            foreach (var value in source)
            {
                if (selector(value))
                    yield return item;
                else
                    yield return value;
            }
        }
    }
}
