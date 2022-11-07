using UnityEngine;

public class Main : MonoBehaviour
{
    private VM spellVM = new VM();

    private void Awake()
    {
        //setup locators
        WizardRepository wizardRepository = new WizardRepository();
        ServiceLocator.ProvideWizardRepository(wizardRepository);

        //TO DO : load some spells here then go to town :D
    }
}
