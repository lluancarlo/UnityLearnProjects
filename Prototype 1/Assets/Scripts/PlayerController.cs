using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public uint speed = 20;
	public uint turnSpeed = 30;
	private float horizontalInput;
	private float verticalInput;

	// Update is called once per frame
	void Update()
	{
		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
		transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
	}
}