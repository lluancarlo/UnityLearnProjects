using UnityEngine;

public class AutoDestroyOffScreen : MonoBehaviour
{
	public float xLimit = -15f;

	void Update()
	{
		if (transform.position.x < xLimit)
			Destroy(gameObject);
	}
}