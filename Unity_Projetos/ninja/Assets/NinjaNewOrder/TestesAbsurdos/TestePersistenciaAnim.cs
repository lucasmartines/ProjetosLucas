using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestePersistenciaAnim : MonoBehaviour {
    public GameObject anim;

    public GameObject anim1;
    public bool isActivated;
	// Use this for initialization
    public enum VoldX { ianX, ianY, ianZ };
    public VoldX a;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (a == VoldX.ianX)
        {

            anim.SetActive(true);
            anim1.SetActive(false);

        }
        else if (a == VoldX.ianY)    
        {
            anim1.SetActive(true);
            anim.SetActive(false);

        }
          
	}
}
