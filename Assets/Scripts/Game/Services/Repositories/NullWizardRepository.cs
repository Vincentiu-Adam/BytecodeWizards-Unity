
public class NullWizardRepository : IWizardRepository
{
    private NullWizard nullWizard = new NullWizard();

    public IWizard GetWizard(int id)
    {
        return nullWizard; //this is a null repository to avoid nre's just return a null wizard
    }
}
