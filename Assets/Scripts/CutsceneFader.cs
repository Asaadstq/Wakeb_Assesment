using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneFader : MonoBehaviour
{
    [Header("Cutscene Frames")]
    public Image[] cutsceneImages;      // Assign in Inspector (order = display order)

    [Header("Timings")]
    public float fadeDuration = 1f;     // Fade in/out time
    public float displayDuration = 2f;  // Time fully visible

    [Header("Next Scene")]
    public string nextSceneName = "FireScene"; // Must be in Build Settings

    void Awake()
    {
        // Prevent initial flash
        if (cutsceneImages != null)
            foreach (var img in cutsceneImages)
                if (img) { var c = img.color; c.a = 0f; img.color = c; img.gameObject.SetActive(false); }
    }

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        foreach (Image img in cutsceneImages)
        {
            if (!img) continue;

            // Enable & fade in
            img.gameObject.SetActive(true);
            yield return StartCoroutine(FadeImage(img, 0f, 1f, fadeDuration));

            // Hold
            yield return new WaitForSeconds(displayDuration);

            // Fade out & hide
            yield return StartCoroutine(FadeImage(img, 1f, 0f, fadeDuration));
            img.gameObject.SetActive(false);
        }

        // Load next scene directly
        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeImage(Image img, float from, float to, float dur)
    {
        float t = 0f;
        var c = img.color;
        while (t < dur)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(from, to, t / dur);
            img.color = c;
            yield return null;
        }
        c.a = to; img.color = c;
    }
}
