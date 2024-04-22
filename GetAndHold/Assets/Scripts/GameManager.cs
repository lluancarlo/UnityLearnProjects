using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public PlayerController playerController;
	public UIManager uiManager;
	public SpawnManager spawnManager;
	bool gameFinished;
	int totalTime = 60;
	int barrelsInBed = 0;
	int boxesInBed = 0;

	void Start()
	{
		playerController.AddItemInBed.AddListener(AddItem);
		playerController.RemoveItemInBed.AddListener(RemoveItem);
		StartCoroutine(TimerRoutine());
	}

	IEnumerator TimerRoutine()
	{
		uiManager.SetTimeValue(totalTime);
		while(!gameFinished)
		{
			yield return new WaitForSeconds(1f);
			totalTime--;
			uiManager.SetTimeValue(totalTime);
			if (totalTime == 0)
				FinishGame();
		}
	}

	void FinishGame()
	{
		gameFinished = true;
		playerController.CanControl = false;
		spawnManager.CanSpawn = false;
		uiManager.ShowFinishedGameUI(barrelsInBed + boxesInBed);
	}

	void AddItem(string itemTag, int value)
	{
		UpdateItens(itemTag, value);
	}

	void RemoveItem(string itemTag, int value)
	{
		UpdateItens(itemTag, value);
	}

	void UpdateItens(string itemTag, int value)
	{
		if (itemTag == "Barrel")
		{
			barrelsInBed += value;
			uiManager.SetBarrelValue(barrelsInBed);
		}
		else if (itemTag == "Box")
		{
			boxesInBed += value;
			uiManager.SetBoxesValue(boxesInBed);
		}
	}

	void test() => 
		ScreenCapture.CaptureScreenshot("screenshot.png");
}
