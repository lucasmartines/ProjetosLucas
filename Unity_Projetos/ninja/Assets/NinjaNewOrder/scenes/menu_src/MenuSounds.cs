using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Menu sounds for event clicks or mouse over.
/// </summary>
public class MenuSounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MouseOver(){
		GameObject.FindGameObjectWithTag ("SoundUtility").GetComponent<SoundListUtility> ().PlayElementByName ("selection_menu_option");

	}
	public void MouseClick(){
		GameObject.FindGameObjectWithTag ("SoundUtility").GetComponent<SoundListUtility> ().PlayElementByName ("onclick_menu_sound");

	}
}
