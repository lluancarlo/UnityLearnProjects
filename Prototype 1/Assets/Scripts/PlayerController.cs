using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] int speed;
	[SerializeField] int rpm;
	[SerializeField] float horsePower = 20000;
	const float turnSpeed = 30;
	float horizontalInput;
	float verticalInput;
	Rigidbody rb;
	
	[SerializeField] GameObject centerOfMass;
	[SerializeField] TextMeshProUGUI speedometerText;
	[SerializeField] TextMeshProUGUI rpmText;

	[SerializeField] List<WheelCollider> allWheels;
  [SerializeField] int wheelsOnGround;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = centerOfMass.transform.position;
		rb.AddRelativeForce(Vector3.forward * horsePower);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");

		if (IsOnGround())
		{
			//transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
			rb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
			transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

			if (transform.position.y < -10f)
			{
				transform.position = Vector3.up * 2f;
				transform.rotation = new Quaternion();
			}

			speed = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f);
			speedometerText.text = $"Speed: {speed} km/h";

			rpm = (speed % 30) * 100;
			rpmText.text = $"RPM: {rpm}";
		}
	}

	bool IsOnGround()
	{
		wheelsOnGround = 0;
		foreach (WheelCollider wheel in allWheels)
			if (wheel.isGrounded)
				wheelsOnGround++;
		return wheelsOnGround == 4;
	}
}