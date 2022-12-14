using UnityEngine;

public class WizardRepository : IWizardRepository
{
    private static int uniqueID = 0;

    public const int MAX_WIZARDS = 2; //simple game, 2 wizards :D
    private Wizard[] wizards = new Wizard[MAX_WIZARDS];

    private NullWizard nullWizard = new NullWizard();

    public WizardRepository()
    {
        uniqueID = 0;

        //simple game; create wizards and be done
        for (int i = 0; i < MAX_WIZARDS; i++)
        {
            CreateWizard();
        }
    }

    private void CreateWizard()
    {
        GameObject wizardGameObject = new GameObject();

        Wizard wizardEntity = wizardGameObject.AddComponent<Wizard>();
        wizardEntity.Init(uniqueID);

        wizards[uniqueID] = wizardEntity;

        ++uniqueID;
    }

    public IWizard GetWizard(int id)
    {
        if (id < 0 || id >= MAX_WIZARDS)
        {
            return nullWizard; //send null object to avoid null refs :D
        }

        return wizards[id];
    }
}
