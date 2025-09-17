using UnityEngine;

public class ParticleWatcher : MonoBehaviour
{
    public ParticleSystem targetParticle;  // The particle system to monitor
    public GameObject objectToActivate;    // The object to activate when emission is 0

    void Update()
    {
        if (targetParticle == null || objectToActivate == null) return;

        var emission = targetParticle.emission;
        float emissionRate = emission.rateOverTime.constant;

        if (emissionRate <= 0f)
        {
            objectToActivate.SetActive(true);
            // Optional: disable this script so it only happens once
            enabled = false;
        }
    }
}
