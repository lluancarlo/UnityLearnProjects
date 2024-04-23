using System;
using System.IO;
using UnityEngine;

[Serializable]
public class Player
{
	public string Name;
	public int Score;

	public Player Copy() => (Player)this.MemberwiseClone();
}

public class PersistenceData : MonoBehaviour
{
	public static PersistenceData instance;
	public Player currentPlayer = new();
	public Player bestScorePlayer = new();
	string savePath;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
		instance.savePath = Application.persistentDataPath + "/savefile.json";
		DontDestroyOnLoad(gameObject);
	}

	public void SaveBestScore()
	{
		var data = instance.bestScorePlayer.Copy();
		var json = JsonUtility.ToJson(data);
		File.WriteAllText(instance.savePath, json);
	}

	public void LoadBestScore()
	{
		if (!File.Exists(instance.savePath))
			return;

		var json = File.ReadAllText(instance.savePath);
		var data = JsonUtility.FromJson<Player>(json);
		instance.bestScorePlayer = data;
	}
}
