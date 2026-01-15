class Inventory
{
// fields
    private int maxWeight;
    private Dictionary<string, Item> items;
// constructor
    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }
// methods
    public bool Put(string itemName, Item item)
    {
        if ((maxWeight - item.Weight) >= 0)
        {
            items.Add(itemName, item);
            return true;
        }
        
        return false;
    }
    //method om een gekozen item uit je inventory te verwijderen
    public Item Get(string itemName)
    {
        items.Remove(itemName);
        return null;
    }
    //deze method telt al het gewicht van de items in je inventory op
    public int TotalWeight()
    {
        int total = 0;

        foreach (KeyValuePair<string, Item> item in items)
        {
            total += item.Value.Weight;
        }
        return total;
    }
    //method telt op hoeveel je nog kan dragen in je inventory
    public int FreeWeight()
    {
        return maxWeight - TotalWeight();
    }
    
    public void Print()
    {
        Console.WriteLine("Your bag weighs "+TotalWeight()+"kg");
        Console.WriteLine("You can store "+FreeWeight()+"kg of items");
        Console.WriteLine("You have:");
        foreach (KeyValuePair<string, Item> item in items)
        {
            Console.WriteLine(item.Key);
        }
    }
}