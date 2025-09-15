using UnityEngine;

public class FlameExtinguish : MonoBehaviour
{
    [Header("References")]
    public ParticleSystem flame;      // assign your flames ParticleSystem here

    [Header("Extinguish Tuning")]
    public float extinguishPerHit = 5f;   // how much to reduce emission per collision
    public float smooth = 10f;            // how fast the visual change lerps

    float baseRate;       // initial emission rate
    float targetRate;     // where we’re trying to get to

    void Awake()
    {
        if (flame == null) flame = GetComponentInChildren<ParticleSystem>();
        var em = flame.emission;
        baseRate   = em.rateOverTime.constant;  // store starting value
        targetRate = baseRate;
    }

    // This is called when WATER particles hit the FlameZone collider
    void OnParticleCollision(GameObject other)
    {
        
        // If you tagged the water object as "Water", keep this check.
        if (other.CompareTag("Water") || true) // remove the || true if you rely on the tag
        {
            Debug.Log("Particle hit from Asaad : " + other.name);
            targetRate = Mathf.Max(0f, targetRate - extinguishPerHit);
        }
    }

    void Update()
    {
        if (flame == null) return;

        var em = flame.emission;
        // current constant value
        float current = em.rateOverTime.constant;
        // move smoothly toward the lowered target
        float next = Mathf.MoveTowards(current, targetRate, smooth * Time.deltaTime);

        // write back the MinMaxCurve with a new constant
        var curve = em.rateOverTime;
        curve.constant = next;
        em.rateOverTime = curve;

        // stop when fully extinguished
        if (next <= 0.01f && flame.isEmitting)
            flame.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}
