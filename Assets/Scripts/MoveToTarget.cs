using UnityEngine;
using UnityEngine.Events;

public class MoveToTarget : MonoBehaviour
{
    [Header("Movement")]
    public Transform Target;
    public float Speed = 3f;
    public float StopDistance = 0.05f;

    [Header("Animation")]
    public Animator Animator;
    public string RunningParam = "Running";

    [Header("Events")]
    public UnityEvent OnArrived;

    bool _moving;

    // Called by Narrative: assigns/overrides target and starts moving
    public void MoveForward(Transform newTarget)
    {
        if (newTarget != null) Target = newTarget;
        if (Target == null) return;

        _moving = true;
        if (Animator) Animator.SetBool(RunningParam, true);
    }

    void Update()
    {
        if (!_moving || !Target) return;

        // face & move
        Vector3 to = Target.position - transform.position;
        if (to.sqrMagnitude > 0.001f)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(to), 10f * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        // arrived?
        if (Vector3.Distance(transform.position, Target.position) <= StopDistance)
        {
            _moving = false;
            if (Animator) Animator.SetBool(RunningParam, false);
            OnArrived?.Invoke(); // hook next narrative step if you want
        }
    }
}
