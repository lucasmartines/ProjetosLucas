using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour {

    private GameObject PauseButton;

    private void Start()
    {
        PauseButton = transform.GetChild(0).gameObject;


    }
    // Update is called once per frame
    void Update () {

        bool Active = GameManager.isPaused ? false : true;
        PauseButton.SetActive(Active);

	}
    public void PauseGame()
    {
        GameManager.isPaused = !GameManager.isPaused;
    }
}
