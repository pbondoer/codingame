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
		int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
		int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
		Dictionary<string, string> mimes = new Dictionary<string, string>();

		for (int i = 0; i < N; i++)
		{
			string[] inputs = Console.ReadLine().Split(' ');
			string EXT = inputs[0].ToLower(); // file extension
			string MT = inputs[1]; // MIME type.
			mimes.Add(EXT, MT);
		}
		for (int i = 0; i < Q; i++)
		{
			string FNAME = Console.ReadLine(); // One file name per line.
			string ext = FNAME.Substring(FNAME.LastIndexOf('.') + 1).ToLower();

			if (FNAME.Contains(".") && mimes.ContainsKey(ext))
				Console.WriteLine(mimes[ext]);
			else
				Console.WriteLine("UNKNOWN");
		}
	}
}
