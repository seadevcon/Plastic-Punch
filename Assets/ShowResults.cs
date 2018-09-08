using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowResults : MonoBehaviour {

    private int cups;
    private int i = 0;
    private float interval = 0.1f;
    private bool finished = false;

    public GameObject image;

    // Use this for initialization
    void Start()
    {
        cups = PlayerPrefs.GetInt("killedTrash", 0);
        Debug.Log(cups);
        StartCoroutine(WriteText());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!finished)
                interval = 0.01f;
            else
            {
                SceneManager.LoadScene("Game");
            }
        }

    }


    IEnumerator WriteText()
    {
        while (i < cups)
        {
            Instantiate(image, Vector3.zero, Quaternion.identity, transform);
            i++;
            yield return new WaitForSeconds(interval);
        }

        finished = true;
    }
}
