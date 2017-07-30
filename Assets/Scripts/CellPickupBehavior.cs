using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPickupBehavior : MonoBehaviour {

    public float bobbingSpeed = 2;
    public float bobbingHeight = 1;

    private SpeedManagerBehavior sManager;
    private Vector3 StartingPosition;

	// Use this for initialization
	void Start () {
        StartingPosition = gameObject.transform.position;
        sManager = SpeedManagerBehavior.instance;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 bobbingPosition = new Vector3(0.0f, Mathf.Sin(Time.realtimeSinceStartup * bobbingSpeed) * bobbingHeight, 0.0f);
        gameObject.transform.localPosition = bobbingPosition;
    }

    public void Use()
    {
        sManager.UseCell();
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
