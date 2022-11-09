fireSpell = bytearray([0x00] * 5);
iceSpell = bytearray([0x00] * 4);
lightningSpell = bytearray([0x00] * 4);

#set first wizard
fireSpell[0] = 0xC0;

#set health value
fireSpell[2] = 0xC0;
fireSpell[3] = 0xA0;

#set wizard health
fireSpell[4] = 0xC1;

dirName = "Assets/Spells/";

with open(dirName + "fire.bin", "wb") as binFile :
    binFile.write(fireSpell);

with open(dirName + "ice.bin", "wb") as binFile :
    binFile.write(iceSpell);

with open(dirName + "lightning.bin", "wb") as binFile :
    binFile.write(lightningSpell);