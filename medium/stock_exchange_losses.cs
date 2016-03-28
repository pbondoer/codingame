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
		int n = int.Parse(Console.ReadLine());
		string[] inputs = Console.ReadLine().Split(' ');        

		int loss = 0;
		int max = 0;
		int value = 0;

		for (int i = 0; i < n; i++)
		{
			value = int.Parse(inputs[i]);
			if (value > max)
				max = value;
			else if(value - max < loss)
				loss = value - max;
		}
		Console.WriteLine(loss);
	}
}
