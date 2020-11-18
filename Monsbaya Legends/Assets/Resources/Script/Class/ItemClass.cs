using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    private bool isScripted;
    private bool isCursed;
    private bool isUpgraded;
    private bool isFake;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {        
    }


    // Implementer un pattern factory pour virer ce switch
    /*public ItemClass CalculateTypeOfItem(int index)
    {
        switch (index)
        {
            case 0:
                GenerateWeapon();
                break;
            case 1:
                GenerateArmor();
                break;
            case 2:
                GeneratePotion();
                break;
            case 3:
                GenerateAmmunition();
                break;
            case 4:
                GenerateOre();
                break;
            case 5:
                GenerateComponent();
                break;
            case 6:
                GenerateUpgrader();
                break;
            case 7:
                GenerateOrb();
                break;
            case 8:
                GenerateSeeds();
                break;
            case 9:
                GenerateGold();
                break;
            case 10:
                GenerateEgg();
                break;
        }
        return this;
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
