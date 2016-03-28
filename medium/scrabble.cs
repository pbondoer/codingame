using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
	static int count(string s, char c)
	{
		int count = 0;

		for (int i = 0; i < s.Length; i++)
			if (s[i] == c)
				count++;
		return (count);
	}
	static bool valid(string s, string v)
	{
		for (int i = 0; i < s.Length; i++)
		{
			if (!v.Contains(s[i]))
				return (false);
			if (count(s, s[i]) > count(v, s[i]))
				return (false);
		} 
		return (true);
	}
	static int score(string s)
	{
		int score = 0;

		for (int i = 0; i < s.Length; i++)
			score += charScore(s[i]);
		return (score);
	}
	static int charScore(char c)
	{
		if (c == 'q' || c == 'z')
			return (10);
		if (c == 'j' || c == 'x')
			return (8);
		if (c == 'k')
			return (5);
		if (c == 'f' || c == 'h' || c == 'v' || c == 'w' || c == 'y')
			return (4);
		if (c == 'b' || c == 'c' || c == 'm' || c == 'p')
			return (3);
		if (c == 'd' || c == 'g')
			return (2);
		return (1);
	}
	static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		Dictionary<string, int[]> dict = new Dictionary<string, int[]>();

		for (int i = 0; i < N; i++)
		{
			string W = Console.ReadLine();
			if (W.Length <= 7)
			{
				int[] n = new int[2];

				n[0] = score(W);
				n[1] = i;

				dict.Add(W, n);
			}
		}
		string LETTERS = Console.ReadLine();

		Console.Error.WriteLine("Have " + dict.Count + " / " + N + " words");
		Console.Error.WriteLine("Letters: " + LETTERS);

		foreach (KeyValuePair<string,int[]> item in dict.OrderByDescending(key => key.Value[0])
														.ThenBy(key => key.Value[1]))
		{
			Console.Error.WriteLine(item.Key + " -> " + item.Value[0] + " (" + item.Value[1] + ")");
			if (valid(item.Key, LETTERS))
			{
				Console.WriteLine(item.Key);
				break;
			}
		}
	}
}
