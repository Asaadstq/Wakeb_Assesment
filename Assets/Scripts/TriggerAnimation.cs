using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;

    public void StartYelling()
    {
        animator.SetBool("StartYelling", true);
    }

    public void StopYelling()
    {
        animator.SetBool("StartYelling", false);
    }
}
