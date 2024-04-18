using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public List<GameObject> targets;
	public TextMeshProUGUI scoreText;
	public GameObject tileScreen;
	public GameObject gameScreen;
	public GameObject gameOverScreen;

	public bool isGameActive;
	private float spawnRate = 2f;
	private int score;

	private void Start()
	{
		tileScreen.gameObject.SetActive(true);
	}

	IEnumerator SpawnTargetRoutine()
	{
		while (isGameActive)
		{
			yield return new WaitForSeconds(spawnRate);
			Instantiate(targets[Random.Range(0, targets.Count)]);
		}
	}

	public void UpdateScore(int scoreToAdd)
	{
		score += scoreToAdd;
		scoreText.text = $"Score: {score}";
	}

	public void GameOver()
	{
		gameOverScreen.gameObject.SetActive(true);
		isGameActive = false;
	}

	public void RestartGame()
	{
		gameScreen.gameObject.SetActive(false);
		gameOverScreen.gameObject.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void StartGame(int difficulty)
	{
		isGameActive = true;
		score = 0;
		spawnRate /= difficulty;
		gameOverScreen.gameObject.SetActive(false);
		StartCoroutine(SpawnTargetRoutine());
		tileScreen.gameObject.SetActive(false);
		gameScreen.gameObject.SetActive(true);
	}
}
