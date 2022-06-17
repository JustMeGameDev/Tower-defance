using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class MapBuilder : MonoBehaviour
{

    [Header("Tiles")]
    public GameObject pathTile;
    public GameObject grassTile;
    public GameObject EnemySpawn;
    public GameObject EnemyTarget;
    

    [Header("Tile Logic")]
    public GameObject activeTile;
    public Transform point;
    private Transform placePoint;
    public PathTile tile;
    public Transform[] transformTemp;
    public List<Transform> transformPoints;
    public List<Transform> transformPointsFinal;

    [Header("Basic Map Parameters")]
    public int pathLength;
    public int mapSize;
    public LayerMask layerMask;
    public bool buggedMap;
    public bool finishedMap;

    [Header("Seed Generator")]
    public string stringSeed = "seed string";
    public bool useStringSeed;
    public int seed;
    public bool useRandomSeed;

    [Header("NavMesh Surfaces")]
    public NavMeshSurface navHuman;
    public NavMeshSurface navOgre;
    public NavMeshSurface navBat;
    public NavMeshSurface navChicken;
    public NavMeshSurface navDragon;
    public NavMeshSurface navSlime;


    public float testTimerValue;
    public float testTimer;
    public Vault vault;

    [Header("Enviorment")]
    public GameObject[] enviorment;


    void Awake()
    {

        switch (PlayerPrefs.GetString("gameMode"))
        {
            case "Carreer":
                useRandomSeed = false;
                seed = PlayerPrefs.GetInt("seed");
                pathLength = PlayerPrefs.GetInt("mapLength");
                break;
            case "Custom":
                useRandomSeed = false;
                seed = PlayerPrefs.GetInt("seed");
                pathLength = PlayerPrefs.GetInt("mapLength");
                break;
            case "Random":
                useRandomSeed = true;
                break;
        }
    }

    private void Update()
    {
        if (!finishedMap)
        {
            GenarateSeed();
            GenarateWorld();
        }
        if (buggedMap)
        {
            ResetWorld();
            finishedMap = false;
            useRandomSeed = true;
        }
        navHuman.UpdateNavMesh(navHuman.navMeshData);
        navOgre.UpdateNavMesh(navOgre.navMeshData);
        navBat.UpdateNavMesh(navBat.navMeshData);
        navChicken.UpdateNavMesh(navChicken.navMeshData);
        navDragon.UpdateNavMesh(navDragon.navMeshData);
        navSlime.UpdateNavMesh(navSlime.navMeshData);   
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
            activeTile = Instantiate(EnemySpawn, transform);


        for (int i = 0; i < pathLength; i++)
        {
                point = CheckBuild();
                if (buggedMap) return;
                PlaceTile(point, pathTile);
                testTimer = testTimerValue;
        }
        point = CheckBuild();
        PlaceTile(point, EnemyTarget);
        for (int i = 0; i < mapSize; i++)
        {
            FillWorld();
        }
        navHuman.AddData();
        navOgre.AddData();
        navBat.AddData();
        navChicken.AddData();
        navDragon.AddData();
        navSlime.AddData();

        navHuman.BuildNavMesh();
        navOgre.BuildNavMesh();
        navBat.BuildNavMesh();
        navChicken.BuildNavMesh();
        navDragon.BuildNavMesh();
        navSlime.BuildNavMesh();
        finishedMap = true;
    }

    private Transform CheckBuild()
    {
        transformPoints = new List<Transform>();
        transformPointsFinal = new List<Transform>();
        transformTemp = activeTile.GetComponentsInChildren<Transform>();
        for (int i = 0; i < transformTemp.Length; i++)
        {
            if (transformTemp[i].tag == "point")
            {
                transformPoints.Add(transformTemp[i]);
            }
        }
        
        foreach (Transform i in transformPoints)
        {
            Collider[] hitColliders = Physics.OverlapSphere(i.position, 9f, layerMask);
            if (hitColliders.Length <= 1)
            {
                transformPointsFinal.Add(i);
            }
        }
        if (transformPointsFinal.Count > 0)
        {
            int rd = Random.Range(0, transformPointsFinal.Count);
            placePoint = transformPointsFinal[rd];
            return placePoint;
        }
        else
        {
            buggedMap = true;
            return null;
        }
        
    }

    private void PlaceTile(Transform Point, GameObject tile)
    {
        activeTile = Instantiate(tile, placePoint.position, placePoint.rotation);

    }

    private void FillWorld()
    {
        transformPoints = new List<Transform>();
        GameObject[] gmTemp = GameObject.FindGameObjectsWithTag("point");
        for (int i = 0; i < gmTemp.Length; i++)
        {
            transformPoints.Add(gmTemp[i].transform);
        }


        foreach (Transform i in transformPoints)
        {
            Collider[] hitColliders = Physics.OverlapSphere(i.position, 0.1f);
            if (hitColliders.Length == 0)
            {
                GameObject tile = Instantiate(grassTile, i.position, i.rotation);
                Transform[] tileTemp = tile.GetComponentsInChildren<Transform>();

            }
        }
    }

    private void ResetWorld()
    {
         GameObject[] resetTiles;
        resetTiles = GameObject.FindGameObjectsWithTag("Tiles");
        foreach (GameObject i in resetTiles)
        {
            GameObject.Destroy(i);
        }
        buggedMap = false;
        return;
    }
        
        
    
}

