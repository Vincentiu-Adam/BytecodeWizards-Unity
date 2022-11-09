def createFireSpell(spellData) :
    #set second wizard
    spellData[0] = 0xC0;
    spellData[1] = 0x01;

    #set second wizard again
    spellData[2] = 0xC0;
    spellData[3] = 0x01;

    #get health value
    spellData[4] = 0xC1;

    #set damage
    spellData[5] = 0xC0;
    spellData[6] = 0x14; #20 decimal

    #subtract damage
    spellData[7] = 0xC6;

    #set wizard health
    spellData[8] = 0xC2;

def createHealSpell(spellData) :
    #set second wizard
    spellData[0] = 0xC0;
    spellData[1] = 0x01;

    #set second wizard again
    spellData[2] = 0xC0;
    spellData[3] = 0x01;

    #get health value
    spellData[4] = 0xC1;

    #set damage
    spellData[5] = 0xC0;
    spellData[6] = 0x0A; #10 decimal

    #add damage
    spellData[7] = 0xC5;

    #set wizard health
    spellData[8] = 0xC2;

fireSpell = bytearray([0x00] * 9);
healSpell = bytearray([0x00] * 9);

iceSpell = bytearray([0x00] * 4);
lightningSpell = bytearray([0x00] * 4);

createFireSpell(fireSpell);
createHealSpell(healSpell);

dirName = "Assets/Spells/";

spellArray = [fireSpell, iceSpell, lightningSpell, healSpell];
nameArray = ["01_fire.bin", "02_ice.bin", "03_lightning.bin", "04_heal.bin"];

for i in range(0, len(spellArray)) :
    with open(dirName + nameArray[i], "wb") as binFile :
        binFile.write(spellArray[i]);
