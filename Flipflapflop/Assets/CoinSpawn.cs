using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ////if (Input.GetKeyDown(KeyCode.Space))
        ////{
        //    Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, 0);
        //    Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        ////}

        gameObject.transform.Rotate(0f, 1f, 1f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, 0);
            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        }
    }
}
