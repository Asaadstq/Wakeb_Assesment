using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneFader : MonoBehaviour
{
    public Image[] cutsceneImages;     // assign your images in the Inspector
    public float fadeDuration = 1f;    // fade in/out time
    public float displayDuration = 2f; // how long to keep image fully visible
    public string nextSceneName;       // the scene to load after cutscene

    private void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        foreach (Image img in cutsceneImages)
        {
            // Reset transparency
            img.gameObject.SetActive(true);
            Color c = img.color;
            c.a = 0;
            img.color = c;

            // Fade In
            float t = 0;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                c.a = Mathf.Lerp(0, 1, t / fadeDuration);
                img.color = c;
                yield return null;
            }

            // Hold
            yield return new WaitForSeconds(displayDuration);

            // Fade Out
            t = 0;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                c.a = Mathf.Lerp(1, 0, t / fadeDuration);
                img.color = c;
                yield return null;
            }

            img.gameObject.SetActive(false);
        }

        // Load next scene
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
