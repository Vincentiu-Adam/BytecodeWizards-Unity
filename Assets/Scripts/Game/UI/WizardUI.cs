using UnityEngine;
using UnityEngine.UI;

public class WizardUI : MonoBehaviour
{
    [SerializeField]
    private uint wizardID;

    [SerializeField]
    private Text wisdomText;

    [SerializeField]
    private Slider healthSlider;

    private void SetWisdom()
    {
        IWizard wizard = GetWizard();
        wisdomText.text = "Wisdom : " + wizard.Wisdom.ToString();
    }

    private void SetHealth()
    {
        IWizard wizard = GetWizard();

        float ratio = wizard.Health / wizard.MaxHealth;
        healthSlider.value = ratio;
    }

    private IWizard GetWizard()
    {
        IWizardRepository wizardRepository = ServiceLocator.GetWizardRepository();
        return wizardRepository.GetWizard((int)wizardID);
    }

    public void UpdateData()
    {
        SetHealth();
        SetWisdom();
    }
}
