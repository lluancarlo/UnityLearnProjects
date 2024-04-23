using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public Button playButton;
	public TextMeshProUGUI bestScoreText;
	public TMP_InputField input;

	private void Start()
	{
		PersistenceData.instance.LoadBestScore();
		bestScoreText.text = 
			$"{PersistenceData.instance.bestScorePlayer.Name} - {PersistenceData.instance.bestScorePlayer.Score}";
	}

	public void CheckInput() =>
		playButton.interactable = input.text.Length > 0;

	public void StartGame()
	{
		PersistenceData.instance.currentPlayer.Name = input.text;
		SceneManager.LoadScene(1);
	}

	public void Exit() =>
		Application.Quit();
}
