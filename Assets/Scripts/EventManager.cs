using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static EventManager instance = null;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
      
    }

    public void RegisterEvents()
    {
    }

    public void UnregisterEvents()
    { }

}