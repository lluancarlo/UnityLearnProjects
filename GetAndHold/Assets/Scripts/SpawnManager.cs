using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public bool CanSpawn = true;
	public GameObject[] itemsPrefab;
	public GameObject mark;
	[SerializeField] float spawnRate = 0.5f;
	[SerializeField] float yPositionToSpawn = 40f;
	[SerializeField] float xPositionLimit = 30;

	void Start()
	{
		StartCoroutine(SpawnItemRoutine());
	}

	IEnumerator SpawnItemRoutine()
	{
		while (CanSpawn)
		{
			yield return new WaitForSeconds(spawnRate);
			GenerateNewItem();
		}
		DestroyAll();
	}

	void GenerateNewItem()
	{
		var index = Random.Range(0, itemsPrefab.Length);
		var RandomPosition = GetNewPosition();
		Instantiate(itemsPrefab[index], RandomPosition, GetNewRotation());
		Instantiate(mark, new Vector3(RandomPosition.x, 0), mark.transform.rotation);
	}

	Vector3 GetNewPosition() => new Vector3(Random.Range(-xPositionLimit, xPositionLimit), yPositionToSpawn, 0f);
	Quaternion GetNewRotation() => new Quaternion(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

	void DestroyAll()
	{
		foreach(var item in GameObject.FindGameObjectsWithTag("Box"))
			Destroy(item);
		foreach(var item in GameObject.FindGameObjectsWithTag("Barrel"))
			Destroy(item);
	}
}
