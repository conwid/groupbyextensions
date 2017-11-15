using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByExtensions
{
    public class FuncEqualityComparer<T, TValue> : IEqualityComparer<T>
    {
        private readonly Func<T, TValue> extractorFunc;
        public FuncEqualityComparer(Func<T, TValue> extractorFunc)
        {
            this.extractorFunc = extractorFunc;
        }
        public bool Equals(T x, T y)
        {
            return extractorFunc(x).Equals(extractorFunc(y));
        }

        public int GetHashCode(T obj)
        {
            return extractorFunc(obj).GetHashCode();
        }
    }
}
