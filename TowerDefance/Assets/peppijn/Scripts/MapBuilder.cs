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



    void Awake()
    {
        //vault = GameObject.FindWithTag("Vault").GetComponent<Vault>();
        //if (!vault.contractseed)
        //{
            GenarateSeed();
            GenarateWorld();

        //}
        //else
        //{
          //  useRandomSeed = false;
          //  seed = PlayerPrefs.GetInt("SelectedSeed");
          //  Random.InitState(seed);
           // GenarateWorld();
        //}
    }

    private void Update()
    {
        if (testTimer > 0)
        {
            testTimer -= Time.deltaTime;
        }
        if (testTimer < 0)
        {
            testTimer = 0;
        }
        navHuman.BuildNavMesh();
        navOgre.BuildNavMesh();
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
            Collider[] hitColliders = Physics.OverlapSphere(i.position, 7f, layerMask);
            if (hitColliders.Length <= 1)
            {
                transformPointsFinal.Add(i);
            }
        }
        int rd = Random.Range(0,transformPointsFinal.Count);
        placePoint = transformPointsFinal[rd];
        
        
        return placePoint;
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
}

