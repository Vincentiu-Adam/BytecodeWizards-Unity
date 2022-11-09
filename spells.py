def createFireSpell(spellData) :
    #set second wizard for hit animation
    spellData[0] = 0xC0;
    spellData[1] = 0x01;

    #set first wizard for attack animation
    spellData[2] = 0xC0;
    spellData[3] = 0x00;

    #set second wizard for set health
    spellData[4] = 0xC0;
    spellData[5] = 0x01;

    #set second wizard for subtract
    spellData[6] = 0xC0;
    spellData[7] = 0x01;

    #get health value
    spellData[8] = 0xC1;

    #set damage
    spellData[9]  = 0xC0;
    spellData[10] = 0x14; #20 decimal

    #subtract damage
    spellData[11] = 0xC6;

    #set wizard health
    spellData[12] = 0xC2;

    #set attack animation trigger
    spellData[13] = 0xC0;
    spellData[14] = 0x02; #2 is attack triger

    #play attack animation on first wizard
    spellData[15] = 0xC9;

    #set hit animation trigger
    spellData[16] = 0xC0;
    spellData[17] = 0x04; #4 is attack triger

    #play hit animation on second wizard
    spellData[18] = 0xC9;

def createHealSpell(spellData) :
    #set second wizard for attack animation
    spellData[0] = 0xC0;
    spellData[1] = 0x01;

    #set second wizard for set health
    spellData[2] = 0xC0;
    spellData[3] = 0x01;

    #set second wizard for add
    spellData[4] = 0xC0;
    spellData[5] = 0x01;

    #get health value
    spellData[6] = 0xC1;

    #set damage
    spellData[7] = 0xC0;
    spellData[8] = 0x0A; #10 decimal

    #add damage
    spellData[9] = 0xC5;

    #set wizard health
    spellData[10] = 0xC2;

    #set attack animation trigger
    spellData[11] = 0xC0;
    spellData[12] = 0x03; #3 is attack triger

    #play attack animation on first wizard
    spellData[13] = 0xC9;

fireSpell = bytearray([0x00] * 19);
healSpell = bytearray([0x00] * 14);

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
