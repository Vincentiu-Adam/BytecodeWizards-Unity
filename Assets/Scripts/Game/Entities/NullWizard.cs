
//null object pattern for IWizard
public class NullWizard : IWizard
{
    public int ID => -1;

    public void SetHealth(int value)
    {
    }

    public void SetWisdom(int value)
    {
    }
}
