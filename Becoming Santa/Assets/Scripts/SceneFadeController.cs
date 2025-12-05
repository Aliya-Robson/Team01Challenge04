using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFadeController : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1.5f; // how long it takes to turn white

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeRoutine(sceneName));
    }

    IEnumerator FadeRoutine(string sceneName)
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        // After fade completes, load next scene
        SceneManager.LoadScene(sceneName);
    }
}
