using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    internal class GraphNode<T>
    {
        private T id; // Stores the identifier for the node (e.g., an airport code)

        private LinkedList<T> adjList; // Stores the list of adjacent nodes (i.e., directly connected airports)

        // Constructor to initialize a new node with the given id
        public GraphNode(T id)
        {
            this.id = id;
            this.adjList = new LinkedList<T>(); // Initializes an empty list of adjacent nodes
        }

        // Property to get or set the ID of the node
        public T ID
        {
            get { return id; }
            set { id = value; }
        }

        // Method to add an edge (connection) to another node (airport)
        public void AddEdge(GraphNode<T> to)
        {
            adjList.AddLast(to.id); // Adds the target node's ID to the adjacency list
        }

        // Method to retrieve the list of adjacent nodes
        public LinkedList<T> GetAdjList()
        {
            return adjList;
        }
    }
}
