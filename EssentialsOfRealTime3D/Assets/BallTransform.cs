using UnityEngine;

public class BallTransform : MonoBehaviour
{
	public float ScaleChange = 0.05f;
	public float yPositionToReset = 0.8f;
	private Vector3 inicialPosition;

	// Start is called before the first frame update
	void Start()
	{
		inicialPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.localScale += Vector3.one * ScaleChange / 10000f;
		if (transform.position.y < yPositionToReset)
		{
			transform.position = inicialPosition;
			transform.localScale = Vector3.one;
		}
	}
}