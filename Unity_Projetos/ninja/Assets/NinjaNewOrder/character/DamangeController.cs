using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamangeController : MonoBehaviour {

    public bool iEnemy;
    public bool IVeBeemDamanged = false;
    public int Damange = 1;
    public Vector2 DirectionDamange;
    public GameObject otherObject;// shoud not public
    public float TimeOfFallBack = 0.1f;
    public float ConterTimeFallBack = 0;
    private void OnEnable()
    {
        ConterTimeFallBack = 0;

        IVeBeemDamanged = false;
        Invoke("SetDamangedTrue", 0.2f);
    }
    void SetDamangedTrue()
    {
        IVeBeemDamanged = true;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(!IVeBeemDamanged)
            if (iEnemy)
            {
                if (other.transform.tag == "Player")
                {

                    CharacterControllerMain controllerMain = other.transform.GetComponent<CharacterControllerMain>();
                    if (controllerMain != null)
                    {
                        controllerMain.TakeDamange(Damange);
                        otherObject = other.gameObject;
                     //   other.transform.GetComponent<Rigidbody2D>().AddForce(DirectionDamange * 100);

                        Debug.Log("take life of player: Life Now" + controllerMain.CharacterData.Life());
                        IVeBeemDamanged = true;
                        //DesactiveMe.SetActive(false);
                        GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("hurt_character_player");
                    }
                }
            }
            else
            {
                if (other.transform.tag == "NPC")
                {
                    BotSimpleIAClass Player = other.transform.GetComponent<BotSimpleIAClass>();
                    if (Player != null)
                    {
                        Player.TakeDamange(Damange);
                        otherObject = other.gameObject;
                        // otherObject.transform.GetComponent<Rigidbody2D>().AddForce(DirectionDamange*100);
                        Debug.Log("take life of Enemy" + Player.CharacterData.Life());
                        // DesactiveMe.SetActive(false);
                        GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("hurt_character");

                        IVeBeemDamanged = true;
                    }

                }
                if (other.transform.tag == "FNPC")
                {
                    FuzzyIA Player = other.transform.GetComponent<FuzzyIA>();
                    if (Player != null)
                    {
                        Player.TakeDamange(Damange);
                        otherObject = other.gameObject;
                        // otherObject.transform.GetComponent<Rigidbody2D>().AddForce(DirectionDamange*100);
                        Debug.Log("take life of Enemy" + Player.data.Life());
                        // DesactiveMe.SetActive(false);
                        GameObject.FindGameObjectWithTag("SoundUtility").GetComponent<SoundListUtility>().PlayElementByName("hurt_character");

                        IVeBeemDamanged = true;
                    }

                }
            }
    }

    private void Update()
    {
        ConterTimeFallBack += Time.deltaTime;

        if ( isActiveAndEnabled && otherObject != null && ConterTimeFallBack <= 0.15f )
        {
         //   otherObject.transform.GetComponent<Rigidbody2D>().AddForce(DirectionDamange * Time.deltaTime / 10000);
            otherObject.transform.Translate(DirectionDamange / 10);
        }
     
     
    }
    private void OnDisable()
    {
        otherObject = null;
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(!IVeBeemDamanged)
            if (iEnemy)
            {
                if (other.transform.tag == "Player")
                {

                    CharacterControllerMain controllerMain = other.transform.GetComponent<CharacterControllerMain>();
                    if (controllerMain != null)
                    {
                        controllerMain.TakeDamange(1);
                        Debug.Log("take life of player: Life Now" + controllerMain.CharacterData.Life());
                        IVeBeemDamanged = true;
                        //DesactiveMe.SetActive(false);
                    }
                }
            }
            else
            {
                if (other.transform.tag == "NPC")
                {
                    BotSimpleIAClass Player = other.transform.GetComponent<BotSimpleIAClass>();
                    if (Player != null)
                    {
                        Player.TakeDamange(1);
                        Debug.Log("take life of Enemy" + Player.CharacterData.Life());
                        // DesactiveMe.SetActive(false);
                        IVeBeemDamanged = true;
                    }

                }
            }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("take trigger of Enemy colission");
        if (iEnemy)
        {
            if(other.tag == "Player") {

                CharacterControllerMain controllerMain = other.GetComponent<CharacterControllerMain>();
                if (controllerMain != null)
                {
                    controllerMain.TakeDamange(2);
                    Debug.Log("take life of player");
                }
            }
        }
        else
        {
            if (other.tag == "NPC") {
                BotSimpleIAClass Player = other.GetComponent<BotSimpleIAClass>();
                if (Player != null)
                {
                    Player.TakeDamange(2);
                    Debug.Log("take life of Enemy");
                }

            }
        }
    }
    */

}
