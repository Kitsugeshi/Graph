using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph<T>
    {
        List<Vertex<T>> Vertexes = new List<Vertex<T>>();
        List<Edge<T>> Edges = new List<Edge<T>>();

        public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;

        public void AddVertex(Vertex<T> vertex)
        {
            Vertexes.Add(vertex);
        }

        public void AddEdge(Vertex<T> from, Vertex<T> to, int weight = 1)
        {
            var edge = new Edge<T>(from, to, weight);
            Edges.Add(edge);
        }

        public void Kruskal()
        {
            Edges.Sort((e1, e2) => e1.Weight.CompareTo(e2.Weight));

            List<Edge<T>> mst = new List<Edge<T>>();

            Dictionary<Vertex<T>, int> component = new Dictionary<Vertex<T>, int>();
            foreach (var vertex in Vertexes)
            {
                component[vertex] = vertex.Id;
            }

            foreach (var edge in Edges)
            {
                var fromComponent = component[edge.From];
                var toComponent = component[edge.To];

                if (fromComponent != toComponent)
                {
                    mst.Add(edge);

                    foreach (var vertex in Vertexes)
                    {
                        if (component[vertex] == toComponent)
                            component[vertex] = fromComponent;
                    }
                }
            }

            foreach (var item in mst)
            {
                Console.WriteLine(item);
            }
        }

        public void AdjacencyMatrix()
        {
            int n = VertexCount;
            bool[,] adjacencyMatrix = new bool[n, n];

            foreach (var edge in Edges)
            {
                adjacencyMatrix[edge.From.Id, edge.To.Id] = true;
            }

            Console.WriteLine("Adjacency Matrix:");
            Console.Write("  ");
            for (int j = 0; j < n; j++)
            {
                Console.Write(Vertexes[j].Name + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(Vertexes[i].Name + " ");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(adjacencyMatrix[i, j] ? "1 " : "0 ");
                }
                Console.WriteLine();
            }
        }


        public bool[,] TransitiveClosure()
        {
            int n = VertexCount;
            bool[,] closure = new bool[n, n];

            foreach (var edge in Edges)
            {
                closure[edge.From.Id, edge.To.Id] = true;
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        closure[i, j] = closure[i, j] || (closure[i, k] && closure[k, j]);
                    }
                }
            }

            return closure;
        }

        public void PrintTransitiveClosure(bool[,] closure)
        {
            int n = closure.GetLength(0);
            

            Console.WriteLine("Transitive Closure:");
            Console.Write("  ");
            for (int j = 0; j < n; j++)
            {
                Console.Write(Vertexes[j].Name + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(Vertexes[i].Name + " ");
                for (int j = 0; j < n; j++)
                {
                    Console.Write((closure[i, j] ? 1 : 0) + " ");
                }
                Console.WriteLine();
            }
        }

        public List<Vertex<T>> TopologicalSort()
        {
            List<Vertex<T>> sortedList = new List<Vertex<T>>();
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();

            foreach (var vertex in Vertexes)
            {
                if (!visited.Contains(vertex))
                {
                    TopologicalSortUtil(vertex, visited, stack);
                }
            }

            while (stack.Count > 0)
            {
                sortedList.Add(stack.Pop());
            }

            return sortedList;
        }

        private void TopologicalSortUtil(Vertex<T> vertex, HashSet<Vertex<T>> visited, Stack<Vertex<T>> stack)
        {
            visited.Add(vertex);

            foreach (var edge in GetAdjacentEdges(vertex))
            {
                var neighbor = edge.To;

                if (!visited.Contains(neighbor))
                {
                    TopologicalSortUtil(neighbor, visited, stack);
                }
            }

            stack.Push(vertex);
        }

        public List<Edge<T>> GetAdjacentEdges(Vertex<T> vertex)
        {
            List<Edge<T>> adjacentEdges = new List<Edge<T>>();

            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    adjacentEdges.Add(edge);
                }
            }

            return adjacentEdges;
        }

    }
}
