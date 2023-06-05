using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawn : MonoBehaviour
{
    public GameObject Tubes;
    public GameObject SpawnReserver;
    public sparrowPlayer Player;
    private float DistanceTravelled = 0;

    private void Start()
    {
        Tubes.transform.position = new Vector3(Tubes.transform.position.x, 34f, Tubes.transform.position.z);
        Instantiate(Tubes, Tubes.transform);
    }



    public void Update()
    {
        if (Player.start == true)
        {
            if (Player.lose == false)
            {
                transform.position += new Vector3((-3 + (Player.multiplier * -0.5f)) * Time.deltaTime, 0, 0);
                if (Math.Abs(transform.position.x) - Math.Abs(DistanceTravelled) >= 6.8)

                {
                    float RandomX = UnityEngine.Random.Range(35f, 37f);
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
