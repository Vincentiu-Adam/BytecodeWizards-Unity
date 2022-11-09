using System.Collections.Generic;
using UnityEngine;

public class UIRepository
{
    private const string CONTAINER_TAG = "ui_container";

    private List<WizardUI> wizardUIs = new List<WizardUI>();

    public UIRepository()
    {
        GameObject containerObject = GameObject.FindGameObjectWithTag(CONTAINER_TAG);
        foreach (Transform child in containerObject.transform)
        {
            WizardUI wizardUI = child.GetComponent<WizardUI>();
            wizardUIs.Add(wizardUI);
        }
    }

    public WizardUI GetWizardUI(int id)
    {
        if (id < 0 || id >= wizardUIs.Count)
        {
            return null;
        }

        return wizardUIs[id];
    }
}
