using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    public float Speed;

    private SpeedManagerBehavior sManager;

	// Use this for initialization
	void Start () {
        sManager = SpeedManagerBehavior.instance;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.left * Time.deltaTime * Speed * sManager.GetCharge(), Space.World);
	}
}
