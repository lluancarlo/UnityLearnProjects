using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 1f;
	private Rigidbody _rb;
	private GameObject target;

	void Start()
	{
		_rb = GetComponent<Rigidbody>();
		target = GameObject.Find(Player);
	}

	private const string Player = nameof(Player);

	void Update()
	{
		 var lookDirection = (target.transform.position - transform.position).normalized;
		_rb.AddForce(lookDirection * speed);
		if (transform.position.y < -10)
			Destroy(gameObject);
	}
}
