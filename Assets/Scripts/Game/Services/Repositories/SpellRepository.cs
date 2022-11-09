using System.IO;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType : uint
{
    FIRE,
    ICE,
    LIGHTNING,
    HEAL
}

public class SpellRepository
{
    private string dirName = Application.dataPath + "./Spells";

    //spells are a list of bytecode
    private List<byte[]> spellList = new List<byte[]>();

    private byte[] emptySpell = new byte[0];

    public SpellRepository()
    {
        //go through files in spell dir and load data
        string[] spellFiles = Directory.GetFiles(dirName, "*.bin");
        foreach (string spellFile in spellFiles)
        {
            using (FileStream file = File.Open(spellFile, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(file))
                {
                    //we know files are small so convert long to int, lol
                    byte[] spellData = reader.ReadBytes((int) file.Length);
                    spellList.Add(spellData);
                }
            }
        }
    }

    public byte[] GetSpellData(SpellType spellType)
    {
        int spellIndex = (int) spellType;
        if (spellIndex < 0 || spellIndex >= spellList.Count)
        {
            return emptySpell; //outside of range just return a spell with no data
        }

        return spellList[spellIndex];
    }
}
