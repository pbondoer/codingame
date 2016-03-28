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
		int R = int.Parse(Console.ReadLine());
		int L = int.Parse(Console.ReadLine());

		string cur;
		string line = R.ToString();
		string newline = "";
		int count = 0;

		while (L > 1)
		{
			string[] split = line.Split(' ');
			int i = 0;
			while (i < split.Length)
			{
				cur = split[i];
				count = 0;
				while (i < split.Length && split[i] == cur)
				{
					count++;
					i++;
				}
				newline += " " + count.ToString() + " " + cur;
			}
			line = newline.Remove(0, 1);
			newline = "";

			L--;
		}

		Console.WriteLine(line);
	}
}
