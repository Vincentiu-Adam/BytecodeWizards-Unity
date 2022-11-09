using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        SetupLocators();

        //load some spells here then go to town :D
        SpellRepository spellRepository = ServiceLocator.GetSpellRepository();

        //cast fire spell
        byte[] fireSpellData = spellRepository.GetSpellData(SpellType.FIRE);

        VM spellVM = ServiceLocator.GetVM();
        spellVM.Interpret(fireSpellData);

        //init UI
        UIRepository uiRepository = ServiceLocator.GetUIRepository();
        for (int i = 0; i < WizardRepository.MAX_WIZARDS; i++)
        {
            WizardUI wizardUI = uiRepository.GetWizardUI(i);
            wizardUI.UpdateData();
        }
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
