using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyIA : MonoBehaviour {

    public float[] funcPertinence;
    [SerializeField] CharacterDirection direction;
    int directionID;
    /// <summary>
    /// this character state like chasing or atacking
    /// </summary>
    public CharacterBotAction actualState;
    /// <summary>
    /// Actual id of animation to select wich object animation will be activated 
    /// </summary>
    public int AnimationSelectionID = 0;
    /// <summary>
    /// List of animation/objects
    /// </summary>
    public List<GameObject> animationObjects;

    /// <summary>
    /// this character data like life energy ...
    /// </summary>
    public CharacterData data;
    /// <summary>
    /// this character phisics
    /// </summary>
    public Rigidbody2D CharacterAI;

    public float LastTimeDirection;
    public float PlayerDistance;

    // Part of atack time
    /// <summary>
    /// amount of time of conter
    /// </summary>
    public bool liberarAtaque;
    public float UltimoAtack;
    public float RandomTime;
    public Vector2 RandomDirection;


    public float timeBetweenAtacks;// public for debug
    public float MaxdurationOfAtack;// public for debug

    public FolowPathScript folowPath;
    // part of patrol time

    // Use this for initialization
    void Start () {
        // start with patroll
        CharacterAI = GetComponent<Rigidbody2D>();
        actualState = CharacterBotAction.Patrol;
        funcPertinence = new float[4];
        if (data == null)
        {
            data = GetComponent<CharacterData>();
        }
	}

    public CharacterDirection GetDirection()
    {
        // is important that x is in first and y is last

        var Xv = Mathf.Abs(CharacterAI.velocity.x);
        var Yv = Mathf.Abs(CharacterAI.velocity.y);

        if (Xv > Yv)
        {
            if (CharacterAI.velocity.x < 0)
            {
                return CharacterDirection.Left;
            }
            if (CharacterAI.velocity.x > 0)
            {
                return CharacterDirection.Right;

            }
        }
        else if (Xv < Yv)
        {
            if (CharacterAI.velocity.y > 0)
            {
                return CharacterDirection.Up;
            }
            if (CharacterAI.velocity.y < 0)
            {
                return CharacterDirection.Down;
            }
        }
        return CharacterDirection.Up;
    }

    public void TakeDamange(int amount)
    {
       // DamangeTime = Time.time;

        //if (Time.time > DamangeTime + 0.5f) {

            data.Life(data.Life() - amount);
            //DamangeTime = Time.time;
       // }
    }


    public int GetDirectionById()
    {
        if (direction == CharacterDirection.Up)
        {
            if(Time.time > LastTimeDirection + 0.3f) {
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
        if(Time.time < LastTimeDirection + 0.3f)
        {
            return directionID;
        }
        return 0;
    }



    public void SetAnimatedObjectByAction()
    {

        if (actualState == CharacterBotAction.Idle)
        {
            AnimationSelectionID = 0;
        }

        else if (actualState == CharacterBotAction.Die)
        {
            AnimationSelectionID = 1;
        }

        else if (actualState == CharacterBotAction.Patrol || actualState == CharacterBotAction.Chase)
        {
            AnimationSelectionID = 2;
        }
        // this animation even create a atack object in another gameObject labeled by animation selectionId
        else if (actualState == CharacterBotAction.Atack)//&& GameTime > TimeAtack + MaxAtackTime)//0.5f is time span
        {
            //character.velocity = character.velocity / 4f;


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

    public float GetPlayerDistance(out GameObject nearestPlayer)
    {
        // retornar a distancia do jogador mais proximo e o jogador mais proximo
        // return nearest player and less distance between player and ia

        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

         nearestPlayer = Players[0];

        // distance dont start with zero
        float distance = Vector3.Distance(nearestPlayer.transform.position, transform.position); 

        foreach( GameObject actual in Players)
        {

            float actual_Distance = Vector3.Distance(actual.transform.position,transform.position);

            if( actual_Distance < distance)
            {
                distance = actual_Distance;
                nearestPlayer = actual;
            }
        }

        return distance;
    }

    public void Walk(Vector2 direction,float velocity)
    {
        CharacterAI.velocity = (direction * velocity) * Time.deltaTime;
    }
	// Update is called once per frame
	void Update () {

        if (!GameManager.isPaused &&
             (
                GameManager.State != GameManager.GameState.youwin &&
                GameManager.State != GameManager.GameState.speaking &&
                GameManager.State != GameManager.GameState.gameover)
            )
        {
           

            GameUpdate();
        }
        else if(GameManager.State == GameManager.GameState.youwin )// you win means player wins
        {
            actualState = CharacterBotAction.Die;
            GameUpdate();
           
        }
        else
        // in pause the ai dont move 
        {
            actualState = CharacterBotAction.Idle;
            CharacterAI.velocity = Vector2.zero;
        }
       

    }
    float FarPlayer(float distance)
    {


        float resultado = 0;
       
       

        if (distance > 10)
        {
            return 1;
        }
        // execução formula
        if (distance > 0)
        {
            distance -= 7;
            float formula = ((-0.25f * (distance * distance)) + distance);
            formula = Mathf.Clamp01(formula);
            return formula;
        }
        
        resultado = Mathf.Clamp01(resultado);
        return resultado;
    }
    float UltraNearPlayer(float distance)
    {
        // execução formula

        float resultado = 0;

        /// função degrau
        if (distance > 0 )
        {
            float formula =( (-0.25f * (distance * distance) ) + distance);/// receive values between 0 and 10
            formula = Mathf.Clamp01(formula);
            return formula;
        }

        
        return resultado;
    }
    float NearPlayer(float distance)
    {
        // execução formula
        //float distance = Vector2.
        float resultado = 0;


        /// função degrau
        if (distance > 0 )
        {
            distance -= 3;
            float formula = ((-0.25f * (distance * distance)) + distance);/// receive values between 0 and 10
            formula = Mathf.Clamp01(formula);
            return formula;
        }

        

        return resultado;
    }
    float LessLife(int Life)
    {

        float resultado = 0;
        float life = Life * 1.0f;

        // função
        resultado =   ( ( (-1 * life) / 3 ) ) + 1.2f;
        // função degrau para debug
        /*
        if ( Life < 2 )
        {
            resultado = 1;
        }*/

        resultado = Mathf.Clamp01(resultado);

        return resultado;


    }
    void GameUpdate()
    {
        // update values
        GameObject nearestPlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerDistance = GetPlayerDistance(out nearestPlayer);

        direction = GetDirection();
        SetAnimatedObjectByAction();

        
        
        //Fuzzy logic Update
        funcPertinence[0] = NearPlayer(GetPlayerDistance(out nearestPlayer));
        funcPertinence[1] = UltraNearPlayer(GetPlayerDistance(out nearestPlayer));
        funcPertinence[2] = LessLife(data.Life() );
        funcPertinence[3] = FarPlayer(GetPlayerDistance(out nearestPlayer));
        // valoresRepresentativos [0] entende-se por Jogador perto
        // valoresRepresentativos [1] entende-se por jogador muito perto
        // valoresRepresentativos [2] entende-se por pouca vida
        // valoresRepresentativos [3] entende-se por jogador longe

       
        /// get the bigger value to chose a action
        int idValorRepresentativo = 0;

        float valorMaior = funcPertinence[0];

        for(int conter = 0; conter < funcPertinence.Length; conter++)
        {
            
            if ( funcPertinence[conter] > valorMaior )
            {
                idValorRepresentativo = conter;// get the id of bigger value
                valorMaior = funcPertinence[conter];// get bigger value
            }

        }


        // change action 

        if (actualState == CharacterBotAction.Patrol)
        {

            if (idValorRepresentativo == 0/* jogadores perto */ ) { actualState = CharacterBotAction.Chase; }
            else if (idValorRepresentativo == 3/* jogadores longe */ ) { actualState = CharacterBotAction.Patrol; }
            //else if (idValorRepresentativo == 2/* jogadores longe */ ) { actualState = CharacterBotAction.Flee; }

        }
        else if (actualState == CharacterBotAction.Die)
        {
            if (idValorRepresentativo == 1/* jogadores mto perto */ ) { actualState = CharacterBotAction.Atack; }
        }

        else if (actualState == CharacterBotAction.Chase)
        {
            if (idValorRepresentativo == 0/* jogadores perto */ ) { actualState = CharacterBotAction.Chase; }
            else if (idValorRepresentativo == 1/* jogadores mto perto */ ) { actualState = CharacterBotAction.Atack; }
            else if (idValorRepresentativo == 2/* eu pouca vida */ ) { actualState = CharacterBotAction.Flee; }
            else if (idValorRepresentativo == 3/* jogadores longe */ ) { actualState = CharacterBotAction.Patrol; }

        }
        else if (actualState == CharacterBotAction.Flee)
        {
            if (idValorRepresentativo == 2/* pouca vida */ ) { actualState = CharacterBotAction.Flee; }
            else if (idValorRepresentativo == 1/* jogadores mto perto */ ) { actualState = CharacterBotAction.Atack; }
           // else if (idValorRepresentativo == 0/* jogadores perto */) { actualState = CharacterBotAction.Chase; }

        }
        else if (actualState == CharacterBotAction.Atack )
        {
            // se ultimo ataque entre 0 segundos e um após inicio do ataque mantem ataque
            // se entre 1 e dois ataques bloquear ataque
            // se ultimo ataque mais 2 segundos então liberar ataque
            

            if (idValorRepresentativo == 0/* jogadores perto */ ) {
                actualState = CharacterBotAction.Chase;

            }
            else if (idValorRepresentativo == 2/* pouca vida */ ) { actualState = CharacterBotAction.Flee; }

            else if (idValorRepresentativo == 1/* jogadores mto perto */ ) { // atack situation

       

            }
        }
     
        else if (actualState == CharacterBotAction.Idle )
        {
            if (idValorRepresentativo == 0/* jogadores perto */ ) { actualState = CharacterBotAction.Chase; }
            else if (idValorRepresentativo == 1/* jogadores mto perto */ ) { actualState = CharacterBotAction.Atack; }
            else if (idValorRepresentativo == 2/* pouca vida */ ) { actualState = CharacterBotAction.Flee; }

            else if (idValorRepresentativo == 3/* jogadores longe */ ) { actualState = CharacterBotAction.Idle; }


        }


        if (actualState != CharacterBotAction.Atack)
        {
            UltimoAtack = 0;
        }
        float Life = data.Life();
        /// is Dead is the last bescause dead is default
        bool isDead = (Life <= 0);
        if (isDead)
        {
            actualState = CharacterBotAction.Die;
        }

       

        // do action
        UpdateIAControll();
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    // here player just do some action according to you state
    void UpdateIAControll()//actuador
    {
        // do action
        if (actualState == CharacterBotAction.Patrol)
        {
          
            if(folowPath != null)
            {
                folowPath.FolowPath();
            }
            else
            {
                Walk(new Vector2(1, 0), 10);
            }
            AnimationSelectionID = 2;

        }
        else if (actualState == CharacterBotAction.Die)
        {
            CharacterAI.velocity = Vector2.zero;// stop ai

            Invoke("DestroyMe", 2);

        }

        else if (actualState == CharacterBotAction.Chase)
        {
            GameObject nearestPlayer;
            GetPlayerDistance( out nearestPlayer);

            Vector2 playerDistance = nearestPlayer.transform.position - gameObject.transform.position;
            CharacterAI.velocity = playerDistance * (float)data.CharacterVelocity();

            AnimationSelectionID = 2;

        }
        else if (actualState == CharacterBotAction.Atack  )
        {
            // move to player
            GameObject nearestPlayer;
            GetPlayerDistance(out nearestPlayer);

            Vector2 playerDistance = nearestPlayer.transform.position - gameObject.transform.position;
            CharacterAI.velocity = playerDistance * (float)data.CharacterVelocity();
            // noved to plaer

   
            AnimationSelectionID = 3;

            
            // this hold a atack for time of MaxDurationOfatack second
            if (Time.time > UltimoAtack + 0.0f && Time.time < UltimoAtack +  MaxdurationOfAtack)// time betwen 0 and maxDurationOfAtack second after atack
            {
                actualState = CharacterBotAction.Atack;
                AnimationSelectionID = 2;

            }
            // this give a time betwen last atack and next atack
            else if (Time.time >= UltimoAtack + MaxdurationOfAtack && Time.time < UltimoAtack + timeBetweenAtacks + MaxdurationOfAtack)// time between 1 and 1.5 after atack
            {
               
                actualState = CharacterBotAction.Chase;
            }
            else if(Time.time >= UltimoAtack + timeBetweenAtacks + MaxdurationOfAtack)// time after 1.5 after atack
            {
                UltimoAtack = Time.time;
                actualState = CharacterBotAction.Chase;
            }

        }
       
        else if (actualState == CharacterBotAction.Flee)
        {

            if(Time.time > RandomTime + 1)
            {// generate random direction to flee between > 1 second

                RandomTime = Time.time;
                float x = Random.Range(-5.0f, 5.0f);
                float y = Random.Range(-5.0f, 5.0f);


                RandomDirection = new Vector2(x,y)  ;


            }
            CharacterAI.velocity = RandomDirection * (float)data.CharacterVelocity();
            AnimationSelectionID = 2;

        }
        else if (actualState == CharacterBotAction.Idle)
        {
            AnimationSelectionID = 0;
            CharacterAI.velocity = Vector2.zero;// stop ai
            
        }
    }
}
