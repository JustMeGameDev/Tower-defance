using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public canvasCheck CanvasCheck;
    RaycastHit hit;
    [SerializeField]
    GameObject prefab;

    public Material[] nonPlaceMat;
    [SerializeField]
    Material[] startMats;
    [SerializeField]
    MeshRenderer mr;
    
   
    bool isPlaceAble;

    void Start()
    {
        mr = GetComponentInChildren<MeshRenderer>();
        startMats = mr.materials;       
    }
    private void Awake()
    {
        CanvasCheck = GameObject.FindWithTag("GameMaster").GetComponent<canvasCheck>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 6))
        {
            transform.position = hit.point;
            isPlaceAble = true;

            mr.materials = startMats;         
        }
        else
        {
            isPlaceAble = false;
            mr.materials = nonPlaceMat;    
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4f, 1 << 8);

        if (hitColliders.Length < 1)
        {

            if (Input.GetMouseButton(0) && isPlaceAble == true)
            {
                GameObject TowerTemp = Instantiate(prefab, transform.position, transform.rotation);
                PopUp popupTemp = TowerTemp.GetComponent<PopUp>();
                CanvasCheck.Towers.Add(popupTemp);
                Destroy(gameObject);
            }
        }
        else
        {
             mr.materials = nonPlaceMat;
        }
 
    }
}
