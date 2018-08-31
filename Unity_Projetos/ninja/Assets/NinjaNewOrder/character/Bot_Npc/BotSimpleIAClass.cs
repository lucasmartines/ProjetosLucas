using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterBotAction { Patrol ,Chase ,Die,Atack,Win,Idle,Flee}

public class BotSimpleIAClass : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D character;

    [SerializeField] CharacterData characterData;
    public CharacterData CharacterData { get { return characterData; } }

    public float LastTimeDirection { get; private set; }
    public int directionID { get; private set; }

    [SerializeField] CharacterDirection direction;
    [SerializeField] CharacterBotAction action;
    public int AnimationSelectionID = 0;

    public float TimeAtack = 0;
    public float TimeAnimationAtack = 0;
    float DamangeTime;
   public float GameTime = 0;
    public float ChaseDistance;
    public float TimeBetweenAtack;
    public float AtackSpaceDistance;
    [SerializeField]
    bool isNearAtack;
    [SerializeField]
    bool playerIsNear;

    public float[] positions = new float[2];

    public List<GameObject> animationObjects;
    void Start()
    {
        if(player == null)
        {
            // pegue o jogador mais proximo da lista
        }
        GameTime = Time.time;
        DamangeTime = Time.time;


    }
    void IAVerification()
    {


        // verify if player is near

        Vector2 playerDistance = player.transform.position- gameObject.transform.position ;


        if (playerDistance.magnitude < ChaseDistance)
        {

            playerIsNear = true;

            if(playerDistance.magnitude < AtackSpaceDistance)
            {
                isNearAtack = true;
            }
            else
            {
                isNearAtack = false;
            }
        }
        else
        {
            playerIsNear = false;
        }
        // verify if is near atack

        if(GameTime < DamangeTime+0.2)
        {
           //damange animation
        }
      
        if (!isNearAtack && !playerIsNear)//for now
        {
            action = CharacterBotAction.Idle;
        }
        else if ( (playerIsNear && isNearAtack && action == CharacterBotAction.Atack && (GameTime > TimeAtack + 0.8f)))
        {
            action = CharacterBotAction.Chase;
        }
        else if (isNearAtack && GameTime > TimeAtack + TimeBetweenAtack)
        {
            TimeBetweenAtack = UnityEngine.Random.Range(1f, 2.5f);
            action = CharacterBotAction.Atack;
            TimeAtack = Time.time;
        }

        else if ( ( playerIsNear && !isNearAtack)  )
        {
            action = CharacterBotAction.Chase;

        }
    
        
       
        if (characterData.Life() <= 0)
        {
            action = CharacterBotAction.Die;
            Invoke("DestroyMe", 0.5f);
        }
        /*
        if (player.GetComponent<CharacterControllerMain>().CharacterData.Life() <= 0)
        {
            action = CharacterBotAction.Win;

        }


      
    */
    }
    void DestroyMe()
    {
        Destroy(gameObject);
    }
    void Update()
    {


        if (GameManager.isPaused == false)
        {

            GameTime += Time.deltaTime;

            IAVerification();



            if (action == CharacterBotAction.Chase)
            {
                Vector2 playerDistance = player.transform.position - gameObject.transform.position;
                character.velocity = playerDistance  * (float)characterData.CharacterVelocity();
            }

            if (action == CharacterBotAction.Idle)
            {
                character.velocity = Vector2.zero;
                // rules to patrol
            }


            direction = GetDirection();

            SetAnimatedObjectByAction();

        }
        else
        {
            direction = 0;
            action = CharacterBotAction.Idle;
            AnimationSelectionID = 0;
            TimeAtack = 0;
            GameTime = 0;
       
            character.velocity = Vector2.zero;
        }


    }
    public void TakeDamange(int amount)
    {
        DamangeTime = Time.time;
        characterData.Life(characterData.Life() - amount);
    }

    public CharacterDirection GetDirection()
    {
        // is important that x is in first and y is last

        var Xv = Mathf.Abs(character.velocity.x);
        var Yv = Mathf.Abs(character.velocity.y);

        if(Xv > Yv) { 
            if ( character.velocity.x < 0)
            {
                return CharacterDirection.Left;
            }
            if (character.velocity.x > 0)
            {
                return CharacterDirection.Right;

            }
        }
        else if (Xv < Yv) { 
            if (character.velocity.y > 0)
            {
                return CharacterDirection.Up;
            }
            if (character.velocity.y < 0)
            {
                return CharacterDirection.Down;
            }
        }
        return CharacterDirection.Up;
    }

    public int GetDirectionById()
    {
        if (direction == CharacterDirection.Up)
        {
            if (Time.time > LastTimeDirection + 0.3f)
            {
                LastTimeDirection = Time.time;
                directionID = 0;
                return 0;

            }

        }
        else if (direction == CharacterDirection.Right)
        {
            if (Time.time > LastTimeDirection + 0.3f)
            {
                LastTimeDirection = Time.time;
                directionID = 1;
                return 1;

            }
        }
        else if (direction == CharacterDirection.Down)
        {
            if (Time.time > LastTimeDirection + 0.3f)
            {
                LastTimeDirection = Time.time;
                directionID = 2;
                return 2;

            }
        }
        else if (direction == CharacterDirection.Left)
        {
            if (Time.time > LastTimeDirection + 0.3f)
            {
                LastTimeDirection = Time.time;
                directionID = 3;
                return 3;

            }
        }
        if (Time.time < LastTimeDirection + 0.3f)
        {
            return directionID;
        }
        return 0;
    }

    public void SetAnimatedObjectByAction()
    {

        if (action == CharacterBotAction.Idle)
        {
            AnimationSelectionID = 0;
        }

        else if (action == CharacterBotAction.Die )
        {
            AnimationSelectionID = 1;
        }

        else if (action == CharacterBotAction.Patrol || action == CharacterBotAction.Chase)
        {
            AnimationSelectionID = 2;
        }
        // this animation even create a atack object in another gameObject labeled by animation selectionId
        else if (action == CharacterBotAction.Atack  )//&& GameTime > TimeAtack + MaxAtackTime)//0.5f is time span
        {
            character.velocity = character.velocity / 4f;
            
     
            AnimationSelectionID = 3;

          
        }

        for (int x = 0; x < animationObjects.Count; x++)
        {
            if (x == AnimationSelectionID)// animação corresponde ao id ative ela se não desative
            {
                animationObjects[x].SetActive(true);
                animationObjects[x].GetComponent<CharacterControllerDirection>().AnimationSelectionID = GetDirectionById();
            }
            else
            {
                animationObjects[x].SetActive(false);
            }

        }
    }
}
