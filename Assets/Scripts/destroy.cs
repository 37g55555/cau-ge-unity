using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    private Color originalColor;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(Transparent());
    }

    private IEnumerator Transparent()
    {
        float elapsedTime = 0.0f;
        
        while (elapsedTime < 0.8f)
        {
            float alpha = Mathf.Lerp(originalColor.a, 0.0f, elapsedTime / 0.8f);
            Color currentColor = originalColor;
            currentColor.a = alpha;
            GetComponent<Renderer>().material.color = currentColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        Color finalColor = originalColor;
        finalColor.a = 0.0f;
        GetComponent<Renderer>().material.color = finalColor;
        meshRenderer.enabled = false;
    }
}
