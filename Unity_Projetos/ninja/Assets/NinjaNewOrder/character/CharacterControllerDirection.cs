using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerDirection : MonoBehaviour {

    /// <summary>
    /// 0 up
    /// 1 right
    /// 2 down
    /// 3 left
    /// </summary>
    public int AnimationSelectionID = 0;
    /// <summary>
    /// Represents visual state of object
    /// </summary>
    public List<GameObject> animationObjects;


	void Update () {

        ///x represent direction
        for (int x = 0; x < animationObjects.Count; x++)
        {
            if (x == AnimationSelectionID)// animação corresponde ao id ative ela se não desative
            {
                animationObjects[x].SetActive(true);
            }
            else
            {
                animationObjects[x].SetActive(false);
            }

        }


    }
}
