using UnityEngine.Assertions;

public enum Instruction : byte
{
    SET_LITERAL = 0x00
}

public class VM
{
    private const int MAX_STACK = 128; //smol VM; smol stack size

    private int stackSize = 0;
    private int[] stack = new int[MAX_STACK];

    public void Interpret(byte[] instructions)
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            byte nextInstruction = instructions[i];
            switch (nextInstruction)
            {
                case (byte)Instruction.SET_LITERAL:

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
}
