using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubVerticalSelection : MonoBehaviour {
    [SerializeField]
    SpriteRenderer active, desactive;
    public bool Active;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Active)
        {
            active.enabled = true;
            desactive.enabled = false;
        }
        else
        {
            active.enabled = false;
            desactive.enabled = true;
        }
    }
}
