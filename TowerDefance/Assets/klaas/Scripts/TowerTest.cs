using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTest : MonoBehaviour
{
    private Transform target;
    
    
    [Header("Stats")]
    public float range = 15;
    public float damage = 10;
    public float attackSpeed = 10;

    [Header("Special Stats")]
    public float fireDamage;
    public float burnDamage;

    [Header("GameMaster")]
    public GameMaster gameMaster;
    public UpgradeTower upgradeTower;

    [Header("Aim Setup")]
    [SerializeField]
    Transform rotator = null;
    public Transform firePoint = null;
    float turnSpeed = 10;
    string enemyTag = "Enemy";
    

    [Header("Cannon")]
    public GameObject cannonBall = null;
    public GameObject specialCanBall = null;
    public GameObject fireCannonBall = null;
    public GameObject cannonExplosion = null;
    public bool useCannon= false;
    public bool cannonNormal = false;
    public bool cannonUpOne = false;
    public bool cannonUpTwo = false;


    [Header("Mage")]
    public LightningBoltScript lightningBolt = null;
    public ParticleSystem fireParticleSystem = null;
    public LineRenderer lineRenderer = null;
    public GameObject fireBall = null;
    public bool useNormal = false;
    public bool useLightning = false;
    public bool useFire = false;
    public bool useMage;
    public float fireDelay = 1f;

    [Header("BallistaTower")]
    public GameObject arrow;
    public GameObject arrowUpgradeOne;
    public GameObject arrowUpgradeTwo;
    public float ballistaDelay = 2;
    public bool useBallista;
    public bool ballistaNormal;
    public bool ballistaUpgradeOne;
    public bool ballistaUpgradeTwo;

    [Header("Flame")]
    public bool useFlame;

    [Header("Updrage")]
    public GameObject fireRotation;
    public GameObject lightingFX;
    public MeshRenderer[] towerMsh;
    public Material[] upgradeOne;
    public Material[] upgradeTwo;

    private void Awake()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        
    }
    void Start()
    {    
        InvokeRepeating("SelectTarget", 0, 1f);
    }
  
    void Update()
    {

        if (target == null)
        {

            if (useMage)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }

            return;

        }
        LookAtTarget();

        if (useMage)
        {
            Laser();
        }
        if(useCannon)
        {
            CannonShoot();
        }
        if(useBallista)
        {
            BallistaShoot();
        }
    }

    void SelectTarget()
    {     

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
       
      
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.CompareTag(enemyTag) && !c.gameObject.GetComponent<EnemyController>().death)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, c.gameObject.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = c.gameObject;
                }
            }
        }
        if (nearestEnemy != null && shortestDistance < range)
        {
            
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    void LookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        rotator.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    void Laser()   
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
           
        }

       

        if(useLightning)
        {
            
            lightningBolt.EndPosition = target.position;
            lightningBolt.Generations = 8;
            lightningBolt.enabled = true;
            target.gameObject.GetComponent<EnemyController>().health -= damage * Time.deltaTime;
        }

        if (useNormal)
        {

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);
           
            lightningBolt.enabled = false;
            target.gameObject.GetComponent<EnemyController>().health -= damage * Time.deltaTime;
        }

        if (useFire)
        {
            
            
            fireDelay -= Time.deltaTime;

            lineRenderer.enabled = false;
            if (fireDelay <= 0)
            {
                GameObject projFireBall = Instantiate(fireBall, firePoint.position, Quaternion.identity);
              //  projFireBall.GetComponent<FireBall>().damage = damage;
                projFireBall.GetComponent<FireBall>().target = target;
                damage += projFireBall.GetComponent<FireBall>().damage;
                fireDelay = 1f;
            }

        }
        
    }

    void CannonShoot()
    {
        fireDelay -= Time.deltaTime;

        if (fireDelay <= 0)
        {
            if (cannonNormal == true)
            {
                Instantiate(cannonExplosion, firePoint.position, Quaternion.identity);
                GameObject projCannonBall = Instantiate(cannonBall, firePoint.position, Quaternion.identity);
                projCannonBall.GetComponent<Bullet>().target = target;
                damage += projCannonBall.GetComponent<Bullet>().damage;
            } else if (cannonUpOne == true)
            {
                Instantiate(cannonExplosion, firePoint.position, Quaternion.identity);
                GameObject projCannonBall = Instantiate(specialCanBall, firePoint.position, Quaternion.identity);
                projCannonBall.GetComponent<SpecialBall>().target = target;
                damage += projCannonBall.GetComponent<SpecialBall>().explosiveDamage;
            } else if (cannonUpTwo == true)
            {
                Instantiate(cannonExplosion, firePoint.position, Quaternion.identity);
                GameObject projCannonBall = Instantiate(fireCannonBall, firePoint.position, Quaternion.identity);
                projCannonBall.GetComponent<FireCannonBall>().target = target;
                damage += projCannonBall.GetComponent<FireCannonBall>().explosiveDamage;
            }
           
            fireDelay = 1f;
        }
    }

    void BallistaShoot()
    {
        fireDelay -= Time.deltaTime;

        if (fireDelay <= 0)
        {
            if (ballistaNormal == true)
            {
                GameObject BulletGO = Instantiate(arrow, firePoint);
                BulletGO.GetComponent<Bullet>().target = target;
                damage += BulletGO.GetComponent<Bullet>().damage;
            }
            else if (ballistaUpgradeOne == true)
            {
                GameObject BulletGO = Instantiate(arrowUpgradeOne, firePoint);
                BulletGO.GetComponent<Bullet>().target = target;
                damage += BulletGO.GetComponent<Bullet>().damage;
            }
            else if (ballistaUpgradeTwo == true)
            {
                GameObject BulletGO = Instantiate(arrowUpgradeTwo, firePoint);
                BulletGO.GetComponent<Bullet>().target = target;
                damage += BulletGO.GetComponent<Bullet>().damage;
            }
            fireDelay = ballistaDelay;
        }
    }

    public void CannonUpgradeOne()
    {
        if (gameMaster.money > upgradeTower.specialUpgradeOne)
        {
            towerMsh[1].materials = upgradeOne;
            towerMsh[0].materials = upgradeOne;

            upgradeTower.upgradeOne.interactable = false;
            upgradeTower.upgradeTwo.interactable = false;

            cannonNormal = false;
            cannonUpOne = true;
            gameMaster.money -= upgradeTower.specialUpgradeOne;
        }
    }
    public void CannonUpgradeTwo()
    {
        if (gameMaster.money > upgradeTower.specialUpgradeTwo)
        {
            towerMsh[1].materials = upgradeTwo;
            towerMsh[0].materials = upgradeTwo;

            upgradeTower.upgradeOne.interactable = false;
            upgradeTower.upgradeTwo.interactable = false;

            cannonNormal = false;
            cannonUpTwo = true;
            gameMaster.money -= upgradeTower.specialUpgradeTwo;
        }
    }

    public void LightingUpgrade()
    {
        if (gameMaster.money > upgradeTower.specialUpgradeOne)
        {
            useLightning = true;
            useNormal = false;

            lightingFX.SetActive(true);

            towerMsh[1].material = upgradeOne[0];
            towerMsh[0].materials = upgradeOne;
            damage += 50;
            upgradeTower.upgradeOne.interactable = false;
            upgradeTower.upgradeTwo.interactable = false;

            gameMaster.money -= upgradeTower.specialUpgradeOne;
            return;
        }
    }
    public void FireUpgrade()
    {
        if (gameMaster.money > upgradeTower.specialUpgradeTwo)
        {
            useFire = true;
            useNormal = false;

            fireRotation.SetActive(true);

            towerMsh[1].material = upgradeTwo[0];
            towerMsh[0].materials = upgradeTwo;

            upgradeTower.upgradeOne.interactable = false;
            upgradeTower.upgradeTwo.interactable = false;

            gameMaster.money -= upgradeTower.specialUpgradeTwo;
            return;
        }
    }

    public void BallistaUpgradeOne()
    {
        if (gameMaster.money > upgradeTower.specialUpgradeOne)
        {
            towerMsh[1].materials = upgradeOne;
            towerMsh[0].materials = upgradeOne;

            upgradeTower.upgradeOne.interactable = false;
            upgradeTower.upgradeTwo.interactable = false;

          arrowUpgradeOne.GetComponent<Bullet>().damage = 150;
            arrowUpgradeOne.GetComponent<Bullet>().iceUpgrade = true;
            ballistaDelay = 5;

            ballistaNormal = false;
            ballistaUpgradeOne = true;
            gameMaster.money -= upgradeTower.specialUpgradeOne;
        }
    }
    public void BallistaUpgradeTwo()
    {
        if (gameMaster.money > upgradeTower.specialUpgradeOne)
        {
            towerMsh[1].materials = upgradeTwo;
            towerMsh[0].materials = upgradeTwo;

            upgradeTower.upgradeOne.interactable = false;
            upgradeTower.upgradeTwo.interactable = false;

           arrowUpgradeTwo.GetComponent<Bullet>().damage = 50;
            ballistaDelay = 0.5f;

            ballistaNormal = false;
            ballistaUpgradeTwo = true;
            gameMaster.money -= upgradeTower.specialUpgradeTwo;
        }
    }

    public void FlameUpgradeOne()
    {
        if (gameMaster.money > upgradeTower.specialUpgradeOne)
        {
            towerMsh[1].materials = upgradeOne;
            towerMsh[0].materials = upgradeOne;

            upgradeTower.upgradeOne.interactable = false;
            upgradeTower.upgradeTwo.interactable = false;
        }
    }
    public void FlameUpgradeTwo()
    {
        if (gameMaster.money > upgradeTower.specialUpgradeTwo)
        {
            towerMsh[1].materials = upgradeTwo;
            towerMsh[0].materials = upgradeTwo;

            upgradeTower.upgradeOne.interactable = false;
            upgradeTower.upgradeTwo.interactable = false;

        }
    }
}
