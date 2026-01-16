class Player
{
    // auto property
    public Room CurrentRoom { get; set; }

    private int health;

    private Inventory backpack;

    public Inventory Backpack
    {
        get { return backpack; }
    }
    // constructor
    public Player()
    {
        backpack = new Inventory(25);
        CurrentRoom = null;
        health = 100;
    }
    // methods
    public void Damage(int amount)
    {
        health -= amount;
        Console.WriteLine("You took " + amount + " damage" );
    }

    public bool TakeFromChest(string itemName)
    {
// TODO implementeer:
// Haal het Item uit de Room
// Zet het in je backpack
// Bekijk de return values
// Past het Item niet? Zet het terug in de chest
// Laat de speler weten wat er gebeurt
// Return true/false voor succes/mislukt
        return false;
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > 100)
        {
            health = 100;
        }
    }

    public bool isAlive()
    {
        if (health <= 0)
        {
            return false;
        }

        return true;
    }
    
    public void StatusCheck()
    {
        Console.WriteLine("Your health is at "+health);
    }
    
    public void Print()
    {
        Console.WriteLine("Your bag weighs "+backpack.TotalWeight()+"kg");
        Console.WriteLine("You can store "+backpack.FreeWeight()+"kg of items");
        Console.WriteLine("You have:");
        backpack.List();
    }
}