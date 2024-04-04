using UnityEngine;

public class AnimatePropeller : MonoBehaviour
{
	public float speed = 80f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed);
    }
}
