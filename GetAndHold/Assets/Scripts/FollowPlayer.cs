using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	[SerializeField] Vector3 offset;
	[SerializeField] float xLimit = 40f;
	GameObject player;

	void Start()
	{
		player = GameObject.Find(Player);
	}

	const string Player = nameof(Player);

	void Update()
	{
		if (player.transform.position.x >= -xLimit && player.transform.position.x <= xLimit)
		transform.position = player.transform.position + offset;
	}
}
