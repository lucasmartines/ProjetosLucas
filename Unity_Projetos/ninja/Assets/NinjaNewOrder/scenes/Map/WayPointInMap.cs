using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WayPointInMap : MonoBehaviour {

    public Transform wayPointOfNortthComand;// up arrow way point
    public Transform wayPointOfSouthComand;// south arrow way point
    public Transform wayPointOfLeftComand;// left arrow way point
    public Transform wayPointOfRightComand;// right arrow way point
    public Vector3 wayPointDirectionChoosed;// this is for me know if i chosed up downl left or right
    public Transform nextWayPoint;// this is in case of point of path not of "scene"
    public WayPointType waypoint;
    public string nomeUIMenuMapa;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D cl) {
        if (cl.transform.tag == "Player") {
            Debug.Log("Colision With player");

            WayPointController wpc = cl.gameObject.GetComponent<WayPointController>();
            wpc.ActualWayPoint = this;
            
            wayPointDirectionChoosed = Vector3.zero;

        }
    }

    void OnTriggerStay2D(Collider2D cl)
    {
        if (cl.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               // SceneManager.SetActiveScene(this.sc);
            }


        }
    }
}
