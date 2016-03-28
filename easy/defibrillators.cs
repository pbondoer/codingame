using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
	static double dist(double lonA, double latA, double lonB, double latB)
	{
		return (double)Math.Sqrt((double)Math.Pow((lonB - lonA)
				* (double)Math.Cos((latA + latB) / 2.0D), 2)
				+ (double)Math.Pow(latB - latA, 2)) * 6371.0D;
	}

	static string getName(string s)
	{
		return s.Split(';')[1];
	}
	static double getLon(string s)
	{
		return double.Parse(s.Split(';')[4].Replace(',', '.'));
	}
	static double getLat(string s)
	{
		return double.Parse(s.Split(';')[5].Replace(',', '.'));
	}

	static void Main(string[] args)
	{
		string LON = Console.ReadLine().Replace(',', '.');
		string LAT = Console.ReadLine().Replace(',', '.');
		double lon = double.Parse(LON);
		double lat = double.Parse(LAT);
		int N = int.Parse(Console.ReadLine());

		string closest = "";
		double minDist = double.MaxValue;
		for (int i = 0; i < N; i++)
		{
			string DEFIB = Console.ReadLine();
			double lon2 = getLon(DEFIB);
			double lat2 = getLat(DEFIB);
			if (dist(lon, lat, lon2, lat2) < minDist)
			{
				minDist = dist(lon, lat, lon2, lat2);
				closest = getName(DEFIB);
			}
		}

		Console.WriteLine(closest);
	}
}
