using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This is the pause menu controller 
/// </summary>
public class PauseController : MonoBehaviour {
    [SerializeField]
    MenuOptionsController option;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) || InputManager.AButton(false) || Input.GetButtonDown("Confirm") ) { 
            if(option.ActualID == 0)
            {
                GameManager.isPaused = !GameManager.isPaused;
            }
            if (option.ActualID == 1)
            {
            SceneManager.LoadScene(SceneNames.MapMenu);
            }
        }
    }
}
