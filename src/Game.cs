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
	
	//maak kamers en items aan
	private void CreateRooms()
	{
		//Begane grond rooms
		Room ingang = new  Room("bij de ingang.");
		Room gang = new   Room("in de gang, het is ongewoon stil.");
		Room trap = new  Room("bij de trap op de begane grond.");
		Room hangplek0 = new   Room("bij de hangplek op de begane grond, er is niemand te vinden.");
		Room lift = new Room("bij de lift, het lijkt buiten gebruik te zijn.");
		//1ste verdieping rooms
		Room trap1 = new Room("bij de eerste trap op de eerste verdieping.");
		Room kantinevoor = new Room("in de voorzijde van de kantine, het ruikt naar eten.");
		Room kantineachter = new Room("in de achterzijde van de kantine, het uitzicht is best mooi.");
		Room trap2 = new Room("Bij de 2de trap op de eerste verdieping");
		//2de verdieping rooms
		Room klas3_1 = new Room("in klas 3.1");
		Room klas3_2 = new Room("in klas 3.2");
		Room trap3 = new Room("bij de eerste trap op de tweede verdieping");
		Room leesplek = new Room("bij de leesplek, er liggen heel veel boeken in de kast");
		Room klas3_3 = new Room("in klas 3.3");
		Room trap4 = new Room("bij de tweede trap op de tweede verdieping");
		//3de verdieping rooms
		Room klas4_1 = new Room("in klas 4.1");
		Room klas4_2 = new Room("in klas 4.2");
		Room trap5 = new Room("bij de eerste trap op de derde verdieping");
		Room hangplek1 = new Room("bij de hangplek op de derde verdieping");
		Room klas4_3 = new Room("in klas 4.3");
		Room trap6 = new Room("bij de tweede trap op de derde verdieping");
		//4de verdieping rooms
		Room klas5_1 = new Room("in klas 5.1");
		Room klas5_2 = new Room("in klas 5.2");
		Room trap7 = new Room("bij de eerste trap op de vierde verdieping");
		Room werkplek = new Room("bij de werkplek");
		Room klas5_3 = new Room("in klas 5.3");
		Room trap8 = new Room("bij de tweede trap op de vierde verdieping");
		//5de verdieping rooms
		Room klas6_1 = new Room("in klas 6.1");
		Room klas6_2 = new Room("in klas 6.2");
		Room trap9 = new Room("bij de eerste trap op de vijfde verdieping");
		Room lunchtafel = new Room("bij de lunchtafel");
		Room klas6_3 = new Room("in klas 6.3");
		Room trap10 = new Room("bij de tweede trap op de vijfde verdieping");
		
		//Room uitgangen
		//begane grond
		ingang.AddExit("gang", gang);
		
		gang.AddExit("ingang", ingang);
		gang.AddExit("trap", trap);
		gang.AddExit("hangplek0", hangplek0);
		
		hangplek0.AddExit("gang", gang);
		hangplek0.AddExit("lift", lift);
		
		lift.AddExit("hangplek0", hangplek0);
		
		trap.AddExit("gang", gang);
		trap.AddExit("boven", trap1);
		
		//eerste verdieping
		trap1.AddExit("beneden", trap);
		trap1.AddExit("kantinevoor", kantinevoor);
		trap1.AddExit("boven", trap3);
		
		kantinevoor.AddExit("trap", trap1);
		kantinevoor.AddExit("kantineachter", kantineachter);
		
		kantineachter.AddExit("trap", trap2);
		kantineachter.AddExit("kantinevoor", kantinevoor);
		
		trap2.AddExit("kantineachter", kantineachter);
		trap2.AddExit("boven", trap4);
		
		//derde verdieping
		trap3.AddExit("beneden", trap1);
		trap3.AddExit("klas3_2", klas3_2);
		trap3.AddExit("leesplek", leesplek);
		trap3.AddExit("boven", trap5);
		
		klas3_2.AddExit("trap", trap3);
		klas3_2.AddExit("klas3_1", klas3_1);
		
		klas3_1.AddExit("klas3_2", klas3_2);
		
		leesplek.AddExit("trap", trap3);
		leesplek.AddExit("klas3_3", klas3_3);
		
		klas3_3.AddExit("leesplek", leesplek);
		klas3_3.AddExit("trap", trap4);
		
		trap4.AddExit("klas3_3", klas3_3);
		trap4.AddExit("boven", trap6);
		trap4.AddExit("beneden", trap2);
		
		//vierde verdieping
		trap6.AddExit("beneden", trap4);
		trap6.AddExit("klas4_3", klas4_3);
		trap6.AddExit("boven", trap8);
		
		klas4_3.AddExit("trap", trap6);
		klas4_3.AddExit("hangplek1", hangplek1);
		
		hangplek1.AddExit("trap", trap5);
		hangplek1.AddExit("klas4_3", klas4_3);
		
		trap5.AddExit("hangplek1", hangplek1);
		trap5.AddExit("klas4_2", klas4_2);
		trap5.AddExit("boven", trap7);
		
		klas4_2.AddExit("trap", trap5);
		klas4_2.AddExit("klas4_1", klas4_1);
		
		klas4_1.AddExit("klas4_2", klas4_2);
		
		//vijfde verdieping
		trap8.AddExit("beneden", trap6);
		trap8.AddExit("klas5_3", klas5_3);
		trap8.AddExit("boven", trap10);
		
		klas5_3.AddExit("trap", trap8);
		klas5_3.AddExit("werkplek", werkplek);
		
		werkplek.AddExit("trap", trap7);
		werkplek.AddExit("klas5_3", klas5_3);
		
		trap7.AddExit("werkplek", werkplek);
		trap7.AddExit("klas5_2", klas5_2);
		trap7.AddExit("boven", trap9);
		
		klas5_2.AddExit("trap", trap7);
		klas5_2.AddExit("klas5_1", klas5_1);
		
		klas4_1.AddExit("klas5_2", klas5_2);
		
		//vijfde verdieping
		trap10.AddExit("beneden", trap8);
		trap10.AddExit("klas6_3", klas6_3);
		
		klas6_3.AddExit("trap", trap10);
		klas6_3.AddExit("lunchtafel", lunchtafel);
		
		lunchtafel.AddExit("trap", trap9);
		lunchtafel.AddExit("klas6_3", klas6_3);
		
		trap9.AddExit("lunchplek", lunchtafel);
		trap9.AddExit("klas6_2", klas6_2);
		
		klas6_2.AddExit("trap", trap9);
		klas6_2.AddExit("klas6_1", klas6_1);
		
		klas6_1.AddExit("klas6_2", klas6_2);

		// Create your Items here
		Item book = new Item(1, "this is a book", "You read the book");
		Item laptop = new Item(5, "this is a laptop", "You opened the laptop, no new emails thoug");
		Item phone = new Item(1, "this is a phone", "You unlock your phone there are no new messages though");
		Item chair = new Item(10, "this is a chair", "You decide to sit down for a minute");
		
		Item croissant = new Item(1,"een croissant", "je eet de croissant en herrenigd 5 health");
		Item broodjegezond = new Item(2, "een broodje gezond", "je eet het broodje en herrenigd 10 health");
		
		//voeg items toe aan player backpack
		_player.Backpack.Put("croissant", croissant);
		_player.Backpack.Put("broodjegezond", broodjegezond);
		// And add them to the Rooms
		// labbasement.Chest.Put("book", book);
		// labbasement.Chest.Put("chair", chair);
		// office.Chest.Put("laptop", laptop);
		// pubfloor1.Chest.Put("phone", phone);
		// Start game outside
		_player.CurrentRoom = ingang;
	}
	
	//Gameplay loop
	public void Play()
	{
		PrintWelcome();

		//Gameloop leest commands tot dat de player het spel quit
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
	
	//print de welkom message
	private void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to Zuul!");
		Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
		Console.WriteLine(_player.CurrentRoom.GetLongDescription());

	}

	// voert de commands uit
	// als het command quit is returnt true eindigt het spel 
	// ander returnt false
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
			case "loop":
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
	
	//print alle commands die je kan gebruiken
	private void PrintHelp()
	{
		Console.WriteLine("You are lost. You are alone.");
		Console.WriteLine("You wander around at the university.");
		Console.WriteLine();
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
	
	//voert het lopen tussen kamers uit als het faalt print een message
	private void GoRoom(Command command)
	{
		if(!command.HasSecondWord())
		{
			Console.WriteLine("loop waar?");
			return;
		}

		string direction = command.SecondWord;

		Room nextRoom = _player.CurrentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("Er is geen "+direction+"!");
			return;
		}

		_player.CurrentRoom = nextRoom;
		Console.WriteLine(_player.CurrentRoom.GetLongDescription());
		_player.Damage(1);
	}
}
