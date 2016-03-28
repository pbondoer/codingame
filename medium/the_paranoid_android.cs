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
		int nbFloors = int.Parse(inputs[0]); // number of floors
		int width = int.Parse(inputs[1]); // width of the area
		int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
		int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
		int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
		int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
		int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
		int nbElevators = int.Parse(inputs[7]); // number of elevators

		Dictionary<int, int> elevators = new Dictionary<int, int>();
		for (int i = 0; i < nbElevators; i++)
		{
			inputs = Console.ReadLine().Split(' ');
			int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
			int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor

			elevators.Add(elevatorFloor, elevatorPos);
		}


		bool hasStopped = false;
		// game loop
		while (true)
		{
			inputs = Console.ReadLine().Split(' ');
			int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
			int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
			string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT

			if(cloneFloor == exitFloor && ((direction == "LEFT" && clonePos > exitPos) || (direction == "RIGHT" && clonePos < exitPos)))
			{
				Console.WriteLine("WAIT");
				continue;
			}

			if (direction == "LEFT")
			{
				int minPos = width - 1;
				if (elevators.ContainsKey(cloneFloor))
				{
					minPos = elevators[cloneFloor] - 1;
				}
				if (elevators.ContainsKey(cloneFloor - 1))
				{
					if (minPos > elevators[cloneFloor - 1] - 1)
						minPos = elevators[cloneFloor - 1] - 1;
				}

				if (clonePos == minPos || clonePos == 0)
				{
					Console.WriteLine("BLOCK");
					if (!elevators.ContainsKey(cloneFloor))
						hasStopped = true;
					continue;
				}
			}
			else
			{
				int maxPos = 0;
				if (elevators.ContainsKey(cloneFloor))
				{
					maxPos = elevators[cloneFloor] + 1;
				}
				if (elevators.ContainsKey(cloneFloor - 1))
				{
					if (maxPos < elevators[cloneFloor - 1] + 1)
						maxPos = elevators[cloneFloor - 1] + 1;
				}
				if (clonePos == maxPos || clonePos == width - 1)
				{
					Console.WriteLine("BLOCK");
					if (!elevators.ContainsKey(cloneFloor))
						hasStopped = true;
					continue;
				}
			}
			// default to WAIT
			Console.WriteLine("WAIT");
		}
	}
}
