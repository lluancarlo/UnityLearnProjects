using UnityEngine;

public class DestroyItem : MonoBehaviour
{
	public float delayToDestroy = 2f;

	void Start()
	{
		Destroy(gameObject, delayToDestroy);
	}
}
