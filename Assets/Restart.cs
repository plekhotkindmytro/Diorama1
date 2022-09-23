using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public LevelLoader levelLoader;
    // Start is called before the first frame update
    int triggerCount = 0;
    private float fiveSeconds = 6f;
    public List<GameObject> balls;

    bool canRecordTime = false;
    float idleTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canRecordTime)
        {
            idleTime += Time.deltaTime;
        }

        if (idleTime > fiveSeconds)
        {
            levelLoader.RestartCurrentLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        string collisionName = collision.gameObject.name;
        if (collisionName.StartsWith("Ball"))
        {
            triggerCount++;
        }

        if (triggerCount == balls.Count)
        {
            canRecordTime = true;
        }
    }
}
