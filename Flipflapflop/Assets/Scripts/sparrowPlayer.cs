using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class sparrowPlayer : MonoBehaviour
{

    private Vector3 direction;
    public float gravity = -9.8f; //can determine the difficulty of the game
    public float strength = 5f;
    public GameObject startTextObject;
    public GameObject againButton;
    //public GameObject sparrow;
    public TextMeshProUGUI countText;
    public bool lose = false;
    public bool start = false;
    private int count;
    private bool pipeTop = false;
    private Animator animator;

    //livesCount
    public Image[] lives;
    public int livesRemaining;
    public bool isPaused;

    //coins
    private GameObject[] collectibles;


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();

        startTextObject.SetActive(true);
        againButton.SetActive(false);
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        Reset();
        
    }


    // decrement the life count on collision
    void loseLife()
    {
        // decrement the value of livesRemaining
        livesRemaining--;
      
        // remove one of the life images
        if (livesRemaining >= 0)
        {
            lives[livesRemaining].enabled = false;
        }

        if (livesRemaining == 0)
        {
            lose = true;
            
        }
        else
        {
            isPaused = !isPaused;

        }
    }

    void instantDeath()
    {
        livesRemaining = 0;
        foreach (Image life in lives)
        {
            life.enabled = false;
        }
        lose = true;
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
        } else if (lose == true)
        {
            //animator.SetTrigger("Dead");
            againButton.SetActive(true);
            if (pipeTop == false)
            {
                if (transform.position.y > 0)
                {
                    direction.y += gravity * Time.deltaTime;
                    transform.position += direction * Time.deltaTime;
                }
            }
        }
        if (isPaused)
        {
            Time.timeScale = 0;
           // animator.SetTrigger("Dead");
            animator.SetTrigger("Reset");


            //Resume with space bar or left click
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isPaused = !isPaused;
            }
        }
        if (!isPaused)
        {
            animator.SetTrigger("Reset");
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            countText.text = "Count: " + count.ToString();
        } else if (other.gameObject.CompareTag("Pipe"))
        {
            animator.SetTrigger("Dead");
            loseLife();
            isPaused = true;
        } else if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetTrigger("Dead");
            instantDeath();

        }



        //else if(other.gameObject.CompareTag("PipeTop"))
        //{
        //    loseLife();
        //    pipeTop = true;
        //}
        //if (other.gameObject.CompareTag("Pipe") || other.gameObject.CompareTag("Ground"))
        //{
        //    lose = true;
        //    animator.SetTrigger("Dead");
        //}
        //else if (other.gameObject.CompareTag("PipeTop"))
        //{
        //    lose = true;
        //    pipeTop = true;
        //    animator.SetTrigger("Dead");
        //}


    }

    public void Reset()
    {
        lose = false;
        start = false;
        pipeTop = false;
        

        startTextObject.SetActive(true);
        againButton.SetActive(false);
        animator.SetTrigger("Reset");
        transform.position = new Vector3(-6.75f, 2.5f, 0.0f);
        livesRemaining = 3;
        foreach (Image life in lives)
        {
            life.enabled = true;
        }

        foreach (GameObject collectible in collectibles)
        {
            collectible.SetActive(true);
        }
        count = 0;
        countText.text = "Count: " + count.ToString();
    }
    
}
