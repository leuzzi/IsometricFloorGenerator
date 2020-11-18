using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FloorGenerator : FloorManager
{
    private GameObject blocks;
    [SerializeField] private BlockStats stats;
    [SerializeField] GameObject[,] grid;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void InitiateGenerator(BlockStats stats)
    {
        grid = new GameObject[10, 10];
        Debug.Log("grid initialised");
        this.stats = stats;
        this.stats.LogStatus();
        Debug.Log("InitiateGeneration");
        placeBlock();
    }

    void placeBlock()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Debug.Log("Placing block " + y + " " + x);
                grid[x, y] = stats.InstantiateSelf(x, y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
