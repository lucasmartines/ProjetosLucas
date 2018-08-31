using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeBar : MonoBehaviour {
    public Slider slider;


    [SerializeField]CharacterData playerData;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float Life;
        if (playerData == null)
        {
            Life = 0;
            Debug.Log("Player Data is Null");
        }
        else { 
             Life = playerData.Life();
        }
        slider.value = Mathf.Clamp01(Life / 20);
    }
}
