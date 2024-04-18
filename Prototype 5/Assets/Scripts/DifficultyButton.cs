using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
	public int difficulty = 1;

	private Button button;
	private GameManager gameManager;

	void Start()
	{
		button = GetComponent<Button>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		button.onClick.AddListener(SetDifficulty);
	}

	void SetDifficulty()
	{
		gameManager.StartGame(difficulty);
	}
}
