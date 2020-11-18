using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    FloorGenerator generator;
    BlockStats block;
    GameObject FloorGenerator;
    GameObject BlockStats;

    // Start is called before the first frame update
    void Start()
    {
        FloorGenerator = GameObject.Find("FloorGenerator");
        BlockStats = GameObject.Find("BlockStats");
        block = BlockStats.GetComponent<BlockStats>();
        generator = FloorGenerator.GetComponent<FloorGenerator>();
        block.InitiateSelf();
        generator.InitiateGenerator(block);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
