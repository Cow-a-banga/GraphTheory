using System.Collections.Generic;
using System.Linq;
using GraphDomain;

namespace Extensions
{
    public static class Extensions
    {
        public static IEnumerable<int> GetWeightOrZero(this IEnumerable<Edge> enumerable, IEnumerable<int> endNums)
        {
            return endNums.Select(num => enumerable.FirstOrDefault(e => e.EndNumber == num)?.Data ?? 0);
        }
    }
}