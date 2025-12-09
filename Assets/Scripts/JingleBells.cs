using UnityEngine;
using System.Collections;

public class RandomJingleBells : MonoBehaviour
{
    public AudioSource jingleAudio;   // Drag your AudioSource here
    public float minDelay = 5f;
    public float maxDelay = 10f;

    void Start()
    {
        StartCoroutine(JingleRoutine());
    }

    IEnumerator JingleRoutine()
    {
        while (true)
        {
            // Wait a random time between min and max
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            
            // Play the sound
            jingleAudio.Play();
        }
    }
}
