using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileScript : MonoBehaviour
{
    public bool HaveTrap;
    public TrapClass trap;
    public bool HaveItemOn;
    public ItemClass item;
    public TileBase tile;

    // Start is called before the first frame update
    void Start()
    {
        CalculateIfTrap();
        CalculateIfItem();
    }

    void CalculateIfTrap()
    {
        int x = UnityEngine.Random.Range(0, 100);
        if (x > 95) 
        {
            this.HaveTrap = true;
            trap = gameObject.AddComponent<TrapClass>();
            SetTrap(x - 95);
        } else
        {
            this.HaveTrap = false;
        }
    }

    void SetTrap(int index)
    {
        trap.ChooseTypeOfTrap(index);
    }

    void CalculateIfItem()
    {
        int x = UnityEngine.Random.Range(0, 100);
        if (x > 90)
        {
        this.HaveItemOn = true;
        item = gameObject.AddComponent<ItemClass>();
        SetItem(x - 90);
        }
    }

    void SetItem(int index)
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
