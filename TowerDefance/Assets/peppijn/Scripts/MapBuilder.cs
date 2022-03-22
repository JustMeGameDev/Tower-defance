using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    [Header("Tiles")]
    public GameObject pathTile;
    public GameObject grassTile;
    public GameObject EnemySpawn;
    public GameObject EnemyTarget;

    [Header("Basic Map Parameters")]
    public int pathLength;
    public int mapSize;

    [Header("Seed Generator")]
    public string stringSeed = "seed string";
    public bool useStringSeed;
    public int seed;
    public bool useRandomSeed;

    void Awake()
    {
        GenarateSeed();
        GenarateWorld();
    }





    private void GenarateSeed()
    {
        if (useRandomSeed)
        {
            seed = Random.Range(0, 99999); 
        }
        if (useStringSeed)
        {
            seed = stringSeed.GetHashCode();
        }

        Random.InitState(seed);
    }


    private void GenarateWorld()
    {

    }
}
