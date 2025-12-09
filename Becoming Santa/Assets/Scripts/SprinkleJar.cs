using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



public class SprinkleJar : MonoBehaviour
{
    public Transform sprinklePoint;      // where sprinkles spawn
    public GameObject sprinklePrefab;    // small physics sprinkle
    public float spawnRate = 0.05f;      // how fast sprinkles fall
    public float tiltThreshold = 70f;    // degrees tilt needed to pour

    private float timer = 0f;

    private XRGrabInteractable grabObject;

    void Start()
    {
        grabObject = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        // Only sprinkle if the jar is being held
        if (grabObject == null || !grabObject.isSelected)
            return;

        // Check tilt angle
        float tilt = Vector3.Angle(transform.up, Vector3.down); // upside down test

        bool isPouring = tilt > tiltThreshold;

        if (isPouring)
        {
            timer += Time.deltaTime;
            if (timer >= spawnRate)
            {
                SpawnSprinkle();
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }

    void SpawnSprinkle()
    {
        Instantiate(
            sprinklePrefab, 
            sprinklePoint.position, 
            Random.rotation
        );
    }
}