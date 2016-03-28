using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
	public class Node
	{
		public int id;
		public int dist;
		public Node previous;

		public Node(int id)
		{
			this.id = id;
			dist = int.MaxValue;
			previous = null;
		}
	}
	public class Link
	{
		public Node n1;
		public Node n2;

		public Link(Node n1, Node  n2)
		{
			this.n1 = n1;
			this.n2 = n2;
		}
	}

	static List<Node> nodes = new List<Node>();
	static List<Link> links = new List<Link>();
	static List<Node> gateways = new List<Node>();

	//gets the link to cut using dijkstra
	static Link getBestLink(Node agent)
	{
		Console.Error.WriteLine("Link count: " + links.Count);

		Node bestNode = null;
		int bestDist = int.MaxValue;
		int curDist = 0;
		Link bestLink = null;

		foreach(Node gate in gateways)
		{
			//init
			foreach(Node init in nodes)
			{
				init.dist = int.MaxValue;
				init.previous = null;
			}

			//starting node is agent
			agent.dist = 0;
			List<Node> notSeen = new List<Node>(nodes);

			while(notSeen.Count > 0)
			{
				Node curNode = notSeen[0];
				foreach(Node n in notSeen)
				{
					if (n.dist < curNode.dist) curNode = n;
				}
				notSeen.Remove(curNode);

				foreach(Link link in links)
				{
					if(link.n1 != curNode && link.n2 != curNode) continue;

					Node nextNode = (curNode == link.n1 ? link.n2 : link.n1);
					if (nextNode.dist > curNode.dist + 1)
					{
						nextNode.dist = curNode.dist + 1;
						nextNode.previous = curNode;
					}
				}
			}

			//We have the best possible path
			Node iterNode = gate;
			bestNode = iterNode;
			curDist = 0;

			while (iterNode != agent && iterNode != null)
			{
				curDist++;
				bestNode = iterNode;
				iterNode = iterNode.previous;
				if (iterNode == gate)
				{
					iterNode = null;
					break;
				}

			}

			if (iterNode == null)
			{
				Console.Error.WriteLine("Gateway " + gate.id + " unreachable");
				continue;
			}
			Console.Error.WriteLine("Gateway " + gate.id + " -> curDist: " + curDist);

			if (curDist < bestDist)
			{
				foreach(Link link in links)
				{
					if ((link.n1 == bestNode && link.n2 == agent) || (link.n1 == agent && link.n2 == bestNode))
					{
						bestLink = link;
						break;
					}
				}
				bestDist = curDist;
			}
		}
		return bestLink;
	}

	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
		int L = int.Parse(inputs[1]); // the number of links
		int E = int.Parse(inputs[2]); // the number of exit gateways

		//nodes
		for (int i = 0; i < N; i++)
		{
			nodes.Add(new Node(i));
		}
		//links
		for (int i = 0; i < L; i++)
		{
			inputs = Console.ReadLine().Split(' ');
			int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
			int N2 = int.Parse(inputs[1]);

			links.Add(new Link(nodes[N1], nodes[N2]));
		}
		//gateways
		for (int i = 0; i < E; i++)
		{
			int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
			gateways.Add(nodes[EI]);
		}

		// game loop
		while (true)
		{
			int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
			Node agentNode = nodes[SI];
			Link bestLink = getBestLink(agentNode);

			Console.WriteLine(bestLink.n1.id + " " + bestLink.n2.id);
			links.Remove(bestLink);
		}
	}
}
