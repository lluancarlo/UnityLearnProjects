using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float SpacePressRate = 0.5f;
    private float lastSpacePress;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Time.time > (lastSpacePress + SpacePressRate) && Input.GetKeyDown(KeyCode.Space))
        {
						lastSpacePress = Time.time;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
