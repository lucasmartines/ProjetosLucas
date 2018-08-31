using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraFollow : MonoBehaviour {
	public GameObject FollowMe;
	public int offset;

	public bool useOffset;
	// Use this for initialization
	public float MaxOffsetX;
	public float MaxOffsetY;

	float offsetX;
	float offsetY;
	/// <summary>
	/// Image of transiction
	/// </summary>
	void Start () {
		
	}
	
	/// <summary>
	/// Center camera when he moves beyond the offset
	/// and when camera get off offset, it follow player
	/// </summary>

	void Update () {



		if (useOffset) {
			transform.position = new Vector3 (FollowMe.transform.position.x, FollowMe.transform.position.y, transform.position.z);
		}
		else {
			offsetX =  FollowMe.transform.position.x -transform.position.x ;
			offsetY =  FollowMe.transform.position.y -transform.position.y ;

		
			if (offsetX < -MaxOffsetX) {
				offsetX = -MaxOffsetX;
				transform.localPosition = new Vector3 (FollowMe.transform.localPosition.x +( offsetX * -1) , FollowMe.transform.localPosition.y + (offsetY * -1 ), transform.localPosition.z);
			}
			if (offsetX > MaxOffsetX) {
				offsetX = MaxOffsetX;
				transform.localPosition = new Vector3 (FollowMe.transform.localPosition.x +( offsetX * -1), FollowMe.transform.localPosition.y + (offsetY * -1 ), transform.localPosition.z);
			}
			if (offsetY < -MaxOffsetY) {
				offsetY = -MaxOffsetY ;
				transform.localPosition = new Vector3 (FollowMe.transform.localPosition.x +( offsetX * -1) , FollowMe.transform.localPosition.y + (offsetY * -1 ) , transform.localPosition.z);
			}
			if (offsetY > MaxOffsetY) {
				offsetY = MaxOffsetY;
				transform.localPosition = new Vector3 (FollowMe.transform.localPosition.x+( offsetX * -1 ), FollowMe.transform.localPosition.y + (offsetY * -1 ), transform.localPosition.z);
			}
		}
	}
}
