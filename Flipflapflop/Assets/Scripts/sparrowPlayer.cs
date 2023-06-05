using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class sparrowPlayer : MonoBehaviour
{

    private Vector3 direction;
    public float gravity = -9.8f; //can determine the difficulty of the game
    public float strength = 5f;
    public GameObject startTextObject;
    public GameObject againButton;
    //public GameObject sparrow;
    public TextMeshProUGUI countText;
    public GameObject lifeLost;
    public GameObject gameOver;
    public GameObject powerup;
    public GameObject powerupEndWarn;
    public bool lose = false;
    public bool start = false;
    public bool powerupStatus = false;
    public bool powerupCollsion;
    public int multiplier = 1;
    public int count;
    private int elapsedPower = 0;
    private int click = 0;
    private bool powerActivated = false;
    private bool pipeTop = false;
    private Animator animator;
    public GameObject howToPlay;

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

        count = 0;
        multiplier = 1;
        countText.text = "Coins: " + count.ToString();

        startTextObject.SetActive(true);
        againButton.SetActive(false);
        gameOver.SetActive(false);
        lifeLost.SetActive(false);
        howToPlay.SetActive(true);
        powerup.SetActive(false);
        powerupEndWarn.SetActive(false);

        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
    }


    // lose life upon pipe collision
    void loseLife()
    {
        livesRemaining--;
        if (livesRemaining >= 0) 
        {
            lives[livesRemaining].enabled = false; // deactivate a heart image
        }
        if (livesRemaining == 0)
        {
            lose = true;
            start = false;
            gameOver.SetActive(true);
            lifeLost.SetActive(false);
            animator.SetTrigger("Dead");

        }
        else
        {
            isPaused = !isPaused;

        }
    }

    // instant death upon ground collision
    void instantDeath()
    {
        livesRemaining = 0;
        animator.SetTrigger("Dead");
        foreach (Image life in lives)
        {
            life.enabled = false;
        }
        lose = true;
        gameOver.SetActive(true);
        start = false;
    }


    // Update is called once per frame
    void Update()
    {
        //print("powerupStatus = " + powerupStatus + ", powerActivated = " + powerActivated + ", multiplier = " + multiplier + ", elapsedPower = " + elapsedPower);
        if (lose == false)
        {
            animator.SetTrigger("Reset");
            // get bird to fly with space bar or left click
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;
                start = true;
                startTextObject.SetActive(false);
                if (click == 1) {
                    howToPlay.SetActive(false);
                }
                click++;
            }
            if (start == true)
            {
                direction.y += gravity * Time.deltaTime;
                transform.position += direction * Time.deltaTime;
            }
            //if (powerupStatus == true && elapsedPower % 3 != 0)
            //{
            //    powerActivated = true;
            //}
        } else if (lose == true)
        {
            animator.SetTrigger("Dead");
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
    
            lifeLost.SetActive(true);
            //Resume with space bar or left click
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isPaused = !isPaused;
                lifeLost.SetActive(false);
                transform.position = new Vector3(transform.position.x, 3.0f, transform.position.z);
            }
        }
        if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            
            countText.text = "Coins: " + count.ToString();
            if (powerupStatus == true)
            {
                powerActivated = true;
                powerup.SetActive(true);
                multiplier = 1;
            }
            else if (powerupStatus == false && powerActivated == true) 
            {
                elapsedPower++;
            } else
            {
                multiplier++;
            }

            if (elapsedPower % 3 == 2 && elapsedPower != 0 && powerActivated == true && powerupStatus == false)
            {
                powerup.SetActive(false);
                powerupEndWarn.SetActive(true);
            }
            else if (elapsedPower % 3 == 0 && elapsedPower != 0 && powerActivated == true && powerupStatus == false)
            {
                multiplier = count - elapsedPower;
                powerupEndWarn.SetActive(false);
                powerActivated = false;
                powerupStatus = false;
            }


        }

        if (other.gameObject.CompareTag("Pipe"))
        {
            animator.SetTrigger("Dead");
            loseLife();
            if (livesRemaining > 0)
            {
                isPaused = true;
                lose = false;
            } else
            {
                isPaused = false;
                lose = true;
            }
        } else if (other.gameObject.CompareTag("Ground"))
        {
            instantDeath();
        }
    }

    public void Reset()
    {
        //lose = false;
        //start = false;
        //pipeTop = false;


        //startTextObject.SetActive(true);
        //againButton.SetActive(false);
        //gameOver.SetActive(false);
        //animator.SetTrigger("Reset");
        //lifeLost.SetActive(false);
        //transform.position = new Vector3(-6.75f, 2.5f, 0.0f);
        //livesRemaining = 3;
        //foreach (Image life in lives)
        //{
        //    life.enabled = true;
        //}

        //foreach (GameObject collectible in collectibles)
        //{
        //    collectible.SetActive(true);
        //}
        //count = 0;
        //countText.text = "Coins: " + count.ToString();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
