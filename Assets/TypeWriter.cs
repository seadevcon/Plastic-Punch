using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour {

    private Text text;
    private string introText =
    "One sunny day in Atlantis...\n\n" +
    "Suddenly everything goes dark.The sun is gone...\n\n" +
    "a brave hero is sent to the surface to investigate\n\n" +
    "this hero is you!";
    private int i = 0;
    private float interval = 0.1f;
    private bool finished = false;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

        StartCoroutine(WriteText());
	}

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!finished)
                interval = 0.01f;
            else
            {
                SceneManager.LoadScene("Game");
            }
        }

    }


    IEnumerator WriteText()
    {
        while (i < introText.Length)
        {
            text.text += introText[i];
            i++;
            yield return new WaitForSeconds(interval);
        }

        finished = true;
    }
}
