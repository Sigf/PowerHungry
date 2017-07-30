using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManagerBehavior : MonoBehaviour {

    public static SpeedManagerBehavior instance = null;

    private GameManagerBehavior gManager;

    public float PassiveEnergyLoss = 2.0f;
    public float PowerChargeUse = 0.1f;
    public float CellPower = 0.25f;

    [Range(0.0f, 1.0f)]
    public float StartingCharge = 0.5f;

    private float CurrentCharge;

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
        CurrentCharge = StartingCharge;
        gManager = GameManagerBehavior.instance;
	}
	
	// Update is called once per frame
	void Update () {

        switch(gManager.CurrentState)
        {
            case GameManagerBehavior.GameState.Playing:
                {
                    CurrentCharge -= PassiveEnergyLoss * Time.deltaTime;

                    if (CurrentCharge <= 0.0f)
                    {
                        gManager.EndGame();
                    }

                    break;
                }

            case GameManagerBehavior.GameState.GameOver:
                {
                    break;
                }
        }
	}

    public float GetCharge()
    {
        return CurrentCharge;
    }

    public bool UsePower()
    {
        if(CurrentCharge >= PowerChargeUse)
        {
            CurrentCharge -= PowerChargeUse;
            CurrentCharge = Mathf.Clamp(CurrentCharge, 0.0f, 1.0f);
            return true;
        }
        return false;
    }

    public void UseCell()
    {
        CurrentCharge += CellPower;
        CurrentCharge = Mathf.Clamp(CurrentCharge, 0.0f, 1.0f);
    }

    public void Stop()
    {
        CurrentCharge = 0.0f;
    }
}
