class Command
{
	public string CommandWord { get; init; }
	public string SecondWord { get; init; }
	public string Thirdword { get; init; }
	
	// Create a command object. First and second word must be supplied, but
	// either one (or both) can be null. See Parser.GetCommand()
	public Command(string first, string second, string third)
	{
		CommandWord = first;
		SecondWord = second;
		Thirdword = third;
	}

	
	// Return true if this command was not understood.
	public bool IsUnknown()
	{
		return CommandWord == null;
	}

	
	// Return true if the command has a second word.
	public bool HasSecondWord()
	{
		return SecondWord != null;
	}

	public bool HaseThirdWord()
	{
		return Thirdword != null;
	}
}
