using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class LifeStringUI : MonoBehaviour {

   public Text Life;
    // Use this for initialization

    public CharacterData data;

	// Update is called once per frame
	void Update () {
        

        Life.text = Convert.ToString("Life: "+ data.Life());
	}
}
