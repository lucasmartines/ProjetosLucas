using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuOption{
	MapMenu,
	LoadGameMenu,
	OptionMenu,
    Credits,
	Instructions,
	Exit
}
public class StartMenuController : MonoBehaviour {


	public static MenuOption optionChoosed;

	[SerializeField]
	MenuOption opt;

	[SerializeField]
	int menuID = 1;
	// Use this for initialization
    public int MaxButtons = 5;
	public List<string> sceneNames;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



        menuID = Mathf.Clamp(menuID, 1, MaxButtons);


		if (menuID == 1) {
			opt = MenuOption.MapMenu;

		}
		else if (menuID == 2) {
			opt = MenuOption.LoadGameMenu;
		}
		else if (menuID == 3) {
			opt = MenuOption.OptionMenu;
		}
        else if (menuID == 4)
        {
            opt = MenuOption.Credits;
        }
		else if (menuID == 5) {
			opt = MenuOption.Exit;
		}



		// keyboard
		 
		#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN

			if (Input.GetKeyDown (KeyCode.UpArrow) ) {
				menuID--;
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				menuID++;
			}

			if ( Input.GetKeyDown (KeyCode.Space) ) {
				if (menuID == 1) {
					SceneManager.LoadScene (sceneNames [0]);
				}
				else if (menuID == 2) {
					SceneManager.LoadScene (sceneNames [1]);
				}
				else if (menuID == 3) {
					SceneManager.LoadScene (sceneNames [2]);
				}
                else if (menuID == 4)
                {
                    SceneManager.LoadScene(sceneNames[3]);
                }
				else if (menuID == 5) {
					Application.Quit ();
				}


			}
		#endif

		// * keyboard


		// GamePad

		// GamePad

		optionChoosed = opt;
	}

	public void SelectSceneBymenuID(int menuID){
	

		if (menuID == 1) {
			SceneManager.LoadScene (sceneNames [0]);
		}
		else if (menuID == 2) {
			SceneManager.LoadScene (sceneNames [1]);
		}
		else if (menuID == 3) {
			SceneManager.LoadScene (sceneNames [2]);
		}
		else if (menuID == 4) {
			SceneManager.LoadScene (sceneNames [3]);
		}


	}


}
