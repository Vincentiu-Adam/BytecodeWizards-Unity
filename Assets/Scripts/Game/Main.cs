using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        SetupLocators();

        //init UI
        Utility.UpdateUIData();
    }

    private void SetupLocators()
    {
        WizardRepository wizardRepository = new WizardRepository();
        ServiceLocator.ProvideWizardRepository(wizardRepository);

        SpellRepository spellRepository = new SpellRepository();
        ServiceLocator.ProvideSpellRepository(spellRepository);

        UIRepository uiRepository = new UIRepository();
        ServiceLocator.ProvideUIRepository(uiRepository);

        VM spellVM = new VM();
        ServiceLocator.ProvideSpellVM(spellVM);
    }

    private void PrintSpell(byte[] spellData)
    {
        string hexString = BitConverter.ToString(spellData).Replace("-", " ");
        Debug.Log("Spell Data \n" + hexString);
    }
}
