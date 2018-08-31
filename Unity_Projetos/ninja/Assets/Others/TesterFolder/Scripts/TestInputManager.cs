using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestInputManager : MonoBehaviour {


    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        Debug.Log(InputManager.MainJoystickXZ());

        if(text != null)
        {

            text.text = "A_Button: " + InputManager.AButton(true) + "   ";
            text.text += "B_Button: " + InputManager.BButton(true) + "\n";
            text.text += "X_Button: " + InputManager.XButton(true) + "   ";
            text.text += "Y_Button: " + InputManager.YButton(true) + "\n";
            text.text += "L_Button: " + InputManager.LButton(true) + "   ";
            text.text += "R_Button: " + InputManager.RButton(true) + "\n";
            text.text += "Horizontal_Axis: " + InputManager.MainHorizontal() + "\n";
            text.text += "Vertical: " + InputManager.MainVertical() + "\n";
        }
    }
}
