class Player
{
    // auto property
    public Room CurrentRoom { get; set; }

    private int health;
    // constructor
    public Player()
    {
        CurrentRoom = null;
        health = 100;
    }
    // methods
    public void Damage(int amount)
    {
        health -= amount;
        Console.WriteLine("You took " + amount + " damage" );
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
}