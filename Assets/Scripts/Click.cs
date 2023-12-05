using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    private AudioSource mouseSource;
    private AudioSource keyboardSource;
    private Light power;
    private float time = 0.0f;
    private bool isTurned = false;
    void Start()
    {
        mouseSource = GameObject.Find("mouse").GetComponent<AudioSource>();
        keyboardSource = GameObject.Find("keyboard").GetComponent<AudioSource>();
        power = GameObject.Find("powerbutton").GetComponent<Light>();
        
    }
    void Update()
    {
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
                    isTurned = true;
                }
                
                if (hit.collider.gameObject.name == "keyboard")
                {
                    keyboardSource.Play();
                    isTurned = true;
                }
            }
        }
        
        if (isTurned)
        {
            power.enabled = true;
            time += Time.deltaTime;

            if (time > 1.0f)
            {
                isTurned = false;
                power.enabled = false;
                time = 0.0f;
            }
            
        }
    }
}

