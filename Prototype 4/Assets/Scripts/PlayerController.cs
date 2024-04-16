using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 3f;
	public float powerUpStrength = 15f;
	public float powerUpDuration = 5f;
	public GameObject powerUpIndicator;
	public AudioClip pickUpAudio;
	public AudioClip hitNormalAudio;
	public AudioClip hitPowerUpAudio;

	private Rigidbody _rb;
	private AudioSource _audio;
	private GameObject focalPoint;
	private bool hasPowerUp;
	private Vector3 initialPosition;

	void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_audio = GetComponent<AudioSource>();
		focalPoint = GameObject.Find(FocalPoint);
		initialPosition = transform.position;
	}

	private const string FocalPoint = nameof(FocalPoint);

	void Update()
	{
		var inputVertical = Input.GetAxis("Vertical");
		_rb.AddForce(focalPoint.transform.forward * inputVertical * speed);
		powerUpIndicator.transform.position = transform.position;
	}

	public void ResetPlayer()
	{
		_rb.velocity = Vector3.zero;
		transform.position = initialPosition;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PowerUp"))
		{
			_audio.PlayOneShot(pickUpAudio);
			hasPowerUp = true;
			powerUpIndicator.gameObject.SetActive(true);
			Destroy(other.gameObject);
			StartCoroutine(PowerUpCountDownRoutine());
		}
	}

	IEnumerator PowerUpCountDownRoutine()
	{
		yield return new WaitForSeconds(powerUpDuration);
		hasPowerUp = false;
		powerUpIndicator.gameObject.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			if (hasPowerUp)
			{
				_audio.PlayOneShot(hitPowerUpAudio);
				var enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
				var direction = collision.gameObject.transform.position - transform.position;
				enemyRigidBody.AddForce(direction * powerUpStrength, ForceMode.Impulse);
			}
			else
			{
				_audio.PlayOneShot(hitNormalAudio);
			}
		}
	}
}
