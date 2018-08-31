using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AutoScroll : MonoBehaviour {

    public float incrementer;
    public Scrollbar scrollbar;
    bool permissionForAutoScrool = true;
    public float LastTime;
    /// <summary>
    /// this time is about time to let player use auto scrool as manual
    /// </summary>
    public float WhaitTimeToLetPUAS;
    float Conter;
    // Update is called once per frame
    void Start()
    {
        LastTime = Time.time;
        Conter = LastTime;
    }
    void Update () {
        Conter += Time.deltaTime;
        if (permissionForAutoScrool) { 
             scrollbar.value += incrementer * Time.deltaTime;
        }
        if(Time.time > LastTime + WhaitTimeToLetPUAS)
        {
            permissionForAutoScrool = false;
        }
        
    }
    public void SetpermissionForAutoScrool(bool perm)
    {
        permissionForAutoScrool = false;
    }
}
