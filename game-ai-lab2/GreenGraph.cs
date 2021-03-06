using System;
using System.Collections.Generic;

class GreenGraph : Graph {
   
   // List of nodes in this graph
   private List<Node> nodes;

   // An adjacency matrix, recording edges between nodes
   // Edges FROM node i are recorded in adjMatrix[i]
   // Edge FROM node i to node j is recorded in adjMatrix[i][j]
   // Each int entry records the edge cost (> -1)
   // If entry is 0 there is no edge 
   private List<List<int>> adjMatrix;

   public GreenGraph() {
       //Node Array list
      nodes = new List<Node>(); 
      adjMatrix = new List<List<int>>();
   }

   // ADD MISSING METHODS HERE
    
    public void AddNode(Node a) {
        //Adds node to arraylist
        nodes.Add(a);
        //Clears all values in the adjacency matrix
		adjMatrix.Clear();
        //Inputs new values inside the adjacency matrix
		for(int i = 0; i < nodes.Count; i++)
		{
			List<int> n = new List<int>();
			n.AddRange(new int[nodes.Count]);
			adjMatrix.Add(n);
		}
	}

	public void AddEdge(Node a, Node b, int c) {
		adjMatrix[a.GetHashCode()][b.GetHashCode()] = c;
	}

	public List<Node> Nodes()
	{
        //Displays the list of nodes
		return nodes;
	}

	public List<Node> Neighbours(Node a)
	{
        // it looks through the list and adds a node to it
		List<Node> neighbours = new List<Node>();
		for (int x = 0; x < nodes.Count; x++)
		{
            // if the value is greater than 0, then it is added to the neighbour list
			if (adjMatrix[a.GetHashCode()][x] > 0)
			{
				neighbours.Add(nodes[x]);
			}
		}
		return neighbours;
	}

	public int Cost(Node a, Node b)
	{
		return adjMatrix[a.GetHashCode()][b.GetHashCode()];
	}


   public void Write() {
      Console.WriteLine("GreenGraph");

      for (int i = 0; i < nodes.Count; i++) {
         Console.Write(nodes[i] + ": ");

         bool first = true;
         for (int j = 0; j < nodes.Count; j++) {
            if (adjMatrix[i][j] > 0) {
               if (!first) Console.Write(", ");
               Console.Write(nodes[j] + "(" + adjMatrix[i][j] + ")");
               first = false;
            }
         }

         Console.Write("\n");
      }
   }
}