using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

	public void restart()
    {
        PlayerPrefs.SetInt("killedTrash", 0);
        SceneManager.LoadScene("Game");
    }
}
