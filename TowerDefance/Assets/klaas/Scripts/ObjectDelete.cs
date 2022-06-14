using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
   [SerializeField] private float waitTime;

    private void Start()
    {
        StartCoroutine(DeleteCountDown());
    }
    IEnumerator DeleteCountDown()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
   
}
