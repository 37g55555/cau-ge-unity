using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Setting : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GameObject.Find("Cube").GetComponent<VideoPlayer>(); 
        videoPlayer.loopPointReached += Finish;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void Finish(VideoPlayer vp)
    {
        SceneManager.LoadScene("First");
    }
}


// if (vp == videoPlayer)
// {
