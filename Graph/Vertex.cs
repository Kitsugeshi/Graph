using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Vertex<T>
    {
        public T Name { get; set; }
        public int Id { get; set; }

        public Vertex(T name, int id = 0)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
