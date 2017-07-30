using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour {

    private SpeedManagerBehavior sManager;
    public float SpeedWeight = 40;
    private float CurrentScore = 0;
    private Text ScoreImage;

	// Use this for initialization
	void Start () {
        sManager = SpeedManagerBehavior.instance;
        ScoreImage = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnGUI()
    {
        CurrentScore += (Time.deltaTime * sManager.GetCharge() * SpeedWeight);
        ScoreImage.text = "Score " + (int)CurrentScore;
    }
}
