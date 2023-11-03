using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstance;
    [SerializeField] private List<GameObject> pooledFireElementals;
    [SerializeField] private List<GameObject> pooledWaterElementals;
    [SerializeField] private List<GameObject> pooledFireCores;
    [SerializeField] private List<GameObject> pooledWaterCores;
    [SerializeField] private GameObject fireElemental;
    [SerializeField] private GameObject waterElemental;
    [SerializeField] private GameObject fireCore;
    [SerializeField] private GameObject waterCore;
    [SerializeField] private int amountToPoolElementals;
    [SerializeField] private int amountToPoolCores;
    // Start is called before the first frame update
    void Start()
    {
        pooledFireCores= new List<GameObject>();
        pooledWaterCores= new List<GameObject>();
        pooledFireElementals= new List<GameObject>();
        pooledWaterElementals= new List<GameObject>();

        for(int fe = 0; fe < amountToPoolElementals; fe++) //pools fire elementals
        {
            GameObject fireEle = Instantiate(fireElemental);
            fireEle.SetActive(false);
            pooledFireElementals.Add(fireEle);
        }
        for (int fc = 0; fc < amountToPoolCores; fc++) //pools fire cores
        {
            GameObject fireCo = Instantiate(fireCore);
            fireCo.SetActive(false);
            pooledFireElementals.Add(fireCo);
        }
        for (int we = 0; we < amountToPoolElementals; we++) //pools water elementals
        {
            GameObject waterEle = Instantiate(waterElemental);
            waterEle.SetActive(false);
            pooledFireElementals.Add(waterEle);
        }
        for (int wc = 0; wc < amountToPoolCores; wc++) //pools water cores
        {
            GameObject waterCo = Instantiate(waterCore);
            waterCo.SetActive(false);
            pooledFireElementals.Add(waterCo);
        }
    }

    void Awake()
    {
        sharedInstance = this;      
    }

    public GameObject GetPooledFireElementals()
    {
        for (int i = 0; i < pooledFireElementals.Count; i++)
        {
            if (!pooledFireElementals[i].activeInHierarchy)
            {
                return pooledFireElementals[i];
            }
        }
        return null;
    }

    public GameObject GetPooledFireCores()
    {
        for (int i = 0; i < pooledFireCores.Count; i++)
        {
            if (!pooledFireCores[i].activeInHierarchy)
            {
                return pooledFireCores[i];
            }
        }
        return null;
    }

    public GameObject GetPooledWaterElementals()
    {
        for (int i = 0; i < pooledWaterElementals.Count; i++)
        {
            if (!pooledWaterElementals[i].activeInHierarchy)
            {
                return pooledWaterElementals[i];
            }
        }
        return null;
    }

    public GameObject GetPooledWaterCores()
    {
        for (int i = 0; i < pooledWaterCores.Count; i++)
        {
            if (!pooledWaterCores[i].activeInHierarchy)
            {
                return pooledWaterCores[i];
            }
        }
        return null;
    }
}
