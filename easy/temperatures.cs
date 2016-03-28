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
		int N = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
		string TEMPS = Console.ReadLine(); // the N temperatures expressed as integers ranging from -273 to 5526

		if (N <= 0)
		{
			Console.WriteLine("0\n");
			return;
		}

		string[] split = TEMPS.Split(' ');

		int i = 0;
		int temp = 0;
		int cIndex = 0;
		int cDelta = 5526; // highest temperature is 5526

		while (i < N)
		{
			temp = int.Parse(split[i]);

			if (temp < 0)
				temp = -temp;

			if (temp == cDelta && int.Parse(split[i]) > 0)
			{
				cDelta = temp;
				cIndex = i;
			}
			if (temp < cDelta)
			{
				cDelta = temp;
				cIndex = i;
			}
			i++;
		}

		Console.WriteLine(split[cIndex] + "\n");
	}
}
