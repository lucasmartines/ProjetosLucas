using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// when player touch some object the scene turns to another
/// </summary>
public class TriggerSceneSwitch : MonoBehaviour {

    [SerializeField] string SceneName;
    public enum KindOfTrigger { touchAndEndScene,touchAndSubmit}
    public KindOfTrigger trigger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if (trigger == KindOfTrigger.touchAndSubmit) { 
                if (InputManager.YButton(true)) {
                    Debug.Log("Swich scene");
                    SceneManager.LoadScene(SceneName);
                }
            }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            if(trigger == KindOfTrigger.touchAndSubmit) { 
                if (InputManager.YButton(true) || Input.GetButtonDown("Submit") )
                {
                    Debug.Log("Swich scene");
                    SceneManager.LoadScene(SceneName);
                }
            }
            if (trigger == KindOfTrigger.touchAndEndScene) { 
                {
                    GameManager.State = GameManager.GameState.youwin;

                }
            }
    }

}
