using UnityEngine;

[RequireComponent(typeof(Animation))]
public class WizardPresentation : MonoBehaviour
{
    public int ID { get; private set; }

    private Animation animationComponent;

    private void Awake()
    {
        //link animator to component
        animationComponent = GetComponent<Animation>();
        animationComponent.Animator = GetComponent<Animator>();
    }

    public void Init(int id)
    {
        ID = id;

        gameObject.name = "wizard_presentation_" + ID;
    }

    public void SetAnimation(int trigger)
    {
        animationComponent.Animator.SetTrigger(trigger.ToString());
    }
}
