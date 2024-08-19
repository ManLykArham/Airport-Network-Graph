using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initializes the graph to store airport connections
            Graph<string> testGraph = new Graph<string>();
            bool finished = false;

            do
            {
                // Displays the menu options to the user
                Console.WriteLine("Press ENTER");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("1. Insert an Airport by adding its code");
                Console.WriteLine("2. Remove an Airport by adding its code");
                Console.WriteLine("3. Insert a direct flight between 2 airports given their codes");
                Console.WriteLine("4. Display Direct or Connected flights from Starting Airport");
                Console.WriteLine("5. Exit");
                Console.WriteLine("\n Choose a function");

                // Reads the user's choice
                string option = Console.ReadLine();

                // Switch case to handle user choice
                switch (option)
                {
                    case "1":
                        // Prompts the user to insert an airport code and checks if it already exists
                        Console.WriteLine("Please insert airport code:");
                        string airport = Console.ReadLine();
                        if (testGraph.ContainsGraph(new GraphNode<string>(airport)))
                        {
                            Console.WriteLine("This airport has already been added");
                        }
                        else
                            testGraph.AddNode(airport);  // Adds the airport if it doesn't exist
                        break;
                    case "2":
                        // Prompts the user to input an airport code to remove
                        Console.WriteLine("Please insert airport code:");
                        string removRport = Console.ReadLine();
                        testGraph.Remove(testGraph.GetNodeByID(removRport));  // Removes the airport
                        break;
                    case "3":
                        // Prompts the user to insert two airports to establish a direct flight
                        Console.WriteLine("From - Airport");
                        string from = Console.ReadLine();
                        Console.WriteLine("To - Airport");
                        string to = Console.ReadLine();
                        if (testGraph.IsAdjacent(testGraph.GetNodeByID(from), testGraph.GetNodeByID(to)))
                        {
                            Console.WriteLine("These 2 airports have already been connected");
                        }
                        else
                            testGraph.AddEdge(from, to);  // Adds the flight if it doesn't exist
                        break;
                    case "4":
                        flights();  // Calls the method to display flight connections
                        break;
                    case "5":
                        finished = true;  // Ends the program
                        Console.WriteLine("Give me First Class :)");
                        break;
                }
            } while (!finished);

            // Function to display connected or direct flights
            void flights()
            {
                Console.WriteLine("1. Connected Flights");
                Console.WriteLine("2. Direct Flights");
                Console.WriteLine("\nChoose method:");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // Displays all connected flights starting from a given airport
                        Console.WriteLine("Starting Airport: ");
                        string strAirport = Console.ReadLine();
                        testGraph.displayCodes(strAirport);
                        break;
                    case "2":
                        // Displays all direct flights from a given airport
                        Console.WriteLine("Insert starting airport by its code:");
                        string stAirport = Console.ReadLine();
                        testGraph.adjlistOfnode(testGraph.GetNodeByID(stAirport));
                        break;
                }
            }
        }
    }
}
