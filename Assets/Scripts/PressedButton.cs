using UnityEngine;
using UnityEngine.InputSystem;

public class PressedButton : MonoBehaviour
{
    public InputActionProperty action;
    public GameObject gameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    // Update is called once per frame
    void Update()
    {
        if (action.action.WasPerformedThisFrame())
        {
            gameObject.SetActive(true);
            //a2.Play();
        }
        
    }
}
