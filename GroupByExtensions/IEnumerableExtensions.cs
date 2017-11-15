using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByExtensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey, TExtractor>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TExtractor> extractorFunc)
        {
            return source.GroupBy(keySelector, new FuncEqualityComparer<TKey, TExtractor>(extractorFunc));
        }
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement, TExtractor>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TExtractor> extractorFunc)
        {
            return source.GroupBy(keySelector, elementSelector, new FuncEqualityComparer<TKey, TExtractor>(extractorFunc));
        }
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult, TExtractor>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, Func<TKey, TExtractor> extractorFunc)
        {
            return source.GroupBy(keySelector, resultSelector, new FuncEqualityComparer<TKey, TExtractor>(extractorFunc));
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult, TExtractor>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, Func<TKey, TExtractor> extractorFunc)
        {
            return source.GroupBy(keySelector, elementSelector, resultSelector, new FuncEqualityComparer<TKey, TExtractor>(extractorFunc));
        }

    }
}
