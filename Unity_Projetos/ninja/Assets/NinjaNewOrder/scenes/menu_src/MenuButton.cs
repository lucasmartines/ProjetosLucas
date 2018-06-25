using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu button Controller.
/// </summary>
public class MenuButton : MonoBehaviour {

	[SerializeField]
	GameObject activeSprite;
	[SerializeField]
	GameObject desactiveSprite;

	[SerializeField]
	bool activate;


	public bool Activate{get{ return activate; } set{ activate = value;}}
	[SerializeField]
	MenuOption menuOption;
	/// <summary>
	/// The permission for playing sound by keyboard selection.
	/// </summary>
	public bool PlaySound = false;


	// Use this for initialization
	void Start () {

		Invoke ("ActivatePlaySoundByDelayTime", 1.5f);
	}
	void ActivatePlaySoundByDelayTime(){
		PlaySound = true;
	}
	// Update is called once per frame
	void Update () {

		if (StartMenuController.optionChoosed == menuOption ) {
			

			activate = true;


		} else {
			activate = false;

		}
		if (activate) {

			if (activate == true && PlaySound == true) {
				PlaySound = false;
			}


			activeSprite.SetActive (true);
			desactiveSprite.SetActive (false);
		} else {

			PlaySound = true;
			activeSprite.SetActive (false);
			desactiveSprite.SetActive (true);
		}

	}
	public void OnClick(){
	
		if (menuOption == MenuOption.MapMenu) {
			SceneManager.LoadScene (SceneNames.MapScene);
		}
		if (menuOption == MenuOption.LoadGameMenu) {
			SceneManager.LoadScene (SceneNames.LoadSave);
		}
		if (menuOption == MenuOption.Exit) {
			Application.Quit ();
		}
        if (menuOption == MenuOption.Credits)
        {
            SceneManager.LoadScene(SceneNames.Credits);

        }
		if (menuOption == MenuOption.Instructions)
		{
			SceneManager.LoadScene(SceneNames.Instructions);

		}
        if (menuOption == MenuOption.OptionMenu) {
			SceneManager.LoadScene (SceneNames.Options);
		}

	}
	public void MouseOver(){
		GameObject.FindGameObjectWithTag ("SoundUtility").GetComponent<SoundListUtility> ().PlayElementByName ("selection_menu_option");

	}
	public void MouseClick(){
		GameObject.FindGameObjectWithTag ("SoundUtility").GetComponent<SoundListUtility> ().PlayElementByName ("onclick_menu_sound");

	}

}
