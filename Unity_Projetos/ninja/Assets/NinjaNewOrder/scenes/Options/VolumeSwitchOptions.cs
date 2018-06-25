using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSwitchOptions : MonoBehaviour {
    [SerializeField] VerticalSelection vertical;
    public float volume;
    public GameConfiguration gm;
    // Use this for initialization
	void Start () {
        gm.LoadConfiguration();
        int soundVolume = (int) ( GameConfiguration.gameData.volume * 10); 
        Debug.Log(soundVolume);
        vertical.actualId = soundVolume;


    }
	
	// Update is called once per frame
	void Update () {
        if (vertical.Active) { 
            volume = vertical.actualId /10f;
            volume = Mathf.Clamp(volume, 0, 1);

            if (GameConfiguration.gameData.volume != volume) {
                GameConfiguration.gameData.volume = volume;
                gm.SaveConfiguration();
            }
        }

    }
}
