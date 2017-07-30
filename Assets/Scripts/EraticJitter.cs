using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraticJitter : MonoBehaviour {


    private RectTransform textTransform;
    private Vector3 StartPosition;

    private SpeedManagerBehavior sManager;
    public float JitterIntensity = 10;

	// Use this for initialization
	void Start () {
        textTransform = GetComponent<RectTransform>();
        StartPosition = textTransform.position;
        sManager = SpeedManagerBehavior.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {

        float charge = sManager.GetCharge();

        Vector3 RandomOffset = new Vector3(Random.Range(-JitterIntensity * charge, JitterIntensity * charge), Random.Range(-JitterIntensity * charge, JitterIntensity * charge), 0.0f);
        textTransform.position = StartPosition + RandomOffset;
    }
}
