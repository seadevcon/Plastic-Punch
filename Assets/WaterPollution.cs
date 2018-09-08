using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterPollution : MonoBehaviour {
    public float WaterHealth = 40;
    public Image PollutionBar;
    private float MaxWaterHealth;
	// Use this for initialization
	void Start () {
        MaxWaterHealth = WaterHealth;
        UpdatePollutionBar();
	}
	public void Pollution()
    {
        WaterHealth -= 1;
        UpdatePollutionBar();
    }
    void UpdatePollutionBar()
    {
        PollutionBar.fillAmount = WaterHealth / MaxWaterHealth;
    }

}
