class Player
{
    // auto property
    public Room CurrentRoom { get; set; }

    private int _health;

    private Inventory _backpack;
    // constructor
    public Inventory Backpack
    {
        get { return _backpack; }
    }
    public Player()
    {
        _backpack = new Inventory(25);
        CurrentRoom = null;
        _health = 100;
    }
    // methods
    public void Damage(int amount)
    {
        _health -= amount;
        Console.WriteLine("Je hebt " + amount + " damage opgelopen" );
    }

    //method om de gekozen item uit de huidige kamer chest te halen returnt of het gelukt is en om welke reden het kan falen
    public bool TakeFromChest(string itemName, out string reason)
    {
        reason = "";
        
        Item item = CurrentRoom.Chest.Get(itemName);

        if (item == null)
        {
            reason = "notfound";
            return false;
        }
        
        if (item.Weight > _backpack.FreeWeight())
        {
            CurrentRoom.Chest.Put(itemName, item);
            reason = "tooheavy";
            return false;
        }

        _backpack.Put(itemName, item);
        return true;
    }
    public bool DropToChest(string itemName, out string reason)
    {
        reason = "";
        Item item = _backpack.Get(itemName);

        if (item == null)
        {
            reason = "notfound";
            return false;
        }

        if (item.Weight > CurrentRoom.Chest.FreeWeight())
        {
            _backpack.Put(itemName, item);
            reason = "toofull";
            return false;
        }
        
        CurrentRoom.Chest.Put(itemName, item);
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

    public string ShowInventory()
    {
        return _backpack.Show();
    }

    public string Use(string itemName)
    {
        Item item = _backpack.Get(itemName);

        if (item == null)
        {
            return "You dont have that item";
        }

        if (item.Description.Contains("een croissant"))
        {
            Heal(5);
        }
        
        if (item.Description.Contains("een broodje gezond"))
        {
            Heal(10);
        }

        return item.Usemessage;
    }
}