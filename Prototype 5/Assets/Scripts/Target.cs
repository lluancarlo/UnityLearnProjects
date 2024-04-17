using UnityEngine;

public class Target : MonoBehaviour
{
	private Rigidbody rb;
	private float minSpeed = 13f;
	private float maxSpeed = 18f;
	private float maxTorque = 10f;
	private float xRange = 4f;
	private float ySpawnPos = -2f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		transform.position = GetRandomPosition();
		rb.AddForce(GetRandomForce(), ForceMode.Impulse);
		rb.AddTorque(GetRandomTorque(), ForceMode.Impulse);
	}
			
	private void OnMouseDown()
	{
		Destroy();
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy();
	}

	private void Destroy()
	{
		Destroy(gameObject);
	}

	Vector3 GetRandomPosition() => new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
	Vector3 GetRandomForce() => Vector3.up * Random.Range(minSpeed, maxSpeed);
	Vector3 GetRandomTorque() => new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
}
