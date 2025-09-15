using UnityEngine;

public class DebugParticleCollision : MonoBehaviour
{
    public GameObject gameObject;
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle hit from: " + other.name);
        gameObject.SetActive(false);
    }

    
}
