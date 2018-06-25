using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager:MonoBehaviour  {
    // -- axis
    static bool _PressedButton { get; set; }
    /// <summary>
    /// Vertical axis as a button try
    /// </summary>
    public static bool PressedButton { get { return _PressedButton; } }


    static float _vertical = 0.0f;
    static float _horizontal = 0.0f;


    void LateUpdate()
    {
        var xx = _vertical;
        Debug.Log(" vertical" + xx);
    }
    void MainVerticalAsButton()
    {

       

    }
    /// <summary>
    /// Verify once per frame dont repeat for various if for example if PovVertical > 0 if PovVertical < 1
    /// try to holt a var like this var direction = POvVertical if Direction > 0 or if direction < 0
    /// </summary>
    /// <returns></returns>
    public static float PovVertical()
    {
        if(MainVertical() == 0) {
            _vertical = MainVertical();
            return 0;
        }
        if (MainVertical() != 0)// vertical pressed
        {
            if( MainVertical() > 0 && _vertical == 0)
            {
                _vertical = 1f;
                return 1f;
            }
            else if (MainVertical() < 0 && _vertical == 0)
            {
                
                _vertical = -1f;
                return -1f;
            }
          
        }
        else if (_vertical != 0 && MainVertical() != 0)
        {
            //_vertical = 0;
            return 0;
        }
        else if (_vertical != 0 && MainVertical() == 0)
        {
            _vertical = 0;
            return 0;
        }

        return 0;
       
      
       
    }

    public static float PovHorizontal()
    {
        if (MainHorizontal() == 0)
        {
            _horizontal = MainHorizontal();
            return 0;
        }
        if (MainHorizontal() != 0)// vertical pressed
        {
            if (MainHorizontal() > 0 && _horizontal == 0)
            {
                _horizontal = 1f;
                return 1f;
            }
            else if (MainHorizontal() < 0 && _horizontal == 0)
            {

                _horizontal = -1f;
                return -1f;
            }

        }
        else if (_horizontal != 0 && MainHorizontal() != 0)
        {
            //_vertical = 0;
            return 0;
        }
        else if (_horizontal != 0 && MainHorizontal() == 0)
        {
            _horizontal = 0;
            return 0;
        }

        return 0;



    }

    public static bool isLeftAxisPositive()
    {
        float horizontal = 0.0f;
        horizontal += Input.GetAxis("J_MainHorizontal");
        horizontal += Input.GetAxis("K_MainHorizontal");
        horizontal = Mathf.Clamp(horizontal, -1, 1);

        if(horizontal < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool isRighttAxisPositive()
    {
        float horizontal = 0.0f;
        horizontal += Input.GetAxis("J_MainHorizontal");
        horizontal += Input.GetAxis("K_MainHorizontal");
        horizontal = Mathf.Clamp(horizontal, -1, 1);

        if (horizontal > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Base function for gettin positions
    /// 
    /// </summary>
    /// <returns></returns>
    public static float MainHorizontal()
    {

        float horizontal = 0.0f;
        horizontal += Input.GetAxis("J_MainHorizontal");
        horizontal += Input.GetAxis("K_MainHorizontal");
        horizontal += VirtualJoystick.Horizontal();

        return Mathf.Clamp(horizontal, -1, 1);

    }
    public static float MainVertical()
    {

        float vertical = 0.0f;
      //  #if UNITY_STANDALONE_WIN || UNITY_WSA
        vertical += Input.GetAxisRaw("J_MainVertical");
     //  #endif
        vertical += Input.GetAxisRaw("JX_MainVertical");
        vertical += Input.GetAxisRaw("K_MainVertical");
        vertical += VirtualJoystick.Vertical();

        return Mathf.Clamp(vertical, -1, 1);

    }
    public static Vector3 MainJoystickXY()
    {

        return new Vector3(MainHorizontal(), MainVertical(), 0);
    }

    public static Vector3 MainJoystickXZ()
    {

        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    //--button
    public static bool AButton(bool holdButton)
    {
        if(holdButton)
        return Input.GetButton("A_Button");
        else
            return Input.GetButtonDown("A_Button");
    }
    public static bool BButton(bool holdButton)
    {
        if (holdButton)
            return Input.GetButton("B_Button");
        else
            return Input.GetButtonDown("B_Button");
    }

    public static bool XButton(bool holdButton)
    {
        if (holdButton)
            return Input.GetButton("X_Button");
        else
            return Input.GetButtonDown("X_Button");
    }
    public static bool YButton(bool holdButton)
    {
        if (holdButton)
            return Input.GetButton("X_Button");
        else
            return Input.GetButtonDown("X_Button");
    }

    public static bool LButton(bool holdButton)
    {
        if (holdButton)
            return Input.GetButton("L_Button");
        else
            return Input.GetButtonDown("L_Button");
    }





    public static bool Pause(bool holdButton)
    {
        if (holdButton)
            return Input.GetButton("Pauser");
        else
            return Input.GetButtonDown("Pauser");
    }
    public static bool RButton(bool holdButton)
    {
        if (holdButton)
            return Input.GetButton("R_Button");
        else
            return Input.GetButtonDown("R_Button");
    }

}
