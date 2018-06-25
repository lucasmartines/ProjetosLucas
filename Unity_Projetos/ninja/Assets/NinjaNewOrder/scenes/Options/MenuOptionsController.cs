using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptionsController : MonoBehaviour {

    public List< VerticalSelection > options;
    public int actualId = 0;
    public int ActualID { get { return actualId; } }
	// Use this for initialization
	void Start () {
		
	}
    /// <summary>
    ///  Select otside of code one option for menu
    /// </summary>
    /// <param name="option"></param>
	public void ChangeOption(int option)
    {
        actualId = option;
        actualId = Mathf.Clamp(actualId, 0, options.Count - 1);
    }
	// Update is called once per frame
	void Update () {



        for(int x = 0; x < options.Count; x++)
        {
            if (x == actualId) { 
              options[x].Active = true;
            }
            else
            {
                options[x].Active = false;
            }

        }

        float direction = InputManager.PovVertical();

        if (direction > 0 )
        {
            GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("selection_menu_option");
            actualId--;
        }
        if (direction < 0)
        {
            GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("selection_menu_option");
            actualId++;
        }

        actualId = Mathf.Clamp(actualId, 0, options.Count -1);

    }
}
