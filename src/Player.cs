class Player
{
    // auto property
    public Room CurrentRoom { get; set; }

    private int _health;

    private Inventory _backpack;
    // constructor
    public Player()
    {
        _backpack = new Inventory(5);
        CurrentRoom = null;
        _health = 100;
        Item pen = new Item(1, "this is a pen", "You click the pen a few times");
        Item paper = new Item(1, "this is a sheet of paper", "You fold a paper airplane");
        _backpack.Put("pen", pen);
        _backpack.Put("paper", paper);
    }
    // methods
    public void Damage(int amount)
    {
        _health -= amount;
        Console.WriteLine("You took " + amount + " damage" );
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

        if (item.Description.Contains("this is a sheet of paper"))
        {
            Item paperplane = new Item(1, "this is a paper airplane", "You threw the paper airplane");
            _backpack.Put("paperplane",paperplane);
        }

        if (item.Description.Contains("this is a pen"))
        {
            _backpack.Put(itemName, item);
        }
        return item.Usemessage;
    }
}