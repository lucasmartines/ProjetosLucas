using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Controller the start up content like engine
/// enterprise and fatec brand
/// </summary>

public class StartupController : MonoBehaviour {

	/// <summary>
	/// cont timer of transicion based on delta time
	/// </summary>
	public float TimeConter;
	/// <summary>
	/// This is the max transiction of one scene
	/// </summary>
	[SerializeField]
	float transictionTime = 3;
	public float TransicionTime{ get{ return transictionTime;}set{ transictionTime = value;}}

	/// <summary>
	/// The open utility inversor is useful for use one var that
	/// invert to open one scene to another.
	/// </summary>
	bool openUtilityInversor = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		TimeConter += Time.deltaTime;


		if (( TimeConter > 0 && TimeConter < transictionTime   ) && openUtilityInversor == true ) {
			
			SceneManager.LoadSceneAsync (SceneNames.EngineBrand,LoadSceneMode.Additive);
			openUtilityInversor = false;
		}

		else if ( ( TimeConter > transictionTime && TimeConter < transictionTime * 2   )  ) {

			if (openUtilityInversor == false) {
				openUtilityInversor = true;
				if (openUtilityInversor) {
					SceneManager.UnloadSceneAsync (SceneNames.EngineBrand);
					SceneManager.LoadSceneAsync (SceneNames.EnterpriseBrand, LoadSceneMode.Additive);
				}
			}

		}
		else if (( TimeConter > transictionTime * 2 && TimeConter < transictionTime  * 3  ) ) {

			if (openUtilityInversor == true) {
				
				if (openUtilityInversor) {
					SceneManager.UnloadSceneAsync (SceneNames.EnterpriseBrand);
					SceneManager.LoadSceneAsync (SceneNames.FatecBrand,LoadSceneMode.Additive);
				}
				openUtilityInversor = false;
			}


		}
		//canOpen = true;
		if (TimeConter > transictionTime * 3  )  {
			if (openUtilityInversor == false) { 
				SceneManager.LoadSceneAsync (SceneNames.StartMenu, LoadSceneMode.Additive);
				SceneManager.UnloadSceneAsync (SceneNames.FatecBrand);

				openUtilityInversor = true;
			}
		}

	}
}
