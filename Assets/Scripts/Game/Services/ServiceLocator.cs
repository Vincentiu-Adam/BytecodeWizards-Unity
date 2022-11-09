using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private static NullWizardRepository nullWizardRepository = new NullWizardRepository();

    private static IWizardRepository wizardRepository = nullWizardRepository;

    private static WizardPresentationRepository wizardPresentationRepository = null;

    private static SpellRepository spellRepository = null;

    private static UIRepository uiRepository = null;

    private static VM spellVM = null;

    public static void ProvideWizardRepository(WizardRepository repository)
    {
        //just for pattern testing; will not do this for all repos
        if (repository == null)
        {
            wizardRepository = nullWizardRepository;
            return;
        }

        wizardRepository = repository;
    }

    public static void ProvideWizardPresentationRepository(WizardPresentationRepository repository)
    {
        wizardPresentationRepository = repository;
    }

    public static void ProvideSpellRepository(SpellRepository repository)
    {
        spellRepository = repository;
    }

    public static void ProvideUIRepository(UIRepository repository)
    {
        uiRepository = repository;
    }

    public static void ProvideSpellVM(VM vm)
    {
        spellVM = vm;
    }

    public static IWizardRepository GetWizardRepository()
    {
        return wizardRepository;
    }

    public static WizardPresentationRepository GetWizardPresentationRepository()
    {
        return wizardPresentationRepository;
    }

    public static SpellRepository GetSpellRepository()
    {
        return spellRepository;
    }

    public static UIRepository GetUIRepository()
    {
        return uiRepository;
    }

    public static VM GetVM()
    {
        return spellVM;
    }
}
