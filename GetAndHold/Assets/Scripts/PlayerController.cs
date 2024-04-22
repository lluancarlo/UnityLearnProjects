using UnityEngine;
using UnityEngine.Events;

public class ItemEvent : UnityEvent<string, int>{}

public class PlayerController : MonoBehaviour
{
	public ItemEvent AddItemInBed = new();
	public ItemEvent RemoveItemInBed = new();
	public bool CanControl = true;
	float torque = 7000;
	float horizontalInput;
	Rigidbody rbComponent;

	void Start()
	{
		rbComponent = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (CanControl)
		{
			horizontalInput = Input.GetAxis("Horizontal");
			rbComponent.AddRelativeForce(Vector3.forward * horizontalInput * torque);
		}
	}

	private void OnTriggerEnter(Collider other) =>
		AddItemInBed.Invoke(other.gameObject.tag, 1);

	private void OnTriggerExit(Collider other) =>
		RemoveItemInBed.Invoke(other.gameObject.tag, -1);
}
