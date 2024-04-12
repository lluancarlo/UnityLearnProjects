using UnityEngine;

public class MoveLeft : MonoBehaviour
{
	public float speed = 20f;
	private PlayerController playerControllerScript;

	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	void Update()
	{
		if (!playerControllerScript.gameOver)
			transform.Translate(Vector3.left * Time.deltaTime * speed);
	}
}