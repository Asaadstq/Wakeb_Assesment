using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneFader : MonoBehaviour
{
    [Header("Cutscene Frames")]
    public Image[] cutsceneImages;      

    [Header("Timings")]
    public float fadeDuration = 1f;     
    public float displayDuration = 2f;  

    [Header("Next Scene")]
    public string nextSceneName = "FireScene"; 

    void Awake()
    {
        
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

            
            img.gameObject.SetActive(true);
            yield return StartCoroutine(FadeImage(img, 0f, 1f, fadeDuration));

            
            yield return new WaitForSeconds(displayDuration);

            
            yield return StartCoroutine(FadeImage(img, 1f, 0f, fadeDuration));
            img.gameObject.SetActive(false);
        }

        
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
