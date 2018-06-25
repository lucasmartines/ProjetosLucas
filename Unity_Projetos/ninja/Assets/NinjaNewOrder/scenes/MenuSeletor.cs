using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class MenuSeletor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetMenuPrincipalScene(){
		SceneManager.LoadScene (SceneNames.StartMenu);
		Debug.Log ("teste");
	}
    public void SetMapMenuScene()
    {
        SceneManager.LoadScene(SceneNames.MapMenu);
        Debug.Log("teste");
    }
}
