using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public GameObject gameScreen;
	public GameObject finishedScreen;
	public TextMeshProUGUI boxesValue;
	public TextMeshProUGUI barrelValue;
	public TextMeshProUGUI timeValue;
	public TextMeshProUGUI totalValue;

	private void Start()
	{
		SetBoxesValue(0);
		SetBarrelValue(0);
	}

	public void SetBoxesValue(int value) => boxesValue.text = value.ToString();
	public void SetBarrelValue(int value) => barrelValue.text = value.ToString();
	public void SetTimeValue(int value) => timeValue.text = value.ToString();

	public void ShowFinishedGameUI(int total)
	{
		gameScreen.SetActive(false);
		finishedScreen.SetActive(true);
		totalValue.text = total.ToString();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
