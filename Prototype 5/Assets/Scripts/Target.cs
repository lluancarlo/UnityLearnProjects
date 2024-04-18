using UnityEngine;

public class Target : MonoBehaviour
{
	private Rigidbody rb;
	private GameManager gameManager;
	private float minSpeed = 13f;
	private float maxSpeed = 18f;
	private float maxTorque = 10f;
	private float xRange = 4f;
	private float ySpawnPos = -2f;

	public int score = 1;
	public ParticleSystem particle;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		transform.position = GetRandomPosition();
		rb.AddForce(GetRandomForce(), ForceMode.Impulse);
		rb.AddTorque(GetRandomTorque(), ForceMode.Impulse);
	}
			
	private void OnMouseDown()
	{
		if (gameManager.isGameActive)
		{
			Instantiate(particle, transform.position, particle.transform.rotation);
			Destroy();
			gameManager.UpdateScore(score);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy();
		if (!gameObject.CompareTag("BadTrigger"))
			gameManager.GameOver();
	}

	private void Destroy()
	{
		Destroy(gameObject);
	}

	Vector3 GetRandomPosition() => new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
	Vector3 GetRandomForce() => Vector3.up * Random.Range(minSpeed, maxSpeed);
	Vector3 GetRandomTorque() => new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
}
