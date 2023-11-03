using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private List<GameObject> elementalSpawnLocations;
    [SerializeField] private List<GameObject> coreSpawnLocations;
    public int coreCount; //public so gameplay can access it
    private int location;
    // Start is called before the first frame update
    void Start()
    {
        coreCount = 0;
        location = 0;
        InvokeRepeating("SpawnWaterOrFireElemental", 0.0f, 2.0f); //these values can change
        InvokeRepeating("SpawnWaterOrFireCore", 5.0f, 5.0f);  //only spawns 5 cores, will need a rework so cores dont spawn in same spot when spawning more than 5 locations

    }

    private void SpawnWaterOrFireElemental() //trigger sound effect when new elemental spawns nearby?
    {
        //chooses between fire or water, calls the appropriate method
        int eleSwap = Random.Range(1, 3); //RR int is not maximally inclusive so range must be 1-3
        int location = Random.Range(0, elementalSpawnLocations.Count);
        if (eleSwap == 1) //fire elementals
        {
            GameObject fireEle = ObjectPooler.sharedInstance.GetPooledFireElementals();
            if (fireEle != null)
            {
                fireEle.transform.position = elementalSpawnLocations[location].transform.position;
                fireEle.SetActive(true);
            }
        }
        else if (eleSwap == 2)//water elementals
        {
            GameObject waterEle = ObjectPooler.sharedInstance.GetPooledWaterElementals();
            if (waterEle != null)
            {
                print("water elemental spawned");
                waterEle.transform.position = elementalSpawnLocations[location].transform.position;
                waterEle.SetActive(true);
            }
        }
    }

    private void SpawnWaterOrFireCore() //trigger sound effect when core spawns?
    {
        print("spawned core");
        int coreSwap = Random.Range(1, 3); //RR int is not maximally inclusive so range must be 1-3
        if(coreSwap == 1) //fire cores
        {
            GameObject fireCore = ObjectPooler.sharedInstance.GetPooledFireCores();
            if (fireCore != null && coreCount <= 5)
            {
                fireCore.transform.position = coreSpawnLocations[location].transform.position;
                fireCore.SetActive(true);
                //coreSpawnLocations.RemoveAt(location);
                location++;
                coreCount++;
            }
            else
            {
                return;
            }
        }
        else if (coreSwap == 2)//water cores
        {
            GameObject waterCore = ObjectPooler.sharedInstance.GetPooledWaterCores();
            if (waterCore != null && coreCount <= 5)
            {
                waterCore.transform.position = coreSpawnLocations[location].transform.position;
                waterCore.SetActive(true);
                //coreSpawnLocations.RemoveAt(location);
                location++;
                coreCount++;
            }
            else
            {
                return;
            }
        }
    }
}
