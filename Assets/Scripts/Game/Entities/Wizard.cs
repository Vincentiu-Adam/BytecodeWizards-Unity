using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wisdom))]
public class Wizard : MonoBehaviour, IWizard
{
    public int ID { get; private set; }

    private Health healthComponent;
    public int Health => healthComponent.Value;

    private Wisdom wisdomComponent;
    public int Wisdom => wisdomComponent.Value;

    private void Awake()
    {
        healthComponent = GetComponent<Health>();
        wisdomComponent = GetComponent<Wisdom>();
    }

    public void Init(int id)
    {
        ID = id;
    }

    public void SetHealth(int value)
    {
        healthComponent.Value = value;
    }

    public void SetWisdom(int value)
    {
        wisdomComponent.Value = value;
    }
}
