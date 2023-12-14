using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private float time = 0.0f;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time > 0.5f)
        {
            meshRenderer.enabled = !meshRenderer.enabled;
            time = 0.0f;
        }
    }
}
