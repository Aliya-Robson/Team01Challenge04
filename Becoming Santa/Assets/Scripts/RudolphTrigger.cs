using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudolphTrigger : MonoBehaviour
{
    public AudioSource finalSound;
    public AudioSource finalSong;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            finalSound.Play();
            finalSong.Play();
                
        }
    }
}
