using UnityEngine;
using TMPro;

public class CoalCheck : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip firstSound;   // pencil
    public AudioClip secondSound;  // glitter

    private TMP_Text nameText;     
    private int checkCount = 0;

    private void Awake()
    {
        // Automatically find TMP text in the parent NL# object
        nameText = GetComponentInParent<TMP_Text>();

        if (nameText == null)
        {
            // If text isn't directly parented, search all children of the parent row
            nameText = GetComponentInParent<Transform>().GetComponentInChildren<TMP_Text>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        checkCount++;

        if (checkCount == 1)
        {
            if (audioSource && firstSound)
                audioSource.PlayOneShot(firstSound);
        }
        else if (checkCount == 2)
        {
            if (audioSource && secondSound)
                audioSource.PlayOneShot(secondSound);

            // change text to gold
            if (nameText)
                nameText.color = new Color(1f, 0.84f, 0f); // gold

            // stop at 2
            checkCount = 2;
        }
    }
}
