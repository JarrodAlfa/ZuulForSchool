class Player
{
    // auto property
    public Room CurrentRoom { get; set; }

    private int _health;

    private Inventory _backpack;
    // constructor
    public Player()
    {
        _backpack = new Inventory(25);
        CurrentRoom = null;
        _health = 100;
        Item pen = new Item(1, "this is a pen");
        Item paper = new Item(1, "this is a sheet of paper");
        _backpack.Put("pen", pen);
        _backpack.Put("paper", paper);
    }
    // methods
    public void Damage(int amount)
    {
        _health -= amount;
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
        Item item = CurrentRoom.Chest.Get(itemName);

        CurrentRoom.Chest.Get(itemName);
        _backpack.Put(itemName, item);
        return true;
    }

    public void Heal(int amount)
    {
        _health += amount;
        if (_health > 100)
        {
            _health = 100;
        }
    }

    public bool IsAlive()
    {
        if (_health <= 0)
        {
            return false;
        }

        return true;
    }
    
    public int GetHealth()
    {
        return _health;
    }

    public int GetTotalWeight()
    {
        return _backpack.TotalWeight();
    }

    public int GetFreeWeight()
    {
        return _backpack.FreeWeight();
    }

    public string AllItems()
    {
        return _backpack.Show();
    }
}