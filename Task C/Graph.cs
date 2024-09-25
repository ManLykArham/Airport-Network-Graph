using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    internal class Graph<T> where T : IComparable
    {
        private LinkedList<GraphNode<T>> nodes;  // Holds all the nodes (airports) in the graph
        private int edgesCounter;  // Counter to keep track of the number of edges (flights)

        // Constructor to initialize the graph
        public Graph()
        {
            nodes = new LinkedList<GraphNode<T>>();
        }

        // Checks if the graph is empty
        public bool IsEmptyGraph()
        {
            return nodes.Count == 0;
        }

        // Adds a new node (airport) to the graph
        public void AddNode(T id)
        {
            nodes.AddLast(new GraphNode<T>(id));
        }

        // Removes a node (airport) and all its associated edges (flights) from the graph
        public void Remove(GraphNode<T> id)
        {
            nodes.Remove(id);
            foreach (GraphNode<T> item in nodes)
            {
                item.GetAdjList().Remove(id.ID);
            }
        }

        // Displays all airports that are connected directly or indirectly from the starting airport
        public void displayCodes(T startNode)
        {
            if (GetNodeByID(startNode) == null)
            {
                Console.WriteLine("Starting airport not found.");
                return;
            }

            Queue<T> toVisit = new Queue<T>();
            List<T> visited = new List<T>();
            GraphNode<T> current;

            toVisit.Enqueue(startNode);
            visited.Add(startNode);

            while (toVisit.Count != 0)
            {
                current = this.GetNodeByID(toVisit.Dequeue());

                Console.WriteLine("Currently at: " + current.ID);

                foreach (T neighbor in current.GetAdjList())
                {
                    if (!visited.Contains(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

            Console.WriteLine("\nConnected Flights from " + startNode + ":");
            for (int i = 1; i < visited.Count; i++)  // Skip the starting airport
            {
                Console.WriteLine(visited[i].ToString());
            }
        }

        // Displays all of the airports
        public void DisplayAllAirports()
        {
            if (nodes.Count == 0)
            {
                Console.WriteLine("No airports available.");
                return;
            }

            Console.WriteLine("All Airports in the network:");
            foreach (GraphNode<T> n in nodes)
            {
                Console.WriteLine(n.ID.ToString());
            }
        }

        // Checks if a particular node (airport) exists in the graph
        public bool ContainsGraph(GraphNode<T> node)
        {
            foreach (GraphNode<T> curr in nodes)
                if (curr.ID.CompareTo(node.ID) == 0)
                {
                    return true;
                }
            return false;
        }

        // Retrieves a node (airport) from the graph using its ID
        public GraphNode<T> GetNodeByID(T id)
        {
            foreach (GraphNode<T> curr in nodes)
                if (id.CompareTo(curr.ID) == 0)
                {
                    return curr;
                }
            return null;
        }

        // Adds an edge (flight) between two airports in the graph
        public void AddEdge(T from, T to)
        {
            GraphNode<T> n1 = GetNodeByID(from);
            GraphNode<T> n2 = GetNodeByID(to);
            edgesCounter++;
            if (n1 != null && n2 != null)
            {
                n1.AddEdge(n2);
            }
            else
            {
                Console.WriteLine("Node(s) not found within Graph, edge has not been added");
            }
        }

        // Checks if there is a direct connection (flight) between two airports
        public bool IsAdjacent(GraphNode<T> from, GraphNode<T> to)
        {
            foreach (GraphNode<T> curr in nodes)
            {
                if (curr.ID.CompareTo(from.ID) == 0)
                {
                    if (from.GetAdjList().Contains(to.ID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Displays the adjacency list (connected airports) of each airport in the graph
        public void adjofnode()
        {
            foreach (GraphNode<T> n in nodes)
            {
                Console.WriteLine("Node: {0}", n.ID);
                Console.Write("Adj:");
                foreach (T m in n.GetAdjList())
                {
                    Console.Write(m.ToString() + ",");
                }
                Console.WriteLine("\n");
            }
        }

        // Displays the direct connections of a specific airport
        public void adjlistOfnode(GraphNode<T> node)
        {
            if (node == null)
            {
                Console.WriteLine("Airport not found.");
                return;
            }

            Console.WriteLine("\nAirport: {0}", node.ID);
            Console.WriteLine("Airports available using Direct Flights: ");

            foreach (T n in node.GetAdjList())
            {
                Console.WriteLine(n.ToString());
            }
        }


        // Returns the number of nodes (airports) in the graph
        public int NumNodesGraph()
        {
            return nodes.Count;
        }

        // Returns the number of edges (flights) in the graph
        public int NumEdgesGraph()
        {
            return edgesCounter;
        }

        // Returns the airports that have exactly 'k' outgoing flights
        public List<T> Outgoing(int k)
        {
            List<T> list = new List<T>();
            int counter = 0;
            foreach (GraphNode<T> n in nodes)
            {
                int count = 0;
                foreach (T m in n.GetAdjList())
                {
                    count++;
                }
                if (count == k)
                {
                    list.Add(n.ID);
                    Console.WriteLine(list[counter]);
                    counter++;
                }
            }
            return list;
        }

        // Returns the airports that have exactly 'j' incoming flights
        public List<T> Ingoing(int j)
        {
            List<T> list = new List<T>();
            int counter = 0;
            foreach (GraphNode<T> n in nodes)
            {
                int count = 0;
                foreach (T m in n.GetAdjList())
                {
                    count++;
                }
                if (count == j)
                {
                    list.Add(n.ID);
                    Console.WriteLine(list[counter]);
                    counter++;
                }
            }
            return list;
        }

        public void DisplayConnectedFlights(T startNode)
        {
            if (GetNodeByID(startNode) == null)
            {
                Console.WriteLine("Starting airport not found.");
                return;
            }

            Queue<T> toVisit = new Queue<T>();
            HashSet<T> visited = new HashSet<T>();  // HashSet to avoid duplicates
            GraphNode<T> current;

            toVisit.Enqueue(startNode);
            visited.Add(startNode);

            Console.WriteLine($"Connected Flights from {startNode}:");

            while (toVisit.Count != 0)
            {
                current = this.GetNodeByID(toVisit.Dequeue());

                foreach (T neighbor in current.GetAdjList())
                {
                    if (!visited.Contains(neighbor))
                    {
                        Console.WriteLine(neighbor);  // Display connected airport
                        toVisit.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }

        public void DisplayDirectFlights(T startNode)
        {
            GraphNode<T> node = GetNodeByID(startNode);
            if (node == null)
            {
                Console.WriteLine("Airport not found.");
                return;
            }

            Console.WriteLine($"\nAirport: {node.ID}");
            Console.WriteLine("Airports available using Direct Flights: ");

            foreach (T neighbor in node.GetAdjList())
            {
                Console.WriteLine(neighbor);  // Display directly connected airports
            }
        }

    }
}
