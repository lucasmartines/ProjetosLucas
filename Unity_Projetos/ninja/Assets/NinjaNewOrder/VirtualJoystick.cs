using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class VirtualJoystick : MonoBehaviour , IDragHandler , IPointerUpHandler,IPointerDownHandler
{
    private Image bgImage;
    private Image JoyImage;
    private static Vector3 InputVector;

    void Start()
    {
        bgImage = GetComponent<Image>();
        JoyImage = transform.GetChild(0).GetComponent<Image>();


    }


    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 Position;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImage.rectTransform,ped.position,ped.pressEventCamera,out Position))
        {
            

            Position.x = (Position.x / bgImage.rectTransform.sizeDelta.x);
            Position.y = (Position.y / bgImage.rectTransform.sizeDelta.y);


            InputVector = new Vector3(Position.x * 2 + 1, 0, Position.y * 2 - 1);

            InputVector = (InputVector.magnitude > 1) ? InputVector.normalized : InputVector;
            

            Debug.Log(InputVector);
            // Moving Joystick image
            JoyImage.rectTransform.anchoredPosition = new Vector3
             (
                  InputVector.x * (bgImage.rectTransform.sizeDelta.x / 3),
                  InputVector.z * (bgImage.rectTransform.sizeDelta.y / 3)
             );

        }



    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        InputVector = Vector3.zero;
        JoyImage.rectTransform.anchoredPosition = Vector3.zero;

    }
    public static float Horizontal()
    {
        if(InputVector.x!= 0)
        {
            return InputVector.x;

        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
    public static float Vertical()
    {
        if (InputVector.z != 0)
        {
            return InputVector.z;

        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
   
}
