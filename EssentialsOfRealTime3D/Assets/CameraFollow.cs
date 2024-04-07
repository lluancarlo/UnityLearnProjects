using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject objectToFollow;
	public Vector3 offset;

	// Update is called once per frame
	void FixedUpdate()
	{
		if (objectToFollow != null)
			transform.position = objectToFollow.transform.position + offset;
	}
}