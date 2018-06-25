using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMenuSelector : MonoBehaviour {

    public GameObject mobile;
    public GameObject pc_console;
    public bool LoopMe = false;
	// Use this for initialization
	void Start () {
      

                if(mobile != null) { 
                    mobile.SetActive(false);
                }
                if(pc_console!= null) { 
                    pc_console.SetActive(true);
                }

        #if UNITY_ANDROID
                        if (mobile != null)
                        {
                            mobile.SetActive(true);
                        }
                        if (pc_console != null)
                        {
                            pc_console.SetActive(false);
                        }
        #endif
        

    }
    public void Update()
    {
        if (LoopMe)
        {

            if (mobile != null)
            {
                mobile.SetActive(false);
            }
            if (pc_console != null)
            {
                pc_console.SetActive(true);
            }

#if UNITY_ANDROID
                        if (mobile != null)
                        {
                            mobile.SetActive(true);
                        }
                        if (pc_console != null)
                        {
                            pc_console.SetActive(false);
                        }
#endif
        }
    }
}


