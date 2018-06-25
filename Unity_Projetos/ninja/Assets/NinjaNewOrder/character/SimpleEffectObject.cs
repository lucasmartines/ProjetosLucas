using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class that creat a object that make something to player for example
/// giving life or energy
/// whatever this does not matter 
/// </summary>
public class SimpleEffectObject : MonoBehaviour {
    
    public enum TypeOfAction { Life, Energy , Coin};
    /// <summary>
    /// This is type of action
    /// what it actualy does is noting but giving life to player or energy or coin,
    /// it depend what you as a designer whant and i guess what i developed
    /// forgive my strange english is a working in progress
    /// </summary>
    public TypeOfAction typeOfAction;
    // Use this for initialization
    bool iWasUsed;

    public int ValueAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && !iWasUsed)
        {
            iWasUsed = true;
            Destroy(this.gameObject, 0.03f);
            PlaySound();
            switch (typeOfAction)
            {

                case TypeOfAction.Life:
                    collision.GetComponent<CharacterControllerMain>().CharacterData.LifeIncrease(ValueAmount);
                    break;

            }
        }

    }
    public void PlaySound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if ( audio != null)
        {
            audio.volume = SoundController.GetVolume();
            audio.Play();
        }
    }
    public void OnDestroy()
    {
        //Destroy(this.gameObject,)
    }
}
