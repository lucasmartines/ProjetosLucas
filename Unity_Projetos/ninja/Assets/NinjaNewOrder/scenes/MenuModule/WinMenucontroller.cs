using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenucontroller : MonoBehaviour {
   /// this is the menu object that will apper or not dependind what player did
    public GameObject Menu;
    // Use this for initialization
    void Update()
    {
        if(GameManager.State == GameManager.GameState.youwin)
        {
            Menu.SetActive(true);
        }
        else
        {
            Menu.SetActive(false);
        }
    }
 
}
