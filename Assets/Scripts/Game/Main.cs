using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    private VM spellVM = new VM();

    private void Awake()
    {
        SetupLocators();

        //TO DO : load some spells here then go to town :D
        SpellRepository spellRepository = ServiceLocator.GetSpellRepository();

        byte[] fireSpellData = spellRepository.GetSpellData(SpellType.FIRE);
        PrintSpell(fireSpellData);
    }

    private void SetupLocators()
    {
        WizardRepository wizardRepository = new WizardRepository();
        ServiceLocator.ProvideWizardRepository(wizardRepository);

        SpellRepository spellRepository = new SpellRepository();
        ServiceLocator.ProvideSpellRepository(spellRepository);
    }

    private void PrintSpell(byte[] spellData)
    {
        string hexString = BitConverter.ToString(spellData).Replace("-", " ");
        Debug.Log("Spell Data \n" + hexString);
    }
}
