using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This is the pause menu controller 
/// </summary>
public class WinController : MonoBehaviour {
    [SerializeField]
    MenuOptionsController option;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) || InputManager.AButton(false) || InputManager.BButton(false)) { 
            if(option.ActualID == 0)
            {
                GameManager.isPaused = true;

                SceneManager.LoadScene(SceneNames.MapMenu);
            }
            
        }
    }
}
