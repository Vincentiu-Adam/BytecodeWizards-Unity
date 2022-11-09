using UnityEngine;

public class WizardPresentationRepository
{
    private static int uniqueID = 0;

    private const string CONTAINER_TAG = "prefab_container";

    private WizardPresentation[] wizardPresentations = new WizardPresentation[WizardRepository.MAX_WIZARDS];

    public WizardPresentationRepository()
    {
        uniqueID = 0;

        //simple game; create wizards and be done
        for (int i = 0; i < WizardRepository.MAX_WIZARDS; i++)
        {
            CreateWizardPresentation(i);
        }
    }

    private void CreateWizardPresentation(int slotIndex)
    {
        GameObject containerObject = GameObject.FindGameObjectWithTag(CONTAINER_TAG);

        //wizard prefabs are inside slots
        GameObject wizardGameObject = containerObject.transform.GetChild(slotIndex).GetChild(0).gameObject;

        WizardPresentation wizardPresentationEntity = wizardGameObject.AddComponent<WizardPresentation>();
        wizardPresentationEntity.Init(uniqueID);

        wizardPresentations[uniqueID] = wizardPresentationEntity;

        ++uniqueID;
    }

    public WizardPresentation GetWizard(int id)
    {
        if (id < 0 || id >= WizardRepository.MAX_WIZARDS)
        {
            return null; //send null object to avoid null refs :D
        }

        return wizardPresentations[id];
    }
}
