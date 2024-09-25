using System;
using System.Collections.Generic;

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
                DisplayMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddAirport(testGraph);
                        break;
                    case "2":
                        RemoveAirport(testGraph);
                        break;
                    case "3":
                        AddFlight(testGraph);
                        break;
                    case "4":
                        DisplayFlights(testGraph);
                        break;
                    case "5":
                        testGraph.DisplayAllAirports();
                        break;
                    case "6":
                        DisplayAirportAndFlightCount(testGraph);
                        break;
                    case "7":
                        finished = true;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }
            } while (!finished);
        }

        // Displays the menu
        static void DisplayMenu()
        {
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("1. Insert an Airport by adding its code");
            Console.WriteLine("2. Remove an Airport by adding its code");
            Console.WriteLine("3. Insert a direct flight between 2 airports given their codes");
            Console.WriteLine("4. Display Direct or Connected flights from Starting Airport");
            Console.WriteLine("5. Display all Airports");
            Console.WriteLine("6. Display the total number of Airports and Flights");
            Console.WriteLine("7. Exit");
            Console.WriteLine("\nChoose a function: ");
        }

        // Converts user input to uppercase for case-insensitivity
        static string ConvertToUpper(string input)
        {
            return input.Trim().ToUpper();
        }

        // Adds an airport with validation
        static void AddAirport(Graph<string> testGraph)
        {
            Console.WriteLine("Please insert airport code:");
            string airport = ConvertToUpper(Console.ReadLine());

            if (string.IsNullOrWhiteSpace(airport))
            {
                Console.WriteLine("Airport code cannot be empty. Please try again.");
            }
            else if (testGraph.ContainsGraph(new GraphNode<string>(airport)))
            {
                Console.WriteLine("This airport has already been added.");
            }
            else
            {
                testGraph.AddNode(airport);
                Console.WriteLine("Airport added successfully.");
            }
        }

        // Removes an airport with validation
        static void RemoveAirport(Graph<string> testGraph)
        {
            Console.WriteLine("Please insert airport code:");
            string airport = ConvertToUpper(Console.ReadLine());

            if (string.IsNullOrWhiteSpace(airport))
            {
                Console.WriteLine("Airport code cannot be empty. Please try again.");
            }
            else if (testGraph.GetNodeByID(airport) != null)
            {
                testGraph.Remove(testGraph.GetNodeByID(airport));
                Console.WriteLine("Airport removed successfully.");
            }
            else
            {
                Console.WriteLine("Airport not found.");
            }
        }

        // Adds a flight between two airports with validation
        static void AddFlight(Graph<string> testGraph)
        {
            Console.WriteLine("From - Airport:");
            string from = ConvertToUpper(Console.ReadLine());
            Console.WriteLine("To - Airport:");
            string to = ConvertToUpper(Console.ReadLine());

            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
            {
                Console.WriteLine("Airport codes cannot be empty. Please try again.");
            }
            else if (testGraph.GetNodeByID(from) == null || testGraph.GetNodeByID(to) == null)
            {
                Console.WriteLine("One or both of the airports do not exist. Please add them first.");
            }
            else if (testGraph.IsAdjacent(testGraph.GetNodeByID(from), testGraph.GetNodeByID(to)))
            {
                Console.WriteLine("These two airports have already been connected.");
            }
            else
            {
                testGraph.AddEdge(from, to);
                Console.WriteLine("Direct flight added between {0} and {1}.", from, to);
            }
        }

        // Displays flight connections (direct or connected)
        static void DisplayFlights(Graph<string> testGraph)
        {
            Console.WriteLine("1. Connected Flights");
            Console.WriteLine("2. Direct Flights");
            Console.WriteLine("\nChoose method:");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Starting Airport:");
                    string strAirport = ConvertToUpper(Console.ReadLine());
                    testGraph.DisplayConnectedFlights(strAirport);
                    break;
                case "2":
                    Console.WriteLine("Insert starting airport by its code:");
                    string stAirport = ConvertToUpper(Console.ReadLine());
                    testGraph.DisplayDirectFlights(stAirport);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        // Displays the total number of airports and flights
        static void DisplayAirportAndFlightCount(Graph<string> testGraph)
        {
            Console.WriteLine("Number of Airports: " + testGraph.NumNodesGraph());
            Console.WriteLine("Number of Flights: " + testGraph.NumEdgesGraph());
        }
    }
}
