using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public enum SpellType : uint
{
    FIRE,
    ICE,
    LIGHTNING,
    HEAL
}

public class SpellData
{
    public byte[] Data;

    public string FileName;

    public string MD5Hash;
}

public class SpellRepository
{
    private string dirName = Application.dataPath + "./Spells";

    //spells are a list of bytecode
    private Dictionary<SpellType, SpellData> spellList = new Dictionary<SpellType, SpellData>();

    private byte[] emptySpell = new byte[0];

    private MD5 md5 = MD5.Create();

    private int lastUpdateFrame = 0;

    public SpellRepository()
    {
        //go through files in spell dir and load data
        int spellType = 0;

        string[] spellFiles = Directory.GetFiles(dirName, "*.bin");
        foreach (string spellFile in spellFiles)
        {
            using (FileStream file = File.Open(spellFile, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(file))
                {
                    //we know files are small so convert long to int, lol
                    byte[] data = reader.ReadBytes((int) file.Length);

                    SpellData spellData = new SpellData() { Data = data, FileName = spellFile, MD5Hash = GetMD5Hash(data) };
                    spellList.Add((SpellType)spellType, spellData);

                    ++spellType;
                }
            }
        }
    }

    public void Update()
    {
        //update every 20 frames
        if (Time.frameCount - lastUpdateFrame > 20)
        {
            lastUpdateFrame = Time.frameCount;

            //compare hash of all files and reload if changed
            foreach (SpellData spellData in spellList.Values)
            {
                string spellFile = spellData.FileName;
                using (FileStream file = File.Open(spellFile, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(file))
                    {
                        //we know files are small so convert long to int, lol
                        byte[] data = reader.ReadBytes((int) file.Length);

                        string md5Hash = GetMD5Hash(data);

                        //if same do nothing, otherwise reload?
                        if (!spellData.MD5Hash.Equals(md5Hash))
                        {
                            spellData.Data = data;
                        }
                    }
                }
            }
        }
    }

    private string GetMD5Hash(byte[] data)
    {
        byte[] encoded = md5.ComputeHash(data);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < encoded.Length; i++)
        {
            sb.Append(encoded[i].ToString("x2"));
        }

        return sb.ToString();
    }

    public byte[] GetSpellData(SpellType spellType)
    {
        if (!spellList.ContainsKey(spellType))
        {
            return emptySpell; //outside of range just return a spell with no data
        }

        return spellList[spellType].Data;
    }
}
