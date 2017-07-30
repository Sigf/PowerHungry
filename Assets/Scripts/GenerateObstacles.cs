using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour {

    public List<GameObject> Obstacles;
    public float MaxRespawnTime = 2.0f;
    public float MinRespawnTime = 0.8f;

    private bool CanSpawn;
    private float SpawnTimer;

	// Use this for initialization
	void Start () {
        CanSpawn = true;
        SpawnTimer = MaxRespawnTime;
	}
	
	// Update is called once per frame
	void Update () {
        if(CanSpawn)
        {
            SpawnTimer -= Time.deltaTime;
            if(SpawnTimer <= 0.0f)
            {
                SpawnObstacle();
                ResetTimer();
            }
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        CanSpawn = false;
        SpawnTimer = MaxRespawnTime;
        Debug.Log("OnTriggerStay");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanSpawn = true;
        Debug.Log("OnTriggerExit");
    }

    void ResetTimer()
    {
        SpawnTimer = Random.Range(MinRespawnTime, MaxRespawnTime);
    }

    void SpawnObstacle()
    {
        int randIndex = Random.Range(0, Obstacles.Count);
        Instantiate(Obstacles[randIndex], transform);
    }
}
