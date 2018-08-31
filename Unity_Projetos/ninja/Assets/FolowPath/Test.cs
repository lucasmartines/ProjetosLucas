using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public int atual;
	public GameObject [] todos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		for ( int atualID = 0;atualID < todos.Length ; atualID ++) {

			if (atual == atualID) {
				todos [atualID].SetActive (true);
			} else {
				todos [atualID].SetActive (false);
			}

		}

	}
}
