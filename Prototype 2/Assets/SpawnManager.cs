using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public float startDelay = 1f;
	public float spawnInterval = 1.5f;
	public GameObject[] animalPrefabs;
	public Vector3 spawnPosition = new(0f, 0f, 30f);
	public float spawnRangeX = 10f;
	private int index;
	private Vector3 spawnPositionCalculated;

	// Update is called once per frame
	void Start()
	{
		InvokeRepeating(spawnFunction, startDelay, spawnInterval);
	}

	private string spawnFunction = nameof(SpawnRandomAnimal);

	void SpawnRandomAnimal()
	{
		index = Random.Range(0, animalPrefabs.Length);
		spawnPositionCalculated = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, 0f) + spawnPosition;
		Instantiate(animalPrefabs[index], spawnPositionCalculated, animalPrefabs[index].transform.rotation);
	}
}