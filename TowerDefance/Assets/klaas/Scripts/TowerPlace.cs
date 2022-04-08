using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public GameMaster gameMaster;
    
    RaycastHit hit;
    [SerializeField]
    GameObject prefab;

    public Material[] nonPlaceMat;
    [SerializeField]
    Material[] startMats;
    [SerializeField]
    MeshRenderer[] mr;
    public PopUpZonderCheck Close;

    public LayerMask layerMask;

    bool isPlaceAble;

    void Start()
    {
        startMats = mr[0].materials;
        startMats = mr[1].materials;
    }
    private void Awake()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        Close = GameObject.FindWithTag("ShopMenu").GetComponent<PopUpZonderCheck>();
    }
    void Update()
    {   
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 6))
        {
            transform.position = hit.point;
            isPlaceAble = true;

            mr[0].materials = startMats;
            mr[1].materials = startMats;

        }
        else
        {
            isPlaceAble = false;
            mr[0].materials = nonPlaceMat;
            mr[1].materials = nonPlaceMat;
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4f, 1 << 8);
        Collider[] EnvCollider = Physics.OverlapSphere(transform.position, 4f, 1 << 9);
       if (hitColliders.Length < 1)
           {

            if (Input.GetMouseButton(0) && isPlaceAble == true)
            {               
                GameObject TowerTemp = Instantiate(prefab, transform.position, transform.rotation);
                PopUp popupTemp = TowerTemp.GetComponent<PopUp>();
                
                gameMaster.Towers.Add(popupTemp);
                Close.Placing = false;

                foreach(Collider c in EnvCollider)
                {
                    Destroy(c.gameObject);
                }

                Destroy(gameObject);
            }
        }
        else
        {
            mr[0].materials = nonPlaceMat;
            mr[1].materials = nonPlaceMat;
        }
   if (Input.GetKey(KeyCode.Escape))
        {
    
            Close.Placing = false;
            
            Destroy(gameObject);
        }
    }
}
