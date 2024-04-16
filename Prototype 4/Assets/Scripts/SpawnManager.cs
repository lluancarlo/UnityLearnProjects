using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public float spawnRangeFromCenter = 9;
	public GameObject enemyPrefab;
	public GameObject powerUpPrefab;
	private int spawnWaveSize;
	private int enemyCount;

	void Start()
	{
		StartNewRound();
	}

	private void Update()
	{
		enemyCount = FindObjectsOfType<Enemy>().Length;
		if (enemyCount == 0)
			StartNewRound();
	}

	public void ResetSpawn()
	{
		spawnWaveSize = 0;
		DestroyAllEnimies();
		DestroyAllPowerUps();
		StartNewRound();
	}

	void DestroyAllEnimies()
	{
		var enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (var enemy in enemies)
			Destroy(enemy);
	}

	void DestroyAllPowerUps()
	{
		var powerUps = GameObject.FindGameObjectsWithTag("PowerUp");
		foreach (var powerUp in powerUps)
			Destroy(powerUp);
	}

	void StartNewRound()
	{
		SpawnEnemyWave(++spawnWaveSize);
		SpawnPowerUp();
	}

	void SpawnEnemyWave(int waveSize)
	{
		for (int i = 0; i < waveSize; i++)
			Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
	}

	void SpawnPowerUp()
	{
		Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
	}

	private Vector3 GenerateSpawnPosition()
	{
		return new Vector3(Random.Range(-spawnRangeFromCenter, spawnRangeFromCenter), 0.25f, Random.Range(-spawnRangeFromCenter, spawnRangeFromCenter));
	}
}
