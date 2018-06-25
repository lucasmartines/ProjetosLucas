using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoVolumeAdjust : MonoBehaviour {

	// Use this for initialization
	void Start () {


        Invoke("soundConfig", 1);
    }
	void soundConfig()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.volume = SoundController.GetVolume();

        }
    }
}
