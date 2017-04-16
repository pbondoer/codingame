using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

#region "Entity classes"
class Entity
{
	public enum Type {
		SHIP = 0,
		BARREL = 1,
		CANNONBALL = 2,
		MINE = 3
	}

	public int id;
	public Type type;
	public int x;
	public int y;
	public int rum;

	public Entity()
	{
		// empty
	}

	public Entity(int id, Type type, int x, int y, int rum)
	{
		this.type = type;
		Update(id, x, y, rum);
	}

	public void Update(int id, int x, int y, int rum)
	{        
		this.id = id;
		this.x = x;
		this.y = y;
		this.rum = rum;

		Console.Error.WriteLine(ToString());
	}

	public override string ToString()
	{
		return "Entity " + id + ", " + type.ToString() + " (" + x + ", " + y + ") with " + rum + " rum";
	}

	public int getDistance(Entity e)
	{
		return getDistance(e.x, e.y);   
	}
	public int getDistance(int x, int y)
	{
		return (Math.Abs(this.x - x) + Math.Abs(this.y - y));   
	}
}

class Ship : Entity {
	public int rotation;
	public int speed;
	public int owner;
	public int mineCooldown;

	public Ship(int id, int x, int y, int rum, int rotation, int speed, int owner)
	{
		this.type = Type.SHIP;
		Update(id, x, y, rum, rotation, speed, owner);
	}

	public void Update(int id, int x, int y, int rum, int rotation, int speed, int owner)
	{
		base.Update(id, x, y, rum);

		Console.Error.WriteLine("Rotation: " + rotation + ", Speed: " + speed + ", Owner: " + owner);
		this.rotation = rotation;
		this.speed = speed;
		this.owner = owner;
		if (this.mineCooldown > 0)
			this.mineCooldown--;
	}

	public void Move(Entity e)
	{
		Move(e.x, e.y);   
	}
	public void Move(int x, int y)
	{
		Console.WriteLine("MOVE " + x + " " + y);
	}
	public void Wait()
	{
		Console.WriteLine("WAIT");   
	}
	public void Slower()
	{
		Console.WriteLine("SLOWER");   
	}
	public void Fire(Entity e)
	{
		Fire(e.x, e.y);   
	}
	public void Fire(int x, int y)
	{
		Console.WriteLine("FIRE " + x + " " + y);
	}
	public void Mine()
	{
		Console.WriteLine("MINE");
		this.mineCooldown = 4;
	}
}

class Barrel : Entity {
	public Barrel(int id, int x, int y, int rum)
	{
		this.type = Type.BARREL;
		base.Update(id, x, y, rum);
	}
}

class Cannonball : Entity {
	public int owner;
	public int impact;

	public Cannonball(int id, int x, int y, int owner, int impact)
	{
		this.type = Type.CANNONBALL;

		Update(id, x, y, owner, impact);
	}

	public void Update(int id, int x, int y, int owner, int impact)
	{
		base.Update(id, x, y, 25);

		this.owner = owner;
		this.impact = impact;
	}
}

class Mine : Entity {
	public Mine(int id, int x, int y)
	{
		this.type = Type.MINE;
		Update(id, x, y);
	}

	public void Update(int id, int x, int y)
	{
		base.Update(id, x, y, 25);   
	}
}

#endregion

class Player
{
	static void Main(string[] args)
	{
		Dictionary<int, Entity> entities = new Dictionary<int, Entity>();
		List<Ship> ships = new List<Ship>();
		List<Barrel> barrels = new List<Barrel>();
		List<Cannonball> cannonballs = new List<Cannonball>();
		List<Mine> mines = new List<Mine>();

		// game loop
		while (true)
		{
			// number of ships
			int myShipCount = int.Parse(Console.ReadLine());
			// the number of entities (e.g. ships, mines or cannonballs)
			int entityCount = int.Parse(Console.ReadLine());

			ships.Clear();
			barrels.Clear();

			for (int i = 0; i < entityCount; i++)
			{
				string line = Console.ReadLine();
				string[] inputs = line.Split(' ');
				//Console.Error.WriteLine("input: " + line);

				int entityId = int.Parse(inputs[0]);
				string entityType = inputs[1];
				int x = int.Parse(inputs[2]);
				int y = int.Parse(inputs[3]);
				int arg1 = int.Parse(inputs[4]);
				int arg2 = int.Parse(inputs[5]);
				int arg3 = int.Parse(inputs[6]);
				int arg4 = int.Parse(inputs[7]);

				Entity e = null;
				if (entities.ContainsKey(entityId))
				{               
					e = entities[entityId];
					if (entityType == "SHIP")
						((Ship)e).Update(entityId, x, y, arg3, arg1, arg2, arg4);
					else if (entityType == "BARREL")
						((Barrel)e).Update(entityId, x, y, arg1);
					else if (entityType == "CANNONBALL")
						((Cannonball)e).Update(entityId, x, y, arg1, arg2);
					else if (entityType == "MINE")
						((Mine)e).Update(entityId, x, y);
				}
				else
				{
					if (entityType == "SHIP")
						e = new Ship(entityId, x, y, arg3, arg1, arg2, arg4);
					else if (entityType == "BARREL")
						e = new Barrel(entityId, x, y, arg1);
					else if (entityType == "CANNONBALL")
						e = new Cannonball(entityId, x, y, arg1, arg2);
					else if (entityType == "MINE")
						e = new Mine(entityId, x, y);
					entities[entityId] = e;
				}

				// add to the list
				if (entityType == "SHIP")
					ships.Add((Ship)e);
				else if (entityType == "BARREL")
					barrels.Add((Barrel)e);  
				else if (entityType == "CANNONBALL")
					cannonballs.Add((Cannonball)e);
				else if (entityType == "MINE")
					mines.Add((Mine)e);
			}

			foreach (Ship ship in ships)
			{
				if (ship.owner != 1)
					continue;

				if (barrels.Count == 0)
				{
					ship.Fire(ships[1]);
					continue;
				}

				barrels.Sort((b1, b2) => ship.getDistance(b1) - ship.getDistance(b2));
				Console.Error.WriteLine("Best barrel: " + barrels[0]);

				ship.Move(barrels[0]);
			}
		}
	}
}
