fireSpell = bytearray([0x00] * 4);
iceSpell = bytearray([0x00] * 4);
lightningSpell = bytearray([0x00] * 4);

fireSpell[0] = 0xC0;
fireSpell[2] = 0x0A;
fireSpell[3] = 0xC1;

dirName = "Assets/Spells/";

with open(dirName + "fire.bin", "wb") as binFile :
    binFile.write(fireSpell);

with open(dirName + "ice.bin", "wb") as binFile :
    binFile.write(iceSpell);

with open(dirName + "lightning.bin", "wb") as binFile :
    binFile.write(lightningSpell);