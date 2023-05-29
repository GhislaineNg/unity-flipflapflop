using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public GameObject Template;
    public GameObject TemplateEmpty;
    public GameObject SpawnReserver;
    public sparrowPlayer Player;
    private float DistanceTravelled = 0;

    private void Start()
    {
        GameObject Spawned = Instantiate(TemplateEmpty, SpawnReserver.transform);
        Spawned.transform.parent = transform;

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
    }

    public void Update()
    {
        if (Player.start == true)
        {
            if (Player.lose == false)
            {
                transform.position += new Vector3(-3 * Time.deltaTime, 0, 0);
                // Debug.Log("positionx: " + transform.position.x + " .... distance: " + DistanceTravelled);
                // Debug.Log(transform.position.x - DistanceTravelled);
                if (Math.Abs(transform.position.x) - Math.Abs(DistanceTravelled) >= 6.8)

                {
                    DistanceTravelled = transform.position.x;
                    GameObject Spawned = Instantiate(Template, SpawnReserver.transform);
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