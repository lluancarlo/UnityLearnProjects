using UnityEngine;

public class MoveBetweenPositions : MonoBehaviour
{
	public float Speed;
	public Vector3 EndPosition;
	private Vector3 StartPosition;
	private Vector3 TargetPosition;

	// Start is called before the first frame update
	void Start()
	{
		StartPosition = transform.position;
		TargetPosition = EndPosition;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
		if (Vector3.Distance(transform.position, TargetPosition) < 0.001f)
			TargetPosition = TargetPosition == StartPosition ? EndPosition : StartPosition;
	}
}