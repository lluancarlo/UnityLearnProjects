using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<GameObject> targets;
	public float spawnRate = 2f;

	void Start()
	{
		StartCoroutine(SpawnTargetRoutine());
	}

	void Update()
	{

	}
	
	IEnumerator SpawnTargetRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnRate);
			Instantiate(targets[Random.Range(0, targets.Count)]);
		}
	}
}
