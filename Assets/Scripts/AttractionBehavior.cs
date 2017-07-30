using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionBehavior : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 FixedPlayerPosition = Player.transform.position;
        FixedPlayerPosition.x = gameObject.transform.position.x;

        Vector3 NewPosition = Vector3.Lerp(gameObject.transform.position, FixedPlayerPosition, Time.deltaTime * 2);
        gameObject.transform.SetPositionAndRotation(NewPosition, Quaternion.identity);
	}
}
