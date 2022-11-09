using System.IO;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType : uint
{
    FIRE,
    ICE,
    LIGHTNING
}

public class SpellRepository
{
    //spells are a list of bytecode
    private List<byte[]> spellList = new List<byte[]>();

    private string[] spellNames = new string[] { "fire.bin", "ice.bin", "lightning.bin" };

    private byte[] emptySpell = new byte[0];

    public SpellRepository()
    {
        //go through all dir names and load the spells
        string rootPath = Application.dataPath + "/Spells/";
        foreach (string spellName in spellNames)
        {
            string path = rootPath + spellName;

            using (FileStream file = File.Open(path, FileMode.Open))
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
