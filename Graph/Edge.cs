using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Edge<T>
    {
        public Vertex<T> From { get; set; }
        public Vertex<T> To { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex<T> from, Vertex<T> to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}
