using UnityEngine;

public class Mark : MonoBehaviour
{
	public float timeToDestroy = 3f;
	Renderer render;

	void Start()
	{
		render = GetComponent<Renderer>();
		Invoke(nameof(AutoDestroy), timeToDestroy);
	}

	void Update()
	{
		render.material.SetColor("_Color", 
			new Color(render.material.color.r, 
			Mathf.Sin(Time.time * 2) + 1f, 
			render.material.color.b));
	}

	void AutoDestroy() => Destroy(gameObject);
}
