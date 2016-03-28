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
		string MESSAGE = Console.ReadLine();
		string binary = ToBinary(Encoding.ASCII.GetBytes(MESSAGE));

		int i = 0;
		int last = -1;

		while (i < binary.Length)
		{
			int bit = (binary[i] == '1' ? 1 : 0);
			if (last != bit)
			{
				if (last != -1)
					Console.Write(" ");
				Console.Write((bit == 0 ? "00 " : "0 "));
				//start new sequence
				last = bit;
			}
			Console.Write("0");
			i++;
		}
	}

	public static String ToBinary(Byte[] data)
	{
		return string.Join("", data.Select(b => Convert.ToString(b, 2).PadLeft(7, '0')));
	}
}
