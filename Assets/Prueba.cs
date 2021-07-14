using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    public GameObject cube;
    public GameObject monito;
    public bool cual = false;

    public static Prueba Instance; 
    private void Awake()
    {
        // I will check if I am the first singletong
        if (Instance == null)
        {
            // ... since i am the one, I declare myself as the one
            Instance = this;

            // ... and I will live forever
            DontDestroyOnLoad(this);

        }
        else
        {
            // I am not the one... I will walk to the eternal darkness
            Destroy(this.gameObject);
        }
    }

    public static void SetParent(Transform valueLocal)
    {
        Instance.transform.SetParent(valueLocal, false);
    }
}
