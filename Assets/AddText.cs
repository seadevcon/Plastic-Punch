using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddText : MonoBehaviour {
    private int killedTrash = 0;
	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = (PlayerPrefs.GetInt("killedTrash", 0).ToString() + "Plastikteile wurden gesammelt!");
	}
	

}
