using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public Material[] materials;
    Renderer materialRender;
    public sparrowPlayer Player;
    public TubeSpawn tubes;
    public int lastCoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Rotate(0f, 1f, 1f, Space.Self);
        materialRender = GetComponent<Renderer>();
        materialRender.enabled = true;
        materialRender.sharedMaterial = materials[0]; // yellow
    }


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 1f, 1f, Space.Self);

        Debug.Log(Player.count);
        if (Player.count % 5 == 0)
        {
            materialRender.sharedMaterial = materials[1]; // red
        }


        //if (Player.count - lastCoinCount >= 5)

        //{
        //    if (Player.powerupStatus == false)
        //    {
        //        Player.powerupStatus = true;
        //        if (TubeSpawner.tubeCount % 5 == 0)
        //        {
        //            materialRender.sharedMaterial = materials[1]; // red
        //        }
        //    }
        //}

        //if (Player.powerupStatus == false)
        //{
        //    materialRender.sharedMaterial = materials[0]; // yellow

        //}

    }

}
