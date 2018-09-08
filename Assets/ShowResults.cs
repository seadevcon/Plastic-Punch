using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowResults : MonoBehaviour {

    private int cups;
    private int i = 0;
    private float interval = 0.1f;
    private bool finished = false;
    public GameObject image;
    public Text infoText;
    // Use this for initialization
    void Start()
    {
        string[] infos = new string[]{
            "Around 70% of the Earth’s surface is covered by oceans.",
            "The largest ocean on Earth is the Pacific Ocean, covering around 30% of the Earth’s surface.",
            "The name “Pacific Ocean” comes form the Latin name Tepre Pacificum, “peaceful sea”.",
            "The deepest known area of the Earth’s oceans is known as the Mariana Trench. It’s deepest point measures 11km. That’s a long dive down!",
            "The world’s oceans are home to incredible creatures that are masters of disguise!",
            "The longest mountain range in the world is found under water. Stretching over 56,000km, the Mid-Oceanic Ridge is a mountain chain that runs along the centre of the ocean basins.",
            "About 70% of the oxygen we breathe is produced by the oceans.",
            "The sea is home to the world’s largest living structure – the Great Barrier Reef. Measuring around 2,600km, it can even be seen from the Moon!",
            "We have only explored about 5% of the world’s oceans. There’s a lot more to be discovered!",
            "The sea can be described as the planet’s mega museum. There are more artefacts and remnants of history in the ocean than in all of the world’s museums combined!" };
        int InfoRand = Random.Range(0, 10);
        infoText.text = infos[InfoRand];
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
                SceneManager.LoadScene("Info");
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
