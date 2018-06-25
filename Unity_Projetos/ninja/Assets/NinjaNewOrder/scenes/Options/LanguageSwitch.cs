using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// interfacing for language
/// </summary>
public class LanguageSwitch : MonoBehaviour {

    [SerializeField] VerticalSelection verticalSel;

    [SerializeField] MenuTraduction menuLanguageConfig;

    private void Start()
    {


        
    }

    // Update is called once per frame
    void Update () {

      

        if (verticalSel.actualId == 0)
        {
            menuLanguageConfig.ChangeGameConfigToEnglish();
        }
         if (verticalSel.actualId == 1)
        {
            menuLanguageConfig.ChangeGameConfigToPortuguese();
        }
    }
}
