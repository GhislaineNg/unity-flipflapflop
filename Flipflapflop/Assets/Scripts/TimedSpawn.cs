using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{

    public GameObject spawnee;
    public bool stopSpawn = false;
    public float spawnTime;
    public float spawnDelay;

    public float Radius = 1;
    //Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Vector3 randPos = Random.insideUnitCircle * Radius;
        Instantiate(spawnee, transform.position + randPos, transform.rotation);
        if (stopSpawn)
        {
            CancelInvoke("SpawnObject");
        }
    }
}