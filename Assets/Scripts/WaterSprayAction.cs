using UnityEngine;
using UnityEngine.InputSystem;   // Input System
using UnityEngine.InputSystem.Utilities; // for IsPressed()

public class WaterSprayAction : MonoBehaviour
{
    [Header("FX")]
    public ParticleSystem waterFX;     // assign your water particle
    public AudioSource sprayAudio;     // optional

    [Header("Input (Action Map)")]
    // Drag an action here (e.g., "Spray") bound to <XRController>{RightHand}/buttonNorth (B)
    public InputActionProperty sprayAction;

    bool spraying;

    void OnEnable()
    {
        if (sprayAction.action != null)
        {
            // Enable in case it comes from a plain InputActionAsset
            sprayAction.action.Enable();
            sprayAction.action.started += OnSprayStarted;   // button down
            sprayAction.action.canceled += OnSprayCanceled;  // button up
        }
        
       /* if (sprayAction.action.IsPressed())
        {
            a1.SetActive(false);
            a2.Play();
        }*/
    }

    void OnDisable()
    {
        if (sprayAction.action != null)
        {
            sprayAction.action.started  -= OnSprayStarted;
            sprayAction.action.canceled -= OnSprayCanceled;
            // Don’t disable if it’s owned by PlayerInput; safe to leave enabled.
        }
        StopSpray();
    }

    void OnSprayStarted(InputAction.CallbackContext _)
    {
        StartSpray();
    }
    void OnSprayCanceled(InputAction.CallbackContext _)
    {
        StopSpray();
    }

    void StartSpray()
    {
        if (spraying) return;
        spraying = true;

        if (waterFX && !waterFX.isEmitting) waterFX.Play(true);
        if (sprayAudio && !sprayAudio.isPlaying) sprayAudio.Play();
    }

    void StopSpray()
    {
        if (!spraying) return;
        spraying = false;

        if (waterFX && waterFX.isEmitting)
            waterFX.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        if (sprayAudio && sprayAudio.isPlaying)
            sprayAudio.Stop();
    }
}
