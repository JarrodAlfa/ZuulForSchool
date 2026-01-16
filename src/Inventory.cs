class Inventory
{
// fields
    private int _maxWeight;
    private Dictionary<string, Item> _items;
// constructor
    public Inventory(int maxWeight)
    {
        this._maxWeight = maxWeight;
        this._items = new Dictionary<string, Item>();
    }
// methods
    public bool Put(string itemName, Item item)
    {
        if (item.Weight > FreeWeight())
        {
            return false;
        }

        _items[itemName] = item;
        return true;
    }
    //method om een gekozen item uit je inventory te verwijderen
    public Item Get(string itemName)
    {
        if (!_items.ContainsKey(itemName))
        {
            return null;
        }

        Item item = _items[itemName];
        _items.Remove(itemName);
        return item;
    }
    //deze method telt al het gewicht van de items in je inventory op
    public int TotalWeight()
    {
        int total = 0;

        foreach (KeyValuePair<string, Item> item in _items)
        {
            total += item.Value.Weight;
        }
        return total;
    }
    //method telt op hoeveel je nog kan dragen in je inventory
    public int FreeWeight()
    {
        return _maxWeight - TotalWeight();
    }
    
    public string Show()
    {
        return string.Join(", ", _items.Keys);
    }
}