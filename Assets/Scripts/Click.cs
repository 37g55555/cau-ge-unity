using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    private AudioSource mouseSource;
    private AudioSource keyboardSource;
    private Light power;
    private Light monkeyspot;
    private Light robotspot;
    private Light gunspot;
    private Light soccerspot;
    private Light duckspot;
    private Light carspot;
    
    bool isMonkeySpotEnabled = false;
    
    private float time = 0.0f;
    private float spottime = 0.0f;
    private bool isTurned = false;
    private int isClicked = 0;
    private bool isSpotlight = false;
    void Start()
    {
        mouseSource = GameObject.Find("mouse").GetComponent<AudioSource>();
        keyboardSource = GameObject.Find("keyboard").GetComponent<AudioSource>();
        power = GameObject.Find("powerbutton").GetComponent<Light>();
        
        monkeyspot = GameObject.Find("monkeySpot").GetComponent<Light>();
        robotspot = GameObject.Find("robotSpot").GetComponent<Light>();
        gunspot = GameObject.Find("gunSpot").GetComponent<Light>();
        soccerspot = GameObject.Find("soccerSpot").GetComponent<Light>();
        duckspot = GameObject.Find("duckSpot").GetComponent<Light>();
        carspot = GameObject.Find("carSpot").GetComponent<Light>();
        
    }

    void click()
    {
        power.enabled = true;
        Invoke("point", 1.0f);
        isClicked += 1;
        
        if (isClicked == 5)
        {
            int randomValue = Random.Range(0, 6);
            Debug.Log(randomValue);

            if (randomValue == 0)
            {
                monkeyspot.enabled = true;
                Invoke("monkey", 1.5f);
            }
            else if (randomValue == 1)
            {
                robotspot.enabled = true;
                Invoke("robot", 1.5f);
            }
            else if (randomValue == 2)
            {
                gunspot.enabled = true;
                Invoke("gun", 1.5f);
            }
            else if (randomValue == 3)
            {
                soccerspot.enabled = true;
                Invoke("soccer", 1.5f);
            }
            else if (randomValue == 4)
            {
                duckspot.enabled = true;
                Invoke("duck", 1.5f);
            }
            else
            {
                carspot.enabled = true;
                Invoke("car", 1.5f);
            }

            isClicked = 0;
        }
    }

    void point()
    {
        power.enabled = false;
    }
    void monkey()
    {
        monkeyspot.enabled = false;
    }
    void robot()
    {
        robotspot.enabled = false;
    }
    void gun()
    {
        gunspot.enabled = false;
    }
    void soccer()
    {
        soccerspot.enabled = false;
    }
    void duck()
    {
        duckspot.enabled = false;
    }
    void car()
    {
        carspot.enabled = false;
    }
    
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
        {
            Debug.Log("!keyboard");
            keyboardSource.Play();
            click();
        }
        
        if (Input.GetMouseButtonDown(0)) //왜 OnMouseDown은 안됨?
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                
                if (hit.collider.gameObject.name == "car")
                {
                    SceneManager.LoadScene("Car");
                }
                
                if (hit.collider.gameObject.name == "duck")
                {
                    SceneManager.LoadScene("Duck");
                }
                
                if (hit.collider.gameObject.name == "soccerball")
                {
                    SceneManager.LoadScene("Soccerball");
                }
                
                if (hit.collider.gameObject.name == "gun")
                {
                    SceneManager.LoadScene("Gun");
                }
                
                if (hit.collider.gameObject.name == "robot")
                {
                    SceneManager.LoadScene("Robot");
                }
                
                if (hit.collider.gameObject.name == "monkey")
                {
                    SceneManager.LoadScene("Monkey");
                }

                if (hit.collider.gameObject.name == "mouse")
                {
                    mouseSource.Play();
                    click();
                }
                
                if (hit.collider.gameObject.name == "keyboard")
                {
                    keyboardSource.Play();
                    click();
                }
            }
        }
    }
}

