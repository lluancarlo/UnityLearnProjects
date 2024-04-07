using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject projectilePrefab;
	public float speed = 10f;
	public float leftBoundary = -10f;
	public float rightBoundary = 10f;
	private float horizontalInput;

	// Update is called once per frame
	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
		
		if (transform.position.x < leftBoundary)
			transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
		else if (transform.position.x > rightBoundary)
			transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);

		if (Input.GetKeyDown(KeyCode.Space))
			Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
	}
}