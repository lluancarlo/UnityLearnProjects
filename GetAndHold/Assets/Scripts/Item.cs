using UnityEngine;

public class Item : MonoBehaviour
{
	public ParticleSystem destroyParticle;
	float YPositionToDestroy = 1f;

	void Update()
	{
		if (transform.position.y < YPositionToDestroy)
		{
			Instantiate(destroyParticle, transform.position, destroyParticle.transform.rotation);
			Destroy(gameObject);
		}
	}
}
