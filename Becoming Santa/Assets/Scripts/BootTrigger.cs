using UnityEngine;

public class SantaBootTrigger : MonoBehaviour
{
    public SceneFadeController fadeController;
    public string sceneToLoad = "Christmas_Log_Village_Night";
    public AudioSource bootSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (bootSound != null)
                bootSound.Play();
                
            fadeController.FadeToScene(sceneToLoad);
        }
    }
}
