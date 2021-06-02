using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms;
using Extensions;
using Exceptions;

namespace GraphDomain
{
    public class Graph
    {
        private bool isOriented;
        private List<Vertex> vertices;

        public IEnumerable<Vertex> Vertices => vertices;

        public Graph()
        {
            vertices = new List<Vertex>();
            isOriented = false;
        }
        
        public Graph(bool isOriented)
        {
            this.isOriented = isOriented;
            vertices = new List<Vertex>();
        }

        public Graph(int n, bool isOriented)
        {
            InitEmptyGraph(n,isOriented);
        }

        private void InitEmptyGraph(int n, bool isOriented)
        {
            if (n <= 0)
                throw new NotPositiveVertexCountException("Graph must have at least 1 vertex");
            
            vertices = new List<Vertex>();
            for (int i = 0; i < n; i++)
                vertices.Add(new Vertex(i+1));
            
            this.isOriented = isOriented;
        }

        public Graph(StreamReader stream)
        {
            var initLine = stream.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
            InitEmptyGraph(initLine[0],initLine[1] == 1);
            
            while (!stream.EndOfStream)
            {
                var line = stream.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
                AddEdge(line[0], line[1], line[2]);
            }
        }
        
        public void InitDualGraph(StreamReader stream)
        {
            var initLine = stream.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
            InitEmptyGraph(initLine[0] + initLine[1],false);
            var currentV = 1;
            while (!stream.EndOfStream)
            {
                var currentU = initLine[0]+1;
                var line = stream.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
                foreach (var w in line)
                {
                    if(w > 0)
                        AddEdge(currentV,currentU,w);
                    currentU++;
                }

                currentV++;
            }
        }

        public void AddVertex(int number)
        {
            if (vertices.Select(v => v.Number).Contains(number))
                throw new VertexAlreadyExistsException($"Vertex {number} already exists");
            
            vertices.Add(new Vertex(number));
        }

        public void AddEdge(int startNum, int endNum, int data, bool isReversedEdge = false)
        {
            if(vertices.Single(v => v.Number == startNum).Edges.Any(e => e.EndNumber == endNum))
                throw new EdgeAlreadyExistsException($"Edge {startNum}-{endNum} already exists");

            if (data < 0)
                throw new NegativeDataException($"Data must be positive or zero");
            
            vertices
                .Single(v => v.Number == startNum)
                .AddEdge(data, vertices.Single(v => v.Number == endNum));
            if (!isOriented && !isReversedEdge)
                AddEdge(endNum, startNum, data, true);
        }

        public void DeleteVertex(int delVertex)
        {
            if (vertices.Count(v => v.Number == delVertex) == 0)
                throw new VertexDoesNotExistException($"Vertex {delVertex} does not exists");
            
            vertices.ForEach(vertex => vertex.DeleteEdge(delVertex));
            vertices.RemoveAll(v => v.Number == delVertex);
        }

        public void DeleteEdge(int startVertex, int endVertex, bool isReversedEdge = false)
        {
            if (vertices.Single(v => v.Number == startVertex).Edges.Count(e => e.EndNumber == endVertex) == 0)
                throw new EdgeDoesNotExistException($"Edge {startVertex}-{endVertex} does not exists");
            
            vertices
                .Single(v => v.Number == startVertex)
                .DeleteEdge(endVertex);
            if(!isOriented && !isReversedEdge)
                DeleteEdge(endVertex,startVertex, true);
        }

        public IEnumerable<string> GetOutputBySets()
        {
            yield return string.Join(" ",vertices.Select(v => v.Number));
            foreach (var vertex in vertices)
            foreach (var edge in vertex.Edges)
                yield return $"{vertex.Number} {edge.EndNumber} {edge.Data}";
        }
        
        public IEnumerable<string> GetOutputByMatrix()
        {
            return vertices.Select(vertex => string.Join(" ", vertex.Edges.GetWeightOrZero(vertices.Select(v => v.Number)).Select(n=>n.ToString().PadLeft(5))));
        }

        public IEnumerable<string> GetOutputByList()
        {
            return vertices.Select(vertex => vertex.Number + " " + string.Join(" ",vertex.Edges.Select(edge =>$"{edge.EndNumber}({edge.Data})")));
        }



        public IEnumerable<IEnumerable<int>> GetDualMatrix()
        {
            var parts = DualsMatching.GetParts(this).OrderBy(p=>p.Key.Number);
            
            return  parts
                .Where((p) => !p.Value)
                .Select(p => p.Key)
                .GetWeightOrZero(parts.Where(p => p.Value).Select(p => p.Key.Number));
        }
    }
}
