using UnityEngine;

public class ResetPosition : MonoBehaviour
{
	public float zPositionToRestart = 250f;
	private Vector3 startPosition;

	// Start is called before the first frame update
	void Start()
	{
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.z > zPositionToRestart)
			transform.position = startPosition;
	}
}