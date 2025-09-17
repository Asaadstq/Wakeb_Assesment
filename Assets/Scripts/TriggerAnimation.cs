using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;

    public void PlayYelling()
    {
        StartCoroutine(StartAndStopYelling());
    }

    private System.Collections.IEnumerator StartAndStopYelling()
    {
        animator.SetBool("Yelling", true);

        // Wait until the animation length (replace "YellingAnimation" with your animation state name)
        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animLength);

        animator.SetBool("Yelling", false);
    }

    public void Running()
    {
        animator.SetBool("Running", true);
    }
}
