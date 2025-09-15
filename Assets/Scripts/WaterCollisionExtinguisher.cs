using UnityEngine;

public class WaterCollisionExtinguisher : MonoBehaviour
{
    public float hitStrength = 5f;   // how much to reduce emission per collision call

    void OnParticleCollision(GameObject other)
    {
        // Find a FireGroupExtinguish anywhere up the hierarchy of what we hit
        var fire = other.GetComponentInParent<FireGroupExtinguish>();
        if (fire != null)
        {
            fire.ApplyHit(hitStrength);
            // Debug log so you can see it’s firing
            Debug.Log($"Water hit {other.name} -> extinguish applied");
        }
    }
}
