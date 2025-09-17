using UnityEngine;
using UnityEngine.SceneManagement;   

public class MoveToPoint : MonoBehaviour
{
    public Transform targetPoint;   
    public float speed = 3f;        
    
   // public SceneFader fader;
      

    void Update()
    {
        if (targetPoint != null)
        {
            
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPoint.position,
                speed * Time.deltaTime
            );

            
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.05f)
            {

                //fader.FadeToScene("FireScene");

                SceneManager.LoadScene("FireScene");

            }
        }
    }
}
