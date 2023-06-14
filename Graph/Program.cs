using System;

namespace Graph
{
    class Program
    {
        static void Main()
        {
            var graph = new Graph<int>();

            var v1 = new Vertex<int>(1);
            var v2 = new Vertex<int>(2, 1);
            var v3 = new Vertex<int>(3, 2);
            var v4 = new Vertex<int>(4, 3);
            var v5 = new Vertex<int>(5, 4);
            var v6 = new Vertex<int>(6, 5);
            var v7 = new Vertex<int>(7, 6);
            var v8 = new Vertex<int>(8, 7);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddVertex(v8);

            graph.AddEdge(v2, v1, 1);
            graph.AddEdge(v2, v4, 3);
            graph.AddEdge(v2, v8, 8);
            graph.AddEdge(v6, v2, 4);
            graph.AddEdge(v6, v1, 2);
            graph.AddEdge(v6, v4, 7);
            graph.AddEdge(v1, v7, 9);
            graph.AddEdge(v7, v8, 10);
            graph.AddEdge(v4, v3, 5);
            graph.AddEdge(v4, v5, 6);

            graph.AdjacencyMatrix();
            Console.WriteLine();

            graph.PrintTransitiveClosure(graph.TransitiveClosure());
            Console.WriteLine();

            Console.WriteLine("Kruskal Algorithm:");
            graph.Kruskal();
            Console.WriteLine();

            List<Vertex<int>> sortedList = graph.TopologicalSort();

            Console.WriteLine("Topologically sorted vertices:");
            foreach (var vertex in sortedList)
            {
                Console.Write(vertex.Name);
            }
            Console.WriteLine();
        }
    }
}