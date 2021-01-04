using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMainMenu : MonoBehaviour
{
    private static DontDestroyMainMenu playerInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }
}
