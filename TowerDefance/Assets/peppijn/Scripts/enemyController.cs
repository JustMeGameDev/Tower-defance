using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private GameObject[] checkPointsTemp;
    public List<checkPoint> checkPoints;
    private checkPoint addCheck;

    void Start()
    {
        checkPointsTemp = GameObject.FindGameObjectsWithTag("CheckPoint");
        for (int i = 0; i < checkPointsTemp.Length; i++)
        {
            foreach (GameObject o in checkPointsTemp)
            {
                addCheck = o.GetComponent<checkPoint>();
                if (addCheck.id == i)
                {
                    checkPoints.Add(addCheck);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
