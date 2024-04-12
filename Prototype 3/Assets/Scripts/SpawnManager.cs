using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject[] obstaclesPrefab;
	public float startDelay = 1f;
	public float repeatRate = 2f;
	public Vector3 spawnPosition = new Vector3(30f, 0f, 0f);
	private PlayerController playerControllerScript;
	private int randomObstacle;

	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
		InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
	}

	void SpawnObstacle()
	{
		if (!playerControllerScript.gameOver)
		{
			randomObstacle = Random.Range(0, obstaclesPrefab.Length);
			Instantiate(obstaclesPrefab[randomObstacle], spawnPosition, obstaclesPrefab[randomObstacle].transform.rotation);
		}
	}
}