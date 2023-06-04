using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawn : MonoBehaviour
{
    public GameObject Tubes;
    public GameObject TemplateEmpty;
    public GameObject SpawnReserver;
    public sparrowPlayer Player;
    private float DistanceTravelled = 0;

    private void Start()
    {
        // float RandomFloat1 = UnityEngine.Random.Range(35f, 40f);

        Tubes.transform.position = new Vector3(Tubes.transform.position.x, 34f, Tubes.transform.position.z);
        Instantiate(Tubes, Tubes.transform);

        /*
        SpawnReserver.transform.position += new Vector3(6.8f, 0, 0);
        GameObject Spawned1 = Instantiate(TemplateEmpty, SpawnReserver.transform);
        Spawned1.transform.parent = transform;

        SpawnReserver.transform.position += new Vector3(6.8f, 0, 0);
        GameObject Spawned2 = Instantiate(TemplateEmpty, SpawnReserver.transform);
        Spawned2.transform.parent = transform;

        SpawnReserver.transform.position += new Vector3(6.8f, 0, 0);
        GameObject Spawned3 = Instantiate(TemplateEmpty, SpawnReserver.transform);
        Spawned3.transform.parent = transform;

        SpawnReserver.transform.position += new Vector3(6.8f, 0, 0);
        GameObject Spawned4 = Instantiate(TemplateEmpty, SpawnReserver.transform);
        Spawned4.transform.parent = transform;
        */
    }



    public void Update()
    {
        if (Player.start == true)
        {
            if (Player.lose == false)
            {
                transform.position += new Vector3(-3 * Time.deltaTime, 0, 0);
                if (Math.Abs(transform.position.x) - Math.Abs(DistanceTravelled) >= 6.8)

                {
                    float RandomX = UnityEngine.Random.Range(34f, 35.5f);
                    // 34 strict minimum!!, maximum can be adjusted depending on camera placement
                    // Debug.Log(RandomX);

                    DistanceTravelled = transform.position.x;
                    Tubes.transform.position = new Vector3(Tubes.transform.position.x, RandomX, Tubes.transform.position.z);

                    GameObject Spawned = Instantiate(Tubes, SpawnReserver.transform);
                    Spawned.transform.parent = transform;
                }
            }
            else
            {
                transform.position += new Vector3(0, 0, 0);
            }
        }
    }
}
