using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum MenuOptions { PLAY_GAME, SAVE_LOAD, OPTIONS, CREDIT, EXIT_GAME,INSTRUCTIONS }

public class MenuSceneLoader : MonoBehaviour {
    [SerializeField]
    MenuOptions _optionsScenes;
    public MenuOptions OptionScene { get { return _optionsScenes; } }
    [SerializeField]
    BaseMenuElement element;
    public static MenuOptions SelectedMenu;
    public MenuOptions _selectedMenu;
    // Use this for initialization



    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _selectedMenu = SelectedMenu;

        // only one element will be active then you call submit
        if ( ( Input.GetButtonDown("Submit") || InputManager.XButton(false) )&& element.ElementActive){
            OnSubmit();
        }

	}
    public void OnSelected()// looping
    {


    }
    public void OnSubmit()
    {

        GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("selection_menu_option");

        // if option scene is menu play game or save load
        switch (_optionsScenes)
        {
           
            case MenuOptions.PLAY_GAME:
                SelectedMenu = _optionsScenes;

                SceneManager.LoadScene(SceneNames.MapScene);
		
			break;
            case MenuOptions.SAVE_LOAD:
                SelectedMenu = _optionsScenes;
                SceneManager.LoadScene(SceneNames.LoadSave);
              
                break;
            case MenuOptions.OPTIONS:
                SelectedMenu = _optionsScenes;

                SceneManager.LoadScene(SceneNames.Options);
                break;
            case MenuOptions.CREDIT:
                SelectedMenu = _optionsScenes;
                SceneManager.LoadScene(SceneNames.Credits);
                break;

			case MenuOptions.INSTRUCTIONS:
				SelectedMenu = _optionsScenes;
				SceneManager.LoadScene(SceneNames.Instructions);
				break;
            case MenuOptions.EXIT_GAME:
                SelectedMenu = _optionsScenes;
                Application.Quit();
                break;
        }
        
    }
}
