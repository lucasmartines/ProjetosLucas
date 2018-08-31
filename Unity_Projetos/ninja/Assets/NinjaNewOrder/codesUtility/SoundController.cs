using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
	/// <summary>
	/// The sound list utility have a lot of sound pre configured to use.
	/// </summary>

	static GameObject thisSoundController;
	[SerializeField]
	SoundListUtility soundListUtility;
    public GameConfiguration gm;
	public SoundListUtility SoundList{ get { return soundListUtility; } set { soundListUtility = value; } }
    
	void Awake(){
        /* 
        if (thisSoundController != null)
        {
            Destroy(this.gameObject);

        }
        if (thisSoundController == null) {
			thisSoundController = this.gameObject;
			DontDestroyOnLoad (gameObject);
			
		}
		*/

	}

	// Use this for initialization
	void Start () {
		//soundListUtility
		if (soundListUtility == null) {
			GameObject.FindGameObjectWithTag ("SoundUtility").GetComponent<SoundListUtility> ();

		}
        gm.LoadConfiguration();
        
    }

    // Update is called once per frame
    void Update () {
        AudioSource[] sources = GetComponents<AudioSource>();
        foreach (AudioSource source in sources)
        {
            source.volume = GameConfiguration.gameData.volume;
        }
        
	}
    public static float GetVolume()
    {

        return GameConfiguration.gameData.volume;
    }
}
