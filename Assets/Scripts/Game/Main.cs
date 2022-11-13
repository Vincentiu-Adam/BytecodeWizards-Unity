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

    private void Update()
    {
        //update spell repository
        SpellRepository spellRepository = ServiceLocator.GetSpellRepository();
        spellRepository.Update();

        //check if one of the wizards is dead, trigger animation and reset stats
        TriggerDieAnimation();
    }

    private void SetupLocators()
    {
        WizardRepository wizardRepository = new WizardRepository();
        ServiceLocator.ProvideWizardRepository(wizardRepository);

        WizardPresentationRepository wizardPresentationRepository = new WizardPresentationRepository();
        ServiceLocator.ProvideWizardPresentationRepository(wizardPresentationRepository);

        SpellRepository spellRepository = new SpellRepository();
        ServiceLocator.ProvideSpellRepository(spellRepository);

        UIRepository uiRepository = new UIRepository();
        ServiceLocator.ProvideUIRepository(uiRepository);

        VM spellVM = new VM();
        ServiceLocator.ProvideSpellVM(spellVM);
    }

    private void TriggerDieAnimation()
    {
        IWizardRepository wizardRepository = ServiceLocator.GetWizardRepository();

        for (int i = 0; i < WizardRepository.MAX_WIZARDS; i++)
        {
            IWizard wizard = wizardRepository.GetWizard(i);
            if (wizard.Health == 0)
            {
                WizardPresentationRepository presentationRepository = ServiceLocator.GetWizardPresentationRepository();
                UIRepository uiRepository = ServiceLocator.GetUIRepository();

                WizardPresentation wizardPresentation = presentationRepository.GetWizard(i);
                WizardUI wizardUI = uiRepository.GetWizardUI(i);

                wizard.Revive();
                wizardPresentation.SetAnimation(5); //trigger death animation

                wizardUI.UpdateData(); //we reset stats so update the data
            }
        }

    }

    private void PrintSpell(byte[] spellData)
    {
        string hexString = BitConverter.ToString(spellData).Replace("-", " ");
        Debug.Log("Spell Data \n" + hexString);
    }
}
