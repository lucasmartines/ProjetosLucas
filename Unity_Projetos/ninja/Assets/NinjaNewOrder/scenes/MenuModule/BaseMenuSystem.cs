using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// this menu is generic for all menus 
/// </summary>
public class BaseMenuSystem : MonoBehaviour {
    /// <summary>
    /// actual represents the first option auto selected by
    /// computer when the scene starts
    /// </summary>
    public BaseMenuElement actual;
    // Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



        if( actual.before != null )
        {
            actual.before.ElementActive = false;
        }
        if ( actual.next != null )
        {
            actual.next.ElementActive = false;
        }

        actual.ElementActive = true;

        float direction = InputManager.PovVertical();

        if (direction > 0)
        {
            
            if (actual.before != null)
            {
                GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("selection_menu_option");


                actual = actual.before;

            }

        }
        if (direction < 0) 
            {


            if ( actual.next != null )
                    {
                        GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("selection_menu_option");

                        actual = actual.next;

                    }
              
            }
        


    }

}
