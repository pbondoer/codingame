using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
	public class Room
	{
		public int id;
		public string entry;
		public string exit;

		public Room(int id, string entry, string exit)
		{
			this.id = id;
			this.entry = entry;
			this.exit = exit;
		}
	}

	static Room[] presets = {
		new Room(0, "", ""),
		new Room(1, "TOP|LEFT|RIGHT", "BOTTOM|BOTTOM|BOTTOM"),
		new Room(2, "LEFT|RIGHT", "RIGHT|LEFT"),
		new Room(3, "TOP", "BOTTOM"),
		new Room(4, "TOP|RIGHT", "LEFT|BOTTOM"),
		new Room(5, "TOP|LEFT", "RIGHT|BOTTOM"),
		new Room(6, "LEFT|RIGHT", "RIGHT|LEFT"),
		new Room(7, "TOP|RIGHT", "BOTTOM|BOTTOM"),
		new Room(8, "LEFT|RIGHT", "BOTTOM|BOTTOM"),
		new Room(9, "TOP|LEFT", "BOTTOM|BOTTOM"),
		new Room(10, "TOP", "LEFT"),
		new Room(11, "TOP", "RIGHT"),
		new Room(12, "RIGHT", "BOTTOM"),
		new Room(13, "LEFT", "BOTTOM")
	};

	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int W = int.Parse(inputs[0]); // number of columns.
		int H = int.Parse(inputs[1]); // number of rows.

		Room[,] rooms = new Room[W, H];

		for (int y = 0; y < H; y++)
		{
			string[] split = Console.ReadLine().Split(' '); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.

			for (int x = 0; x < W; x++)
				rooms[x, y] = presets[int.Parse(split[x])];
		}
		int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

		// game loop
		while (true)
		{
			inputs = Console.ReadLine().Split(' ');
			int XI = int.Parse(inputs[0]);
			int YI = int.Parse(inputs[1]);
			string POS = inputs[2];

			Room r = rooms[XI, YI];
			if (r.entry.Contains(POS))
			{
				string[] entries;
				string[] exits;

				entries = r.entry.Split('|');
				exits = r.exit.Split('|');

				for (int i = 0; i < entries.Length; i++)
				{
					if (entries[i] == POS)
					{
						string exit = exits[i];

						Console.Error.WriteLine("Found entry at " + POS);
						Console.Error.WriteLine("Found exit at " + exit);

						if (exit == "BOTTOM")
							YI++;
						else if (exit == "LEFT")
							XI--;
						else if (exit == "RIGHT")
							XI++;
					}
				}
			}

			Console.WriteLine(XI + " " + YI);
		}
	}
}
