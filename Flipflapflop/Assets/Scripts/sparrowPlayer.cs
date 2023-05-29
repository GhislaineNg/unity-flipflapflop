using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sparrowPlayer : MonoBehaviour
{

    private Vector3 direction;
    public float gravity = -9.8f; //can determine the difficulty of the game
    public float strength = 5f;
    public GameObject startTextObject;
    public TextMeshProUGUI countText;
    public bool lose = false;
    public bool start = false;
    private int count;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        startTextObject.SetActive(true);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (lose == false)
        {
            // get bird to fly with space bar or left click
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;
                start = true;
                startTextObject.SetActive(false);
            }
            if (start == true)
            {
                direction.y += gravity * Time.deltaTime;
                transform.position += direction * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe") || other.gameObject.CompareTag("Ground"))
        {
            lose = true;
            print("collision");
        }
    }
}
