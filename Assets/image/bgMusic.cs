using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusic : MonoBehaviour
{
    private static bgMusic bagMusic;

    void Awake()
    {
        if(bagMusic == null)
        {
            bagMusic = this;
            DontDestroyOnLoad(bagMusic);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
