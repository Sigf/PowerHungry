using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour {

    private SpeedManagerBehavior sManager;
    private SpriteRenderer rend;

    public float  scrollSpeed;

	// Use this for initialization
	void Start () {
        sManager = SpeedManagerBehavior.instance;
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * sManager.GetCharge() * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector3(offset, 0));

	}
}
