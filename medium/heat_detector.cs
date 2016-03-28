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
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int W = int.Parse(inputs[0]); // width of the building.
		int H = int.Parse(inputs[1]); // height of the building.
		int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
		inputs = Console.ReadLine().Split(' ');
		int X= int.Parse(inputs[0]);
		int Y = int.Parse(inputs[1]);

		int minX = 0;
		int maxX = W;
		int minY = 0;
		int maxY = H;
		int temp;

		// game loop
		while (true)
		{
			// the direction of the bombs from batman's current location
			// (U, UR, R, DR, D, DL, L or UL)
			string bombDir = Console.ReadLine();

			Console.Error.WriteLine(bombDir);
			if (bombDir.Contains("U")) //Y--
			{
				maxY = Y;
				Y = (int)Math.Floor((minY + maxY) / 2.0);
			}
			if (bombDir.Contains("D")) //Y++
			{
				minY = Y;
				Y = (int)Math.Ceiling((minY + maxY) / 2.0);
			}
			if (bombDir.Contains("L")) //X--
			{
				maxX = X;
				X = (int)Math.Floor((minX + maxX) / 2.0);
			}
			if (bombDir.Contains("R")) //X++
			{
				minX = X;
				X = (int)Math.Ceiling((minX + maxX) / 2.0);
			}

			Console.WriteLine(X + " " + Y); // the location of the next window Batman should jump to.
		}
	}
}
