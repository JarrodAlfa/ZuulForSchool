class Item
{
    // fields
    public int Weight { get; }
    public string Description { get; }
    public string Usemessage { get; }
// constructor
    public Item(int weight, string description, string usemessage)
    {
        Weight = weight;
        Description = description;
        Usemessage = usemessage;
    }
}