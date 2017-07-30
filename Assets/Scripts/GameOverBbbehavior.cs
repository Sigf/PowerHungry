using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverBbbehavior : MonoBehaviour {

    private GameManagerBehavior gManager;
    private Text text;


	// Use this for initialization
	void Start () {
        gManager = GameManagerBehavior.instance;
        text = GetComponent<Text>();
	}

    private void OnGUI()
    {
        if(gManager.CurrentState == GameManagerBehavior.GameState.GameOver)
        {
            text.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        }
        
        if(gManager.CurrentState == GameManagerBehavior.GameState.Playing)
        {
            text.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
