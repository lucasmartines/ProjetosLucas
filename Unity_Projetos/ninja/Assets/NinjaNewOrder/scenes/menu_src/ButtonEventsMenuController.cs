using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEventsMenuController : MonoBehaviour {
    /// <summary>
    /// wich keycode will invoke the function
    /// </summary>
    public KeyCode keycode;
	// Use this for initialization
    public delegate void MeyEvento();
    /// <summary>
    /// event for keydown
    /// </summary>
    public event MeyEvento evento;

	void Start () {
        

        evento += GoToMainMenu;

	}
	
	void Update () {
	    
		if( Input.GetKeyDown( keycode ) || Input.GetButtonDown("Confirm") || Input.GetButtonDown("Submit")){
                evento();
            }
	}
    public virtual void GoToMainMenu()
    {
        Debug.Log("back");
        SceneManager.LoadScene(SceneNames.StartMenu);
        GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("onclick_menu_sound");

    }
    public virtual void GoToMap()
    {
       
        SceneManager.LoadScene(SceneNames.MapMenu);
      // GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("onclick_menu_sound");

    }
}
