using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private static NullWizardRepository nullWizardRepository = new NullWizardRepository();

    private static IWizardRepository wizardRepository = nullWizardRepository;

    public static void ProvideWizardRepository(WizardRepository repository)
    {
        if (repository == null)
        {
            wizardRepository = nullWizardRepository;
            return;
        }

        wizardRepository = repository;
    }

    public static IWizardRepository GetWizardRepository()
    {
        return wizardRepository;
    }
}
