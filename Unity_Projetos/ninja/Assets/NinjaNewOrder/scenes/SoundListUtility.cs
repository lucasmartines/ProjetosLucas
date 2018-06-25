using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundElement{
	public string soundName;
	public AudioClip audioFile;
	public SoundElement( string name , AudioClip audioFile){
		soundName = name;
		this.audioFile = audioFile;
	}
}
public class SoundListUtility : MonoBehaviour {

	


	[SerializeField]
	List<AudioClip> audioClip;

	List<SoundElement> sounds ;

	public AudioSource audioSource;
	void Awake(){

       
    }
	// Use this for initialization
	void Start () {

		sounds = new List<SoundElement> ();

		sounds.Add ( new SoundElement ("girl_kid_jump", audioClip [0] ) );
		sounds.Add ( new SoundElement ( "male_kid_jump", audioClip [1] ) );
		sounds.Add ( new SoundElement ("selection_menu_option", audioClip [2] ) );
        sounds.Add ( new SoundElement ("onclick_menu_sound", audioClip [3] ) );


        if ( sounds.Count >= 5) { 

            if (sounds[5] != null)
                sounds.Add(new SoundElement("hurt_character", audioClip[5]));
            if(sounds[6]!=null)
                sounds.Add(new SoundElement("hurt_character_player", audioClip[6]));
            if (sounds[7] != null)
                sounds.Add(new SoundElement("sword_character_player", audioClip[7]));
        }
        //var soundToPlay = GetElementByName ("menu_selection");

        //audioSource.clip = soundToPlay.audioFile;
        //audioSource.Play ();



    }
	/// <summary>
	/// Gets the name of the element by.
	/// </summary>
	/// <returns>The element by name.</returns>
	/// <param name="name">Name.</param>
	public SoundElement GetElementByName(string name){


		foreach (SoundElement element in sounds) {
			if(element !=null)
				if (element.soundName == name) {
					return element;
				}
		}
		return null;
	}
	/// <summary>
	/// Play some sond by this
	/// </summary>
	/// <param name="name">Name.</param>
	/// 
	public void PlayElementByName(string name){


		foreach (SoundElement element in sounds) {
			if(element !=null)
			if (element.soundName == name) {
				audioSource.clip = element.audioFile;
				audioSource.Play ();
			}
		}
	

	}
    /// <summary>
    /// Play Sound directly if exist in scene an object of tag sound utility
    /// </summary>
    /// <param name="SoundNameInList"></param>
    public static void PlaySoundByList(string SoundNameInList)
    {
        SoundListUtility slu = GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>();
        if( slu != null)
        {
            slu.PlayElementByName(SoundNameInList);
        }
    }


}
