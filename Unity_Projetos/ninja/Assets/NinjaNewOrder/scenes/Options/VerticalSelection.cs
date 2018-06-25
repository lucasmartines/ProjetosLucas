using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSelection : MonoBehaviour {
[SerializeField]
    GameObject active, desactive;
    public bool Active;

    public List<SubVerticalSelection> options;
    public int actualId = 0;
    // bool first frame selection loop frames selection

    // Use this for initialization
    void Start () {
		
	}
    public void ChangeOption(int option)
    {
        actualId = option;
        actualId = Mathf.Clamp(actualId, 0, options.Count - 1);
        GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("selection_menu_option");

    }
    // Update is called once per frame
    void Update () {

        if (Active)
        {
            // acesse todos os elementos submenu e torne eles como menu
            active.SetActive(true);// = false;
            desactive.SetActive(false);// = true;

            float direction = InputManager.PovHorizontal();


            if (direction > 0)
            {
                GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("selection_menu_option");
                actualId++;
            }
            if (direction < 0)
            {
                GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("selection_menu_option");
                actualId--;
            }


        }
        else
        {
            active.SetActive(false);// = false;
            desactive.SetActive(true);// = true;


        }

        
        for (int x = 0; x < options.Count; x++)
        {
            if (x == actualId)
            {
                options[x].Active = true;
            }
            else
            {
                options[x].Active = false;
            }

        }

        

        actualId = Mathf.Clamp(actualId, 0, options.Count - 1);


        if (!Active) { 
            SubVerticalSelection[] subSelections = GetComponentsInChildren<SubVerticalSelection>();
            foreach (SubVerticalSelection subVerticalSelection in subSelections)
            {
                subVerticalSelection.Active = false;
            }
        }

    }
}
