using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeterBehavior : MonoBehaviour {

    private SpeedManagerBehavior sManager;
    private Image EnergyImage;

	// Use this for initialization
	void Start () {
        EnergyImage = GetComponent<Image>();
        sManager = SpeedManagerBehavior.instance;
    }
	
	// Update is called once per frame
	void Update () {
        EnergyImage.fillAmount = sManager.GetCharge();
	}
}
