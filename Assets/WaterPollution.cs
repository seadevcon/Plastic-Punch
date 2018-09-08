using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterPollution : MonoBehaviour {
    public float WaterHealth = 40;
    public Image PollutionBar;
    public int killedTrash = 0;
    private float MaxWaterHealth;

	// Use this for initialization
	void Start () {
        MaxWaterHealth = WaterHealth;
        UpdatePollutionBar();
        PlayerPrefs.SetInt("killedTrash", 0);
	}
	public void Pollution()
    {
        WaterHealth -= 1;
        UpdatePollutionBar();
        if(WaterHealth <= 0)
        {
            SafeKilledTrash();
            SceneManager.LoadScene("Lose");
        }
    }
    void UpdatePollutionBar()
    {
        PollutionBar.fillAmount = WaterHealth / MaxWaterHealth;
    }
    public void Killed()
    {
        killedTrash += 1;
    }
    public void SafeKilledTrash()
    {
        PlayerPrefs.SetInt("killedTrash", killedTrash);

    }
}
