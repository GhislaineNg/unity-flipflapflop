using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public Material[] materials;
    Renderer materialRender;
    public sparrowPlayer Player;
    public bool superpowerStatus = false;


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

        if (Player.count != 0 && Player.count % 15 == 0)
        {
            Player.powerupStatus = true;
            materialRender.sharedMaterial = materials[1]; // red
            
        } else
        {
            Player.powerupStatus = false;
            materialRender.sharedMaterial = materials[0]; // yellow
        }

    }

}
