using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public GameObject player;
	[SerializeField] Vector3 offset = new(0f, 5.5f, -7f);

	// Update is called once per frame
	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
		transform.rotation = player.transform.rotation;
	}
}