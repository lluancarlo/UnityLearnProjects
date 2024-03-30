using UnityEngine;

public class BallTransform : MonoBehaviour
{
	public float ScaleChange = 0.1f;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		transform.localScale += Vector3.one * ScaleChange / 10000f;
	}
}