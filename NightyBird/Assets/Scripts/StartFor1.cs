using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFor1 : MonoBehaviour
{

    private void Awake()
    {
        GameControl.instance.isStarted = true;
        PlayerPrefs.SetInt("MP_Scene", 1);
    }
}
