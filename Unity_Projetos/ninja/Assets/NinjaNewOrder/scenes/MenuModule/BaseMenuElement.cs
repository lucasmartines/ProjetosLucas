using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseMenuElement : MonoBehaviour {


    public MenuSceneLoader sceneLoader;
    public BaseMenuElement next;
    public BaseMenuElement before;

    [SerializeField]
    Text active,desactive;
    [SerializeField]
    GameObject activeElement, desactiveElement;

    public bool ElementActive;


    void Start () {
		

	}
	void Update () {


        
      //  active.text = desactive.text = Text;
        if (ElementActive)
        {
            // desative o conponent não o objeto inteiro
            //activeElement.GetComponentInChildren<Text>()
            activeElement.GetComponentInChildren<Text>().enabled = true;
            desactiveElement.GetComponentInChildren<Text>().enabled = false;
            //activeElement.SetActive(true);
           // desactiveElement.SetActive(false);
            sceneLoader.OnSelected();
        }
        else
        {
            activeElement.GetComponentInChildren<Text>().enabled = false;
            desactiveElement.GetComponentInChildren<Text>().enabled = true;
          //  activeElement.SetActive(false);
          //  desactiveElement.SetActive(true);
        }
       
	}

}
