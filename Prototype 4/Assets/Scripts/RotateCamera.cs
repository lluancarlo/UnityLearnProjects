using UnityEngine;

public class RotateCamera : MonoBehaviour
{
	public float rotateSpeed = 100f;
	public bool invertedAxis;

	void Update()
	{
		var horizontalInput = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime * (invertedAxis ? -1 : 1));
	}
}
