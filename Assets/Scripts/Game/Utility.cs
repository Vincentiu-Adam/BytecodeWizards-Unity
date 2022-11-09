
public class Utility
{
    public static void UpdateUIData()
    {
        UIRepository uiRepository = ServiceLocator.GetUIRepository();
        for (int i = 0; i < WizardRepository.MAX_WIZARDS; i++)
        {
            WizardUI wizardUI = uiRepository.GetWizardUI(i);
            wizardUI.UpdateData();
        }
    }
}
