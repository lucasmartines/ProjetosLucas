using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterControllerMain : MonoBehaviour {

    [SerializeField] Rigidbody2D character;
    [SerializeField] CharacterData characterData;
    public CharacterData CharacterData { get { return characterData; } }
    [SerializeField] CharacterDirection direction;
    [SerializeField] CharacterAction action;
    public int AnimationSelectionID = 0;

    public float TimeAtack = 0;
    public float DamangeTime;// damange in Time.time

    public float GameTime = 0;
    public bool disableAtack = false;
    /// <summary>
    /// Represents visual state of object
    /// </summary>
    public List<GameObject> animationObjects;


    private void Start()
    {

        TimeAtack = 0;
        DamangeTime = 0;// damange in Time.time

        GameTime = 0;

        GameTime = Time.deltaTime;

    }
    // Update is called once per frame
    void Update () {


        if ( GameManager.isPaused == false)
        {

            GameTime += Time.deltaTime;
            GameUpdate();
            SetAnimatedObjectByAction();

        }
        else
        {
           
            character.velocity = Vector2.zero;

        }

    }
    public void SetAnimatedObjectByAction()
    {

        if (action == CharacterAction.Idle)
        {
            AnimationSelectionID = 0;
        }
        else if (action == CharacterAction.Walking)
        {
            AnimationSelectionID = 1;
        }
        else if (action == CharacterAction.Running)
        {
            AnimationSelectionID = 2;
        }
       
        else if (action == CharacterAction.Atacking && !disableAtack )
        {
            AnimationSelectionID = 3;
        }
        else if (action == CharacterAction.TakingDamange && Time.time >= DamangeTime + 0.3f)
        {
           
            AnimationSelectionID = 4;
        }



        for (int x = 0; x < animationObjects.Count; x++)
        {
            if (animationObjects[x] != null) { 
                if( x == AnimationSelectionID)// animação corresponde ao id ative ela se não desative
                {
                    animationObjects[x].SetActive(true);
                    animationObjects[x].GetComponent<CharacterControllerDirection>().AnimationSelectionID = GetDirectionById();
                   
                }
                else
                {
                    animationObjects[x].SetActive(false);
                }
            }
            else
            {

                animationObjects[0].SetActive(true);
                animationObjects[0].GetComponent<CharacterControllerDirection>().AnimationSelectionID = GetDirectionById();
            }
        }
    }
    public void ReduceEnergy(float amount)
    {
        characterData.GamerEnergyBar(characterData.GamerEnergyBar() - ( amount * Time.deltaTime ) );
    }
    public virtual void GameUpdate()
    {
                /// rigid body velocity
        character.velocity =InputManager.MainJoystickXY() * (float) characterData.CharacterVelocity();
        direction = GetDirection();
        // SET CHARACTER STATE

        TimeAtack = Mathf.Clamp(TimeAtack, 0, 0.3f);
        // if atack time has ended and player atack again
        if ((Input.GetKeyDown(KeyCode.Z) || InputManager.XButton(false) )&& TimeAtack == 0 && !disableAtack)
        {
            TimeAtack = 0.5f;
            action = CharacterAction.Atacking;

        }
        // is in time   atack
        if (TimeAtack > 0 && action == CharacterAction.Atacking && !disableAtack )
        {
           // character.velocity = Vector2.zero;//alternative
            character.velocity = character.velocity / 8;
            TimeAtack -= Time.deltaTime;
            action = CharacterAction.Atacking;

        }
        else { 
       
            
        
        //IDLE


         if (character.velocity == Vector2.zero)
            {
                action = CharacterAction.Idle;
            }
            // WALK
            else if (character.velocity != Vector2.zero)
            {
                action = CharacterAction.Walking;

                if (character.velocity != Vector2.zero && (Input.GetKeyDown(KeyCode.LeftShift) || InputManager.RButton(true) ) )
                {
                    action = CharacterAction.Running;
                    character.velocity = character.velocity * (float)characterData.GamerVelocityMultplyer();

                }


            }

        

        // RUN
        }
        // GUARD



    }
    public CharacterDirection GetDirection()
    {

        if ( Mathf.Abs( InputManager.MainJoystickXY().x ) > Mathf.Abs ( InputManager.MainJoystickXY().y ) )
        {
            if (InputManager.MainJoystickXY().x < 0)
            {
                return CharacterDirection.Left;
            }
            if (InputManager.MainJoystickXY().x > 0)
            {
                return CharacterDirection.Right;

            }
        }
        else {
            if (InputManager.MainJoystickXY().y > 0)
            {
                return CharacterDirection.Up;
            }
            if (InputManager.MainJoystickXY().y < 0)
            {
                return CharacterDirection.Down;
            }
        }
        
        return CharacterDirection.Up;
        /*
        // is important that x is in first and y is last
        if(InputManager.MainJoystickXY().x < 0)
        {
            return CharacterDirection.Left;
        }
        if (InputManager.MainJoystickXY().x > 0)
        {
            return CharacterDirection.Right;

        }
        if (InputManager.MainJoystickXY().y > 0)
        {
            return CharacterDirection.Up;
        }
        if (InputManager.MainJoystickXY().y < 0)
        {
            return CharacterDirection.Down;
        }
        return CharacterDirection.Up;
        */
    }

    public int GetDirectionById()
    {
        if ( direction == CharacterDirection.Up)
        {
            return 0;
        }
        else if (direction == CharacterDirection.Right)
        {
            return 1;
        }
        else if (direction == CharacterDirection.Down)
        {
            return 2;
        }
        else if (direction == CharacterDirection.Left)
        {
            return 3;
        }

        return 0;
    }
    public void TakeDamange(int amount)
    {
        DamangeTime = Time.time;
        characterData.Life(characterData.Life()- amount);
    }
    public void Atack()
    {
        if ( TimeAtack == 0 && !disableAtack)
        {
            TimeAtack = 0.5f;
            action = CharacterAction.Atacking;

        }
    }
}
public enum CharacterAction
{
    Jumping,Falling,Died,Walking,Running,Atacking,Idle,Guard,Deffending,TakingDamange
}
public enum CharacterDirection
{
    Up,Down,Left,Right
}