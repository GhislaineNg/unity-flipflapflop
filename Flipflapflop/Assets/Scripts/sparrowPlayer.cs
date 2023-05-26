using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparrowPlayer : MonoBehaviour
{

    private Vector3 direction;
    public float gravity = -9.8f; //can determine the difficulty of the game
    public float strength = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get bird to fly with space bar or left click
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;

        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
}
