using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] uint speed = 20;
	[SerializeField] uint turnSpeed = 30;
	float horizontalInput;
	float verticalInput;

	// Update is called once per frame
	void FixedUpdate()
	{
		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
		transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

		if (transform.position.y < -10f)
		{
			transform.position = Vector3.up * 2f;
			transform.rotation = new Quaternion();
		}
	}
}