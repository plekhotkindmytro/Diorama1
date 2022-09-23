using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public LevelLoader LevelLoader;
    public List<GameObject> balls;
  
    private int triggerCount;
    void Start()
    {
        triggerCount = 0;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        string collisionName = collision.gameObject.name;
        if (collisionName.StartsWith("Ball"))
        {
            triggerCount++;
            collision.gameObject.SetActive(false);
        }

        if (triggerCount == balls.Count)
        {
            LevelLoader.LoadNextLevel();
                
            
        }
    }
}
