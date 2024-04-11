using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 2);
        transform.localScale = Vector3.one * 1.3f;
        Material material = Renderer.material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 7.0f * Time.deltaTime, 4.0f * Time.deltaTime);
        transform.localScale = Vector3.one * (float)Math.Sin(Time.time) + Vector3.one * 2f;
    }
}
