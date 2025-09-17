using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTrigger : MonoBehaviour
{
    

    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))   
        {
           
            SceneManager.LoadScene("DrivingScene");
        }
        
        
    }
}
