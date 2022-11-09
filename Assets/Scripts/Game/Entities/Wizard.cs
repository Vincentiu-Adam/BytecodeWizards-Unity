using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wisdom))]
public class Wizard : MonoBehaviour, IWizard
{
    public int ID { get; private set; }

    private Health healthComponent;
    public int Health => healthComponent.Value;
    public int MaxHealth => 100;

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

        gameObject.name = "wizard_" + ID;
    }

    public void SetHealth(int value)
    {
        healthComponent.Value = Mathf.Clamp(value, 0, MaxHealth);
    }

    public void SetWisdom(int value)
    {
        wisdomComponent.Value = Mathf.Min(value, 0);
    }
}
