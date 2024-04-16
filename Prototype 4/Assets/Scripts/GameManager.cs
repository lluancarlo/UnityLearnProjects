using UnityEngine;

public class GameManager : MonoBehaviour
{
	public SpawnManager spawnManager;
	public PlayerController player;

	void Update()
	{
		if (player.transform.position.y < -10)
			ResetGame();
	}

	void ResetGame()
	{
		spawnManager.ResetSpawn();
		player.ResetPlayer();
	}
}
