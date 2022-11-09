using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private static NullWizardRepository nullWizardRepository = new NullWizardRepository();

    private static IWizardRepository wizardRepository = nullWizardRepository;

    private static SpellRepository spellRepository = null;

    private static VM spellVM = null;

    public static void ProvideWizardRepository(WizardRepository repository)
    {
        if (repository == null)
        {
            wizardRepository = nullWizardRepository;
            return;
        }

        wizardRepository = repository;
    }

    public static void ProvideSpellRepository(SpellRepository repository)
    {
        spellRepository = repository;
    }

    public static void ProvideSpellVM(VM vm)
    {
        spellVM = vm;
    }

    public static IWizardRepository GetWizardRepository()
    {
        return wizardRepository;
    }

    public static SpellRepository GetSpellRepository()
    {
        return spellRepository;
    }
    public static VM GetVM()
    {
        return spellVM;
    }
}
