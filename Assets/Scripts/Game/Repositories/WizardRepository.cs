using UnityEngine;

public class WizardRepository : MonoBehaviour
{
    private static int uniqueID = 0;

    private Wizard[] wizards = new Wizard[2]; //simple game, 2 wizards :D

    private NullWizard nullWizard = new NullWizard();

    public void CreateWizard()
    {
        GameObject wizardGameObject = new GameObject();

        Wizard wizardEntity = wizardGameObject.AddComponent<Wizard>();
        wizardEntity.Init(uniqueID);

        wizards[uniqueID] = wizardEntity;

        ++uniqueID;
    }

    public IWizard GetWizard(int id)
    {
        if (id >= wizards.Length)
        {
            return nullWizard; //send null object to avoid null refs :D
        }

        return wizards[id];
    }
}
