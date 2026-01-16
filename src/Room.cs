class Room
{
	// Private fields
	private string _description;
	private Inventory _chest;
	private Dictionary<string, Room> _exits; // stores exits of this room.

	public Inventory Chest
	{
		get { return _chest; }
	}
	// Create a room described "description". Initially, it has no exits.
	// "description" is something like "in a kitchen" or "in a court yard".
	public Room(string desc)
	{
		_description = desc;
		_exits = new Dictionary<string, Room>();
		_chest = new Inventory(999999);
	}

	// Define an exit for this room.
	public void AddExit(string direction, Room neighbor)
	{
		_exits.Add(direction, neighbor);
	}

	// Return the description of the room.
	public string GetShortDescription()
	{
		return _description;
	}

	// Return a long description of this room, in the form:
	//     You are in the kitchen.
	//     Exits: north, west
	public string GetLongDescription()
	{
		string str = "You are ";
		str += _description;
		str += ".\n";
		str += GetExitString();
		return str;
	}

	// Return the room that is reached if we go from this room in direction
	// "direction". If there is no room in that direction, return null.
	public Room GetExit(string direction)
	{
		if (_exits.ContainsKey(direction))
		{
			return _exits[direction];
		}
		return null;
	}

	// Return a string describing the room's exits, for example
	// "Exits: north, west".
	private string GetExitString()
	{
		string str = "Exits: ";
		str += String.Join(", ", _exits.Keys);

		return str;
	}
}
