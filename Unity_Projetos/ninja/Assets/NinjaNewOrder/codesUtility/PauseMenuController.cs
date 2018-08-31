using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
    [SerializeField]/// this is the menu object that will apper or not dependind what player did, if he pushed de Pause Button or not
    GameObject Menu;
    // Use this for initialization

   public  bool pause;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pause = GameManager.isPaused;
        Menu.SetActive(pause);
        
    }
}
