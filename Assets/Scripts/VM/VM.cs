using UnityEngine;
using UnityEngine.Assertions;

public enum Instruction : byte
{
    //allow 64 instructions :D
    SET_LITERAL = 0xC0,
    GET_HEALTH  = 0xC1,
    SET_HEALTH  = 0xC2,
    GET_WISDOM  = 0xC3,
    SET_WISDOM  = 0xC4,
    ADD         = 0xC5,
    SUBTRACT    = 0xC6, //cannot be assed to do signed bit gymnastics
    MULTIPLY    = 0xC7,
    DIVIDE      = 0xC8, //cannot be assed to do float gymnastics
    PLAY_ANIM   = 0xC9,
    PLAY_VFX    = 0xCA,
}

public class VM
{
    private const int MAX_STACK = 128; //smol VM; smol stack size

    private int stackSize = 0;
    private int[] stack = new int[MAX_STACK];

    public void Interpret(byte[] byteCode)
    {
        for (int i = 0; i < byteCode.Length; i++)
        {
            byte nextInstruction = byteCode[i];
            switch (nextInstruction)
            {
                case (byte)Instruction.SET_LITERAL:
                    int literalValue = byteCode[++i];
                    Push(literalValue);

                    break;

                case (byte)Instruction.GET_HEALTH:
                    int wizardID = Pop();

                    int value = GetHealth(wizardID);
                    Push(value);

                    break;

                case (byte)Instruction.SET_HEALTH:
                    wizardID = Pop();
                    int amount = Pop();

                    SetHealth(wizardID, amount);

                    break;

                case (byte)Instruction.GET_WISDOM:
                    wizardID = Pop();

                    value = GetWisdom(wizardID);
                    Push(value);

                    break;

                case (byte)Instruction.SET_WISDOM:
                    wizardID = Pop();
                    amount = Pop();

                    SetWisdom(wizardID, amount);

                    break;

                case (byte)Instruction.ADD:
                    int b = Pop();
                    int a = Pop();

                    Push(a + b);

                    break;

                case (byte)Instruction.SUBTRACT:
                    b = Pop();
                    a = Pop();

                    Push(a - b);

                    break;

                case (byte)Instruction.MULTIPLY:
                    b = Pop();
                    a = Pop();

                    Push(a * b);

                    break;

                case (byte)Instruction.DIVIDE:
                    b = Pop();
                    a = Pop();

                    //avoid division by 0
                    b = b == 0 ? 1 : b;
                    Push(a / b);

                    break;

                case (byte)Instruction.PLAY_ANIM:
                    wizardID = Pop();
                    int trigger = Pop();

                    PlayAnimation(wizardID, trigger);

                    break;

                case (byte)Instruction.PLAY_VFX:
                    wizardID = Pop();
                    int vfxID = Pop();

                    PlayVFX(wizardID, vfxID);

                    break;
            }
        }
    }

    private void Push(int value)
    {
        Assert.IsTrue(stackSize < MAX_STACK);
        stack[stackSize++] = value;
    }

    private int Pop()
    {
        Assert.IsTrue(stackSize > 0);
        return stack[--stackSize];
    }

    private int GetHealth(int wizardID)
    {
        IWizardRepository wizardRepository = ServiceLocator.GetWizardRepository();

        IWizard wizard = wizardRepository.GetWizard(wizardID);
        return wizard.Health;
    }

    private void SetHealth(int wizardID, int amount)
    {
        IWizardRepository wizardRepository = ServiceLocator.GetWizardRepository();

        IWizard wizard = wizardRepository.GetWizard(wizardID);
        wizard.SetHealth(amount);
    }

    private int GetWisdom(int wizardID)
    {
        IWizardRepository wizardRepository = ServiceLocator.GetWizardRepository();

        IWizard wizard = wizardRepository.GetWizard(wizardID);
        return wizard.Wisdom;
    }

    private void SetWisdom(int wizardID, int amount)
    {
        IWizardRepository wizardRepository = ServiceLocator.GetWizardRepository();

        IWizard wizard = wizardRepository.GetWizard(wizardID);
        wizard.SetWisdom(amount);
    }

    private void PlayAnimation(int wizardID, int trigger)
    {
        WizardPresentationRepository wizardPresentationRepository = ServiceLocator.GetWizardPresentationRepository();

        WizardPresentation wizardPresentation = wizardPresentationRepository.GetWizard(wizardID);
        wizardPresentation.SetAnimation(trigger);
    }

    private void PlayVFX(int wizardID, int vfxID)
    {
        WizardPresentationRepository wizardPresentationRepository = ServiceLocator.GetWizardPresentationRepository();
        VFXRepository vfxRepository = ServiceLocator.GetVFXRepository();

        WizardPresentation wizardPresentation = wizardPresentationRepository.GetWizard(wizardID);

        ParticleSystem vfx = vfxRepository.GetParticleSystem(vfxID);
        vfx.Stop();

        //set to wizard pos and play
        vfx.transform.position = wizardPresentation.transform.position;
        vfx.Play();
    }
}
