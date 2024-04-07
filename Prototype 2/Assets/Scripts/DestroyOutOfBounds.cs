using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
	public bool useNegativeBound;
	public float yBound = 30f;

	// Update is called once per frame
	void Update()
	{
		if (useNegativeBound && transform.position.z < -yBound || !useNegativeBound && transform.position.z > yBound)
			Destroy(gameObject);
	}
}