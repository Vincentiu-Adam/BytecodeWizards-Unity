using UnityEngine.Assertions;

public enum Instruction : byte
{
    //allow 64 instructions :D
    SET_LITERAL = 0xC0,
    SET_HEALTH  = 0xC1,
    SET_WISDOM  = 0xC2,
    ADD         = 0xC3,
    MULTIPLY    = 0xC4
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

                case (byte)Instruction.SET_HEALTH:
                    int amount = Pop();
                    int wizardID = Pop();

                    SetHealth(wizardID, amount);

                    break;

                case (byte)Instruction.SET_WISDOM:
                    amount = Pop();
                    wizardID = Pop();

                    SetWisdom(wizardID, amount);

                    break;

                case (byte)Instruction.ADD:
                    int b = Pop();
                    int a = Pop();

                    Push(a + b);

                    break;

                case (byte)Instruction.MULTIPLY:
                    b = Pop();
                    a = Pop();

                    Push(a * b);

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

    private void SetHealth(int wizardID, int amount)
    {
        IWizardRepository wizardRepository = ServiceLocator.GetWizardRepository();

        IWizard wizard = wizardRepository.GetWizard(wizardID);
        wizard.SetHealth(amount);
    }

    private void SetWisdom(int wizardID, int amount)
    {
        IWizardRepository wizardRepository = ServiceLocator.GetWizardRepository();

        IWizard wizard = wizardRepository.GetWizard(wizardID);
        wizard.SetWisdom(amount);
    }
}
