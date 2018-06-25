using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowPathScript : MonoBehaviour {
    public enum KindOfMovment { GoAndBack,FolowRing,GoJustOneTime}
    public KindOfMovment kindOfMovment;
	public Transform [] Paths;
	public int ActualTransformID;
    /// <summary>
    ///  Lenght of points in a path vector
    /// </summary>
    int PathSize;
	public float Velocity;
    public int incrementer = 1;//public for debug
	public Rigidbody2D rb { get; set; }
    /// <summary>
    ///  this function is when you want to execute the folow path here instead of outside of this script
    /// </summary>
    public bool ExecuteFolowPath;
	// Use this for initialization
	void Start () {
		ActualTransformID = 0;
		rb = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {



        if (ExecuteFolowPath)
            FolowPath();
	}
	public void AddPath(Transform[] paths){
		Paths = paths;

	}
    /// <summary>
    /// This function get the children of one object as points of path
    /// </summary>
    /// <param name="pathParent"></param>
    public void GetPathInChildren(GameObject pathParent)
    {
        Paths = pathParent.GetComponentsInChildren<Transform>();
    }
	public Transform [] GetPath(){
		return Paths;
	}
	public void FolowPath()
	{
		if (Paths != null) 
		{
			
			PathSize = Paths.Length;

			Transform ActualTransform = Paths [ActualTransformID];

			Vector2 Distance = ActualTransform.position - transform.position  ;

            // if nearly a point just turn to another point
            if(kindOfMovment == KindOfMovment.FolowRing)
                if (Distance.magnitude <= 0.2f && ActualTransformID < PathSize) {
				    ActualTransformID++;

				    if (ActualTransformID >= PathSize) {
					    ActualTransformID = 0;
				    }

				    ActualTransform = Paths [ActualTransformID];
			    }
            if (kindOfMovment == KindOfMovment.GoAndBack)
            {
                if (Distance.magnitude <= 0.2f && ActualTransformID < PathSize)
                {
                   

                    if (ActualTransformID >= PathSize - 1 || ActualTransformID <= 0)
                    {
                        //ActualTransformID = 0;
                        incrementer = incrementer * -1;
                    }

                    ActualTransformID += incrementer;

                    ActualTransform = Paths[ActualTransformID];
                }
            }
            if (kindOfMovment == KindOfMovment.GoJustOneTime)
            {
                if (Distance.magnitude <= 0.2f && ActualTransformID < PathSize)
                {
                    ActualTransformID++;

                    if (ActualTransformID >= PathSize)
                    {
                        ActualTransformID = PathSize - 1;
                        ExecuteFolowPath = false;
                        rb.velocity = Vector2.zero;
                    }

                    ActualTransform = Paths[ActualTransformID];
                }
            }


                // fowlo path
                if (Distance.magnitude > 0.2f) {

				Vector2 DirectionNextPoint = ActualTransform.position - transform.position;

				DirectionNextPoint.Normalize ();
				rb.velocity = DirectionNextPoint * Velocity;
			} 
		}


	}

}
