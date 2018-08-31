using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class GameData{
	[SerializeField]
	public bool isEnglish;
	public float volume;


}
public class GameConfiguration:MonoBehaviour
{

	public static GameData gameData;
	public static string result;

	void Start(){
		gameData = new GameData();
		gameData.isEnglish = true;

		//SaveConfiguration ();
		LoadConfiguration();

	}
	public  void LoadConfigurationMobile(){

        StartCoroutine(LoadConfigurationALLPlatform());
        // android

        // windows

        // xbox

    }
	public   IEnumerator LoadConfigurationALLPlatform(){
		
		string filePath = Path.Combine (Application.streamingAssetsPath,"base_config.json");


		if (filePath.Contains ("://") ) {
			
			UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(filePath);
			yield return www.SendWebRequest ();
			string result = www.downloadHandler.text;
			gameData = JsonUtility.FromJson<GameData>(result);
		}
		else {
			string result = System.IO.File.ReadAllText(filePath);
			gameData = JsonUtility.FromJson<GameData>(result);
		}


	}
	public void LoadConfiguration(){

        // if android 
        //  IEnumerator cr =;

       StartCoroutine(LoadConfigurationALLPlatform());


        // if pc

        /*
		string urlGameData = Path.Combine (Application.streamingAssetsPath,"base_config.json");


		if(File.Exists(urlGameData) ){
			string stringJason = File.ReadAllText(urlGameData);
			gameData = JsonUtility.FromJson<GameData>(stringJason);
		
		}
		else{
			Debug.Log("Erro arquivo base_config.json não encontrado");
		}
		*/

    }
    public IEnumerator SaveConfigurationAllPlatform()
    {

        string filePath = Path.Combine(Application.streamingAssetsPath, "base_config.json");

       

            var stringGameData = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, stringGameData);

        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Put(filePath, stringGameData);

           
        //Debug.Log(stringGameData);
            yield return www.SendWebRequest();
          
        
      
    }
	public void SaveConfiguration(){

        string filePath = Path.Combine(Application.streamingAssetsPath, "base_config.json");



        var stringGameData = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, stringGameData);

        // StartCoroutine(SaveConfigurationAllPlatform());

        /*
		string urlGameData = Path.Combine (Application.streamingAssetsPath,"base_config.json");


		if(File.Exists(urlGameData) ){
			

			var stringGameData = JsonUtility.ToJson (gameData);

			File.WriteAllText (urlGameData, stringGameData);

		}
		else{
			Debug.Log("Erro arquivo base_config.json não encontrado");
		}

    
		// xbox

    */

    }
}


