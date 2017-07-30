using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawnBehavior : MonoBehaviour {

    private SpeedManagerBehavior sManager;
    private GameObject cellPrefab;

    private float RespawnTimer = 1;
    public float heightRange = 10;
    public float minTime = 1.0f;
    public float maxTime = 5.0f;

	// Use this for initialization
	void Start () {
        cellPrefab = Resources.Load("CellPickup") as GameObject;
        sManager = SpeedManagerBehavior.instance;
    }
	
	// Update is called once per frame
	void Update () {
        RespawnTimer -= Time.deltaTime;

        if(RespawnTimer <= 0.0f)
        {
            SpawnCell();
            ResetTimer();
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position + new Vector3(0.0f, heightRange, 0.0f), gameObject.transform.position + new Vector3(0.0f, -heightRange, 0.0f));
    }

    void ResetTimer()
    {
        RespawnTimer = Random.Range(minTime, maxTime);
    }

    void SpawnCell()
    {
        GameObject cell = Instantiate(cellPrefab, gameObject.transform.localPosition + new Vector3(0.0f, Random.Range(-heightRange, heightRange), 0.0f), Quaternion.identity);
    }
}
