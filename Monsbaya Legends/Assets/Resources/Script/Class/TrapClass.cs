using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapClass : MonoBehaviour
{

   
    public bool doDamage = false;
    public bool inflictAilment = false;
    public string ailmentName;
    public int damageDone;

    // Start is called before the first frame update
    void Start()
    {
    }

    public TrapClass ChooseTypeOfTrap(int index)
    {
        switch (index)
        {
            case 0:
                this.doDamage = true;
                this.damageDone = 10;
                break;
            case 1:
                this.inflictAilment = true;
                this.ailmentName = "poison";
                break;
            case 2:
                this.inflictAilment = true;
                this.ailmentName = "slowness";
                break;
            case 3:
                this.inflictAilment = true;
                this.ailmentName = "paralysis";
                break;
            case 4:
                this.inflictAilment = true;
                this.ailmentName = "burnt";
                break;
            case 5:
                this.inflictAilment = true;
                this.ailmentName = "blindness";
                break;
        }
        return this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
