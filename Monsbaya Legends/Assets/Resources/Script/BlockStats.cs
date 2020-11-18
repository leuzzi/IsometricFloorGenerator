using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStats : FloorGenerator
{
    [SerializeField] private SpriteRenderer skin;
    [SerializeField] private GameObject resource;
    [SerializeField] private float size;
    [SerializeField] protected bool status = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In blockStat start");
    }

    public void InitiateSelf()
    {
        setBlock();
        setSize(0.515f);
        SetStatus();
    }

    void setSize(float size)
    {
        this.size = size;
    }

    void SetStatus()
    {
        this.status = !this.status;
    }

    public void LogStatus()
    {
        Debug.Log(this.status);
    }

    void SetBlock(string name)
    {
        resource = Resources.Load("Prefab/" + name, typeof(GameObject)) as GameObject;
    }

    void setBlock()
    {
        resource = Resources.Load("Prefab/GrassBlock", typeof(GameObject)) as GameObject;
    }
    
    public GameObject InstantiateSelf(int i, int j)
    {
        float x = ((i * this.size) - (j * this.size));
        float y = ((j * this.size) + (i * this.size)) / 2;
        Vector2 vec = new Vector2(y, x);
        GameObject test = Instantiate(resource, vec, Quaternion.identity, transform);
        return test;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
