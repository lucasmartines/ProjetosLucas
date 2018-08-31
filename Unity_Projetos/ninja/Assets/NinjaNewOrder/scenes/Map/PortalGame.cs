using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalGame : MonoBehaviour {
    public string sceneNameForLoader;
    public static PortalGame ActalPortalUnderPlayer;

    public bool PlayerIsInside;
    public ElementTraductionController mapTraduction;
	public string screenName ;
    // Update is called once per frame

/// <summary>
/// This Menu display display information about the stage.
/// For example names or wathever.
/// </summary>
    public GameObject MenuDisplay;

	void Update () {

        showMenu();
        if(PlayerIsInside)
            if  (  InputManager.AButton(false)  || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Confirm") )
            {

                SceneManager.LoadScene(sceneNameForLoader) ;

            }
	}
    /// <summary>
    /// Load scene start game play
    /// </summary>
     public void LoadScene()
    {
     
        if (PlayerIsInside)
        {
            if( ActalPortalUnderPlayer != null) { 
                SceneManager.LoadScene(ActalPortalUnderPlayer.sceneNameForLoader);
            }
        }
    }
    public void showMenu()
    {
        if (PlayerIsInside)
        {
            MenuDisplay.SetActive(true);
        }
        else
        {
            MenuDisplay.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ( collision.CompareTag( "Player" ))
        {
            ActalPortalUnderPlayer = this;
            PlayerIsInside = true;
            mapTraduction.OfficialLanguageReference = screenName;
        }
        GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("onclick_menu_sound");
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            ActalPortalUnderPlayer = null;
            mapTraduction.OfficialLanguageReference = "Map";
            PlayerIsInside = false;
        }

    }
}
