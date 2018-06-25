using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WayPointType { StartPoint, Path, Point }

public class WayPoint
{
    public Vector2 wayPointOfNortthComand;// up arrow way point
    public Vector2 wayPointOfSouthComand;// south arrow way point
    public Vector2 wayPointOfLeftComand;// left arrow way point
    public Vector2 wayPointOfRightComand;// right arrow way point


    public WayPointType waypoint;

    public WayPoint
    (Vector2 wayPointOfNortthComand,// up arrow way point
    Vector2 wayPointOfSouthComand,// south arrow way point
    Vector2 wayPointOfLeftComand,// left arrow way point
    Vector2 wayPointOfRightComand,// right arrow way point
    WayPointType waypoint
    )
    {
        this.wayPointOfNortthComand = wayPointOfNortthComand;
        this.wayPointOfSouthComand = wayPointOfSouthComand;
        this.wayPointOfLeftComand = wayPointOfLeftComand;
        this.wayPointOfRightComand = wayPointOfRightComand;
        this.waypoint = waypoint;
    }

    public WayPoint(WayPointType waypoint)
    {
        this.waypoint = waypoint;
    }
    public WayPoint()
    {
      
    }
}

/// <summary>
/// This waypoint controller is for character
/// </summary>
public class WayPointController : MonoBehaviour {

    public enum WayPointMachine { WALK,STOP}

    public WayPointInMap ActualWayPoint;


    public float magnitude;
    public float distance = 1;// magnitude of vector
    public Vector2 direction;
    public float velocity;// velocity in delta time
  //  public WayPoint [] waypoints;

    public WayPointMachine action = WayPointMachine.STOP;
    public Animator anim;
    public ElementTraductionController el;

    void Start () {
		
        // ler um arquivo com as waypoints[]
        //
        /*
        waypoints = new WayPoint[5];
        WayPoint tests = new WayPoint(WayPointType.Point);
        tests.wayPointOfLeftComand = new Vector2(-7.36f,-4.5f);





Visual Studio
        waypoints[0] = tests;
        tests.wayPointOfLeftComand = new Vector2(-2.02f, -4.74f);
        waypoints[1] = tests;
        */

        // carregar arquivo atual caso o player saia da faze então ele deve aparecer no respectivo waypoint
    //
	}
	
	// Update is called once per frame
	void Update () {
		
        

        // if distance is less that is player over targent and this targent is not part of path but the pole of player position
        // therefore if player is over "scene" ground he can select to go to another scene
        Vector2 distanceChangable = Vector2.zero;
        
        if (ActualWayPoint.wayPointDirectionChoosed != null)
        {
            // if way point is point it has a game screen 
            if(ActualWayPoint.waypoint == WayPointType.Point)
                 el.OfficialLanguageReference = ActualWayPoint.nomeUIMenuMapa;

            if (ActualWayPoint.wayPointDirectionChoosed != Vector3.zero )
            {

                distanceChangable = direction = (Vector2)ActualWayPoint.wayPointDirectionChoosed - (Vector2)transform.position;
            }
        }
        if (distanceChangable.magnitude < distance && ActualWayPoint.waypoint != WayPointType.Path)
        {
            // i an over scene ground
            action = WayPointMachine.STOP;
            ActualWayPoint.wayPointDirectionChoosed = Vector3.zero;
           

        }
        else if (distanceChangable.magnitude < distance && ActualWayPoint.waypoint == WayPointType.Path)
        {
            if (direction.y > 0)
            {

                direction = (Vector2)ActualWayPoint.wayPointOfNortthComand.position - (Vector2)transform.position;
            }

            if (direction.y < 0)
            {

                direction = (Vector2)ActualWayPoint.wayPointOfSouthComand.position - (Vector2)transform.position;
            }
           
            action = WayPointMachine.WALK;
        }

        if (action == WayPointMachine.STOP)
        {
            KeyBoardInput();

            anim.SetFloat("vertical", 0);
            anim.SetFloat("horizontal", 0);
        }
        if (action == WayPointMachine.WALK)  //action real
        {
            transform.Translate(direction * velocity * Time.deltaTime);

            anim.SetFloat("vertical", direction.y);
            anim.SetFloat("horizontal", direction.x);
        }


        magnitude = distanceChangable.magnitude;



    }
    void KeyBoardInput()
    {

        float hor = InputManager.PovHorizontal();
        float vert = InputManager.PovVertical();


        if (Input.GetKeyDown(KeyCode.UpArrow) || vert > 0)
        {

            if (ActualWayPoint.wayPointOfNortthComand != null)
            {
                ActualWayPoint.wayPointDirectionChoosed = ActualWayPoint.wayPointOfNortthComand.position;
                direction = (Vector2)ActualWayPoint.wayPointOfNortthComand.position - (Vector2)transform.position;
                action = WayPointMachine.WALK;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || vert < 0)
        {
            if (ActualWayPoint.wayPointOfSouthComand != null)
            {
                ActualWayPoint.wayPointDirectionChoosed = ActualWayPoint.wayPointOfSouthComand.position;

                direction = (Vector2)ActualWayPoint.wayPointOfSouthComand.position - (Vector2)transform.position;
                action = WayPointMachine.WALK;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || hor < 0 )
        {
            if (ActualWayPoint.wayPointOfLeftComand != null)
            {
                ActualWayPoint.wayPointDirectionChoosed = ActualWayPoint.wayPointOfLeftComand.position;

                direction = (Vector2)ActualWayPoint.wayPointOfLeftComand.position - (Vector2)transform.position;
                action = WayPointMachine.WALK;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || hor > 0 )
        {
            if (ActualWayPoint.wayPointOfRightComand != null)
            {
                ActualWayPoint.wayPointDirectionChoosed = ActualWayPoint.wayPointOfRightComand.position;
                action = WayPointMachine.WALK;
                direction = (Vector2)ActualWayPoint.wayPointOfRightComand.position - (Vector2)transform.position;
            }
        }


    }
}
