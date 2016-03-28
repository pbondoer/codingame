using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
	static void Main(string[] args)
	{
		int L = int.Parse(Console.ReadLine());
		int H = int.Parse(Console.ReadLine());
		string T = Console.ReadLine(); //to write

		string[] rows = new string[H];
		for (int i = 0; i < H; i++)
			rows[i] = Console.ReadLine();

		for (int row = 0; row < H; row++)
		{
			int i = 0;
			while (i < T.Length)
			{
				char c = T[i];
				int index = 26; // default question mark
				if (c >= 'a' && c <= 'z')
					index = c - 'a';
				else if (c >= 'A' && c <= 'Z')
					index = c - 'A';

				Console.Write(rows[row].Substring(index * L, L));
				i++;
			}
			Console.Write("\n");
		}
	}
}
