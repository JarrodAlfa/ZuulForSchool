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
    public Item Get(string itemName)
    {
//  implementeer:
// Zoek Item in de Dictionary
// Verwijder Item uit Dictionary (als gevonden)
// Return Item of null
        return null;
    }
    
    public int TotalWeight()
    {
        int total = 0;

        foreach (KeyValuePair<string, Item> item in items)
        {
            total += item.Value.Weight;
        }
        return total;
    }
    public int FreeWeight()
    {
//  implementeer:
// Vergelijk MaxWeight en TotalWeight()
        return 0;
    }

    public void Print()
    {
        foreach (KeyValuePair<string, Item> item in items)
        {
            Console.WriteLine("Your bag weighs "+TotalWeight()+"kg");
            Console.WriteLine("You have:");
            Console.WriteLine(item.Key);
        }
    }
}