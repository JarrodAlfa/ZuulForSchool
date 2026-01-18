class Game
{
	// Private fields
	private Parser _parser;
	private Player _player;

	// Constructor
	public Game()
	{
		_parser = new Parser();
		_player = new Player();
		CreateRooms();
	}

	// Initialise the Rooms (and the Items)
	private void CreateRooms()
	{
		// Create the rooms
		Room outside = new Room("outside the main entrance of the university");
		Room theatre = new Room("in a lecture theatre");
		Room pub = new Room("in the campus pub");
		Room pubfloor1 = new Room("in the campus pub on the first floor");
		Room lab = new Room("in a computing lab");
		Room office = new Room("in the computing admin office");
		Room labfloor1 = new Room("in the computing lab on the first floor");
		Room labbasement = new Room("in the computing labs basement");
		// Initialise room exits
		outside.AddExit("east", theatre);
		outside.AddExit("south", lab);
		outside.AddExit("west", pub);

		theatre.AddExit("west", outside);

		pub.AddExit("east", outside);
		pub.AddExit("up", pubfloor1);
		
		pubfloor1.AddExit("down", pub);

		lab.AddExit("north", outside);
		lab.AddExit("east", office);
		lab.AddExit("up", labfloor1);
		lab.AddExit("down", labbasement);
		
		labfloor1.AddExit("down", lab);
		labbasement.AddExit("up", lab);

		office.AddExit("west", lab);

		// Create your Items here
		Item book = new Item(1, "this is a book", "You read the book");
		Item laptop = new Item(5, "this is a laptop", "You opened the laptop, no new emails thoug");
		Item phone = new Item(1, "this is a phone", "You unlock your phone there are no new messages though");
		Item chair = new Item(10, "this is a chair", "You decide to sit down for a minute");
		// And add them to the Rooms
		labbasement.Chest.Put("book", book);
		labbasement.Chest.Put("chair", chair);
		office.Chest.Put("laptop", laptop);
		pubfloor1.Chest.Put("phone", phone);
		// Start game outside
		_player.CurrentRoom = outside;
	}

	//  Main play routine. Loops until end of play.
	public void Play()
	{
		PrintWelcome();

		// Enter the main command loop. Here we repeatedly read commands and
		// execute them until the player wants to quit.
		bool finished = false;
		while (!finished)
		{
			Command command = _parser.GetCommand();
			finished = ProcessCommand(command);
			if (!_player.IsAlive())
			{
				finished = true;
			}
		}
		Console.WriteLine("Thank you for playing.");
		Console.WriteLine("Press [Enter] to continue.");
		Console.ReadLine();
	}

	// Print out the opening message for the player.
	private void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to Zuul!");
		Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
		Console.WriteLine(_player.CurrentRoom.GetLongDescription());

	}

	// Given a command, process (that is: execute) the command.
	// If this command ends the game, it returns true.
	// Otherwise false is returned.
	private bool ProcessCommand(Command command)
	{
		bool wantToQuit = false;

		if(command.IsUnknown())
		{
			Console.WriteLine("I don't know what you mean...");
			return wantToQuit; // false
		}

		switch (command.CommandWord)
		{
			case "help":
				PrintHelp();
				break;
			case "go":
				GoRoom(command);
				break;
			case "look":
				Console.WriteLine(_player.CurrentRoom.GetLongDescription());
				Console.WriteLine("Contains: "+_player.CurrentRoom.Chest.Show());
				break;
			case "status":
				Console.WriteLine("Your health is at "+_player.GetHealth());
				break;
			case "inventory":
				Console.WriteLine("Your bag weighs "+_player.GetTotalWeight()+"kg");
				Console.WriteLine("You can store "+_player.GetFreeWeight()+"kg of items");
				Console.WriteLine("You have: "+_player.ShowInventory());
				break;
			case "take":
				Take(command);
				break;
			case "drop":
				Drop(command);
				break;
			case "use":
				Use(command);
				break;
			case "quit":
				wantToQuit = true;
				break;
		}

		return wantToQuit;
	}

	// ######################################
	// implementations of user commands:
	// ######################################
	
	// Print out some help information.
	// Here we print the mission and a list of the command words.
	private void PrintHelp()
	{
		Console.WriteLine("You are lost. You are alone.");
		Console.WriteLine("You wander around at the university.");
		Console.WriteLine();
		// let the parser print the commands
		_parser.PrintValidCommands();
	}

	private void Use(Command command)
	{
		if(!command.HasSecondWord())
		{
			Console.WriteLine("Use what?");
			return;
		}
		
		Console.WriteLine(_player.Use(command.SecondWord));
	}
	private void Take(Command command)
	{
		if(!command.HasSecondWord())
		{
			Console.WriteLine("Take what?");
			return;
		}
		
		string reason;
		bool success = _player.TakeFromChest(command.SecondWord, out reason);
		
		if (success)
		{
			Console.WriteLine("You took: "+command.SecondWord);
		}
		else if (reason == "notfound")
		{
			Console.WriteLine(command.SecondWord+" isn't here");
		}
		else if (reason == "tooheavy")
		{
			Console.WriteLine(command.SecondWord+" is too heavy");
		}
	}
	
	private void Drop(Command command)
	{
		if(!command.HasSecondWord())
		{
			Console.WriteLine("Drop what?");
			return;
		}
		
		string reason;
		bool success = _player.DropToChest(command.SecondWord, out reason);
		
		if (success)
		{
			Console.WriteLine("You dropped: "+command.SecondWord);
		}
		else if (reason == "notfound")
		{
			Console.WriteLine(command.SecondWord+" isn't here");
		}
		else if (reason == "toofull")
		{
			Console.WriteLine("this room is too full");
		}
	}
	// Try to go to one direction. If there is an exit, enter the new
	// room, otherwise print an error message.
	private void GoRoom(Command command)
	{
		if(!command.HasSecondWord())
		{
			// if there is no second word, we don't know where to go...
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;

		// Try to go to the next room.
		Room nextRoom = _player.CurrentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to "+direction+"!");
			return;
		}

		_player.CurrentRoom = nextRoom;
		Console.WriteLine(_player.CurrentRoom.GetLongDescription());
		_player.Damage(1);
	}
}
