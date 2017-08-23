using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour {

	public float scale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			gameObject.transform.position += new Vector3(scale,0,0);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			gameObject.transform.position += new Vector3(-scale,0,0);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			gameObject.transform.position += new Vector3(0,scale,0);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			gameObject.transform.position += new Vector3(0,-scale,0);
		}
	}
}
