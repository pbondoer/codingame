using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
	static void Main(string[] args)
	{
		int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
		int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

		int[,] nodes = new int[width, height];

		//read data
		for (int y = 0; y < height; y++)
		{
			string line = Console.ReadLine(); // width characters, each either 0 or .
			Console.Error.WriteLine(line);
			for (int x = 0; x < line.Length; x++)
			{
				if (line[x] == '.')
					nodes[x, y] = -1;
				else
					nodes[x, y] = 0;
			}
		}

		// compute data
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				// is this cell valid?
				if (nodes[x, y] != 0) continue;

				// visit the node
				nodes[x, y] = 1;

				// output node itself
				Console.Write(x + " " + y + " ");

				bool found = false;
				// left node
				for (int x2 = x + 1; x2 < width; x2++)
				{
					if (nodes[x2, y] != 0) continue;
					found = true;
					Console.Write(x2 + " " + y + " ");
					break;
				}

				if (!found)
					Console.Write("-1 -1 ");

				// bottom node
				found = false;
				for (int y2 = y + 1; y2 < height; y2++)
				{
					if (nodes[x, y2] != 0) continue;
					found = true;
					Console.Write(x + " " + y2 + "\n");
					break;
				}

				if (!found)
					Console.Write("-1 -1\n");
			}
		}
	}
}
