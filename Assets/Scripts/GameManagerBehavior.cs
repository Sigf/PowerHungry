using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour {

    public static GameManagerBehavior instance;

    private SpeedManagerBehavior sManager;

    public enum GameState
    {
        Playing,
        GameOver
    }

    private GameState _CurrentState;

    public GameState CurrentState
    {
        get { return _CurrentState; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        sManager = SpeedManagerBehavior.instance;
        _CurrentState = GameState.Playing;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.R))
        {
            if(_CurrentState == GameState.GameOver)
            {
                RestartGame();
            }
        }
	}

    public void EndGame()
    {
        _CurrentState = GameState.GameOver;
        sManager.Stop();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
