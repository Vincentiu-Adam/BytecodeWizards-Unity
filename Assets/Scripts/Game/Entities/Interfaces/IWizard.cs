public interface IWizard
{
    public int ID { get; }

    public int Health { get; }
    public int MaxHealth { get; }

    public int Wisdom { get; }

    public void SetHealth(int value);

    public void SetWisdom(int value);

    public void Revive();
}
