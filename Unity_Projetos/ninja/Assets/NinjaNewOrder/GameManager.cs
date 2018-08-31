using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool isPaused;
    public bool PermisionForPause;


    public enum GameState { youwin, gameover, fight, adventure, speaking }
    [SerializeField] static GameState state;


    public static GameState State{ get { return state; }set { state = value; } }
   
    [SerializeField] GameState ShowGameState;

    void Start () {
        Screen.SetResolution(1280, 720, true, 60);
        isPaused = false;
        state = GameState.adventure;
	}

    private void Update()
    {
        ShowGameState = state;

        if (PermisionForPause) { 

            // switch between pause
            if (InputManager.Pause(false))
            {
                isPaused = !isPaused;
            
            }
        }


        if(State == GameState.youwin)
        {
            

        }
        else if (State == GameState.adventure)
        {


        }
        else if (State == GameState.fight)
        {


        }
        else if (State == GameState.gameover)
        {


        }
        else if (State == GameState.speaking)
        {


        }
    }
    public void PauseGame()
    {
        isPaused = !isPaused;
    }
}
