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
    }

    public void isAlive()
    {
        if (health <= 0)
        {
            //dood
        }
        else if (health >= 0)
        {
            //levend
        }
    }
    
    public void StatusCheck()
    {
        Console.WriteLine("Your health is at "+health);
    }
}