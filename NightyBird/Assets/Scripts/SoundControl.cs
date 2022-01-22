using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public Animator anim;

    void Awake()
    {
        anim.SetInteger("SoundOn", PlayerPrefs.GetInt("MP_Sound"));       
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("MP_Sound") == 0 && GameControl.instance.gameOver == false)
        {
            GameControl.instance.swingSound.mute = !GameControl.instance.swingSound.mute;
            GameControl.instance.dieSound.mute = !GameControl.instance.dieSound.mute;
            GameControl.instance.scoreSound.mute = !GameControl.instance.scoreSound.mute;
        }
    }
    public void soundOnOff()
    {
        GameControl.instance.swingSound.mute = !GameControl.instance.swingSound.mute;
        GameControl.instance.dieSound.mute = !GameControl.instance.dieSound.mute;
        GameControl.instance.scoreSound.mute = !GameControl.instance.scoreSound.mute;

        if (PlayerPrefs.GetInt("MP_Sound") == 1)
        {
           PlayerPrefs.SetInt("MP_Sound", 0);
            anim.SetInteger("SoundOn", 0);

        }
        else if(PlayerPrefs.GetInt("MP_Sound") == 0)
        {
            PlayerPrefs.SetInt("MP_Sound", 1);
            anim.SetInteger("SoundOn", 1);
            
        }
        
     
    }
}
