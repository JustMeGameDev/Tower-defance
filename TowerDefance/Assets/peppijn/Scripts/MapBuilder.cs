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

    [Header("Basic Map Parameters")]
    public int pathLength;
    public int mapSize;

    [Header("Seed Generator")]
    public string stringSeed = "seed string";
    public bool useStringSeed;
    public int seed;
    public bool useRandomSeed;

    [Header("NavMesh Surfaces")]
    public NavMeshSurface navHuman;
    public NavMeshSurface navOgre;



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
            activeTile = Instantiate(pathTile, transform);
            Transform spawntransform = activeTile.transform;
            spawntransform.position = new Vector3(spawntransform.position.x, spawntransform.position.y + 5, spawntransform.position.z);
            Instantiate(EnemySpawn, spawntransform);

        for (int i = 0; i < pathLength; i++)
        {
            tile = activeTile.GetComponent<PathTile>();
            point = CheckBuild();
            PlaceTile(point, pathTile);

        }
        point = CheckBuild();
        PlaceTile(point, EnemyTarget);
        for (int i = 0; i < mapSize; i++)
        {
            FillWorld();

            navHuman.AddData();
            navOgre.AddData();

            navHuman.BuildNavMesh();
            navOgre.BuildNavMesh();

        }
    }

    private Transform CheckBuild()
    {
        transformPoints = new List<Transform>();
        transformTemp = activeTile.GetComponentsInChildren<Transform>();
        for (int i = 0; i < transformTemp.Length; i++)
        {
            if (transformTemp[i].tag == "point")
            {
                transformPoints.Add(transformTemp[i]);
            }
        }
        for (int i = 0; i < transformPoints.Count; i++)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transformPoints[i].position, 5.5f, 1 << 7);

            if (hitColliders.Length > 1)
            {

                transformPoints.RemoveAt(i);
            }
        }
        int rd = Random.Range(0,transformPoints.Count);
        Debug.Log(rd);
        placePoint = transformPoints[rd];
        
        
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

