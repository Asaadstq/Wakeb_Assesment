using System.Collections.Generic;
using UnityEngine;

public class FireGroupExtinguish : MonoBehaviour
{
    [Tooltip("If left empty, all child ParticleSystems will be controlled.")]
    public ParticleSystem[] flameSystems;

    [Header("Extinguish Tuning")]
    public float extinguishPerHit = 5f;   // emission units per hit
    public float smooth = 10f;            // how fast to lerp to target

    // per-system state
    Dictionary<ParticleSystem, float> baseRate = new();
    Dictionary<ParticleSystem, float> targetRate = new();

    void Awake()
    {
        if (flameSystems == null || flameSystems.Length == 0)
            flameSystems = GetComponentsInChildren<ParticleSystem>(includeInactive: true);

        foreach (var ps in flameSystems)
        {
            var em = ps.emission;
            float start = em.rateOverTime.constant;
            baseRate[ps] = start;
            targetRate[ps] = start;
        }
    }

    // Called by the water when it collides with any collider on this fire object
    public void ApplyHit(float amount)
    {
        foreach (var ps in flameSystems)
        {
            targetRate[ps] = Mathf.Max(0f, targetRate[ps] - amount);
        }
    }

    void Update()
    {
        foreach (var ps in flameSystems)
        {
            var em = ps.emission;

            float current = em.rateOverTime.constant;
            float next = Mathf.MoveTowards(current, targetRate[ps], smooth * Time.deltaTime);

            var curve = em.rateOverTime;
            curve.constant = next;
            em.rateOverTime = curve;

            if (next <= 0.01f && ps.isEmitting)
                ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    // Optional: reset to original intensity (for debugging / gameplay)
    public void ResetFire()
    {
        foreach (var ps in flameSystems)
        {
            targetRate[ps] = baseRate[ps];

            var em = ps.emission;
            var c = em.rateOverTime;
            c.constant = baseRate[ps];
            em.rateOverTime = c;

            if (!ps.isPlaying) ps.Play();
        }
    }
}
