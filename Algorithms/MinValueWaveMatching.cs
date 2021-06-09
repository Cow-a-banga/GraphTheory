using System.Collections.Generic;
using System.Linq;
using GraphDomain;

namespace Algorithms
{
    public class MinValueWaveMatching
    {
        public static IEnumerable<IEnumerable<int>> Match(Graph graph)
        {
            var matrix = graph.GetDualMatrix().Select(e=>e.ToList()).ToList();
            HorizontalReduction(matrix);
            VerticalReduction(matrix);
            return matrix;
        }

        private static void  HorizontalReduction(List<List<int>> matrix)
        {
            for (var i = 0;i< matrix.Count; i++)
            {
                var min = matrix.Select((t, j) => matrix[i][j]).Min();
                
                for (var j = 0; j < matrix.Count; j++)
                    matrix[i][j] -= min;
            }
        }
        
        private static void VerticalReduction(List<List<int>> matrix)
        {
            for (var i = 0; i < matrix.Count; i++)
            {
                var min = matrix.Select(t => t[i]).Min();

                foreach (var t in matrix)
                    t[i] -= min;
            }
        }
    }
}