using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public bool gameOver;
	public float jumpForce = 10f;
	public float gravityModifier = 1.8f;
	public ParticleSystem explosionParticle;
	public ParticleSystem dirtParticle;
	public AudioClip jumpSound;
	public AudioClip crashSound;

	private Rigidbody _rb;
	private Animator _anim;
	private AudioSource _audio;
	private bool isOnAir;

	void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_anim = GetComponent<Animator>();
		_audio = GetComponent<AudioSource>();
		Physics.gravity *= gravityModifier;
	}

	void Update()
	{
		if (!gameOver && !isOnAir && Input.GetKeyDown(KeyCode.Space))
		{
			isOnAir = true;
			_rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			_anim.SetTrigger("Jump_trig");
			_audio.PlayOneShot(jumpSound, 1f);
			dirtParticle.Stop();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag.CompareTo("Ground") == 0)
		{
			isOnAir = false;
			dirtParticle.Play();
		}
		else if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
		{
			gameOver = true;
			_anim.SetBool("Death_b", true);
			_anim.SetInteger("DeathType_int", 1);
			_audio.PlayOneShot(crashSound, 1f);
			dirtParticle.Stop();
			explosionParticle.Play();
		}
	}
}