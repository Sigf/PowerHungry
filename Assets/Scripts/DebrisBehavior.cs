using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisBehavior : MonoBehaviour {

    public List<Sprite> spriteList;

    private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = spriteList[Random.Range(0, spriteList.Count)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
