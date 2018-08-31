using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElementTraductionController : MonoBehaviour {
	/// <summary>
	/// The element that will receive traduction.
	/// </summary>
	[SerializeField]
	Text TextElement;
	[SerializeField]
	MenuTraduction traduction;

    public ElementTraductionController controller;
	/// <summary>
	/// The oficial language reference is if you want a back button you
	/// write here back button then it will turn to portuguese or not
	/// depending of configuration.
	/// </summary>
	public string OfficialLanguageReference;
	public bool upperCase;
	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {

		if(traduction == null) { 
			traduction = GameObject.FindGameObjectWithTag ("MenuTraduction").GetComponent<MenuTraduction>();
        }
        if (TextElement != null && traduction != null) {

            if (traduction.GetElementByTraduction(OfficialLanguageReference) != null)
                TextElement.text = traduction.GetElementByTraduction(OfficialLanguageReference);
        }
        if (upperCase) {
			Debug.Log ( "Function need to finish" );
		}
	}
    public MenuTraduction GetTraductor()
    {
        return traduction;
    }
}
