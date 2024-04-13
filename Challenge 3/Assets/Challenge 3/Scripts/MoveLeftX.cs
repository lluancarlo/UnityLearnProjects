﻿using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
	public float speed;
	private PlayerControllerX playerControllerScript;
	private float leftBound = -10;

	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
	}

	void Update()
	{
		if (!playerControllerScript.gameOver)
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
		}

		if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
		{
			Destroy(gameObject);
		}
	}
}