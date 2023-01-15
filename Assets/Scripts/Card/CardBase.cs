public class CardBase
{
    private int energy  = 0;
    private int element = 0;
    private int attack  = 0;
    private int health  = 0;

    private string name = string.Empty;

    public int Energy
    {
        get { return energy; }
        set { energy = value; }
    }

    public int Element
    {
        get { return element; }
        set { element = value; }
    }

    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public virtual void OnDrew()
    {

    }

    public virtual void OnUsed()
    {

    }

    public virtual void OnDiscarded()
    {

    }

    public virtual void OnUpgraded()
    {

    }
}