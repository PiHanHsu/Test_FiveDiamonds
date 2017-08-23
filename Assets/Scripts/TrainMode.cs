using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMode : MonoBehaviour {

	public float Speed;

	public float MaxX;
	public float MinX;
	public float MaxY;
	public float MinY;

	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;

		if (x == MaxX || x == MinX || y == MaxY || y == MinY) {
		} else {
			float gapToMaxX = Mathf.Abs (x - MaxX);	
			float gapToMinX = Mathf.Abs (x - MinX);	
			float gapToMaxY = Mathf.Abs (y - MaxY);	
			float gapToMinY = Mathf.Abs (y - MinY);	
			float minGap = Mathf.Min (gapToMaxX, gapToMaxY, gapToMinX, gapToMinY);
			if (minGap == gapToMaxX) {
				gameObject.transform.position = new Vector3 (MaxX, y, 0);
			} else if (minGap == gapToMinX) {
				gameObject.transform.position = new Vector3 (MinX, y, 0);
			} else if (minGap == gapToMaxY) {
				gameObject.transform.position = new Vector3 (x, MaxY, 0);
			} else if (minGap == gapToMinY) {
				gameObject.transform.position = new Vector3 (x, MinY, 0);
			} 
		}
			

		if (Speed > 0) {
			
			if (x <= MinX && y < MaxY ) {
				gameObject.transform.position = new Vector3 (MinX, y, 0); 
				gameObject.transform.position += new Vector3 (0, Speed, 0);
			}	

			if (x >= MaxX && y > MinY) {
				gameObject.transform.position = new Vector3 (MaxX, y, 0); 
				gameObject.transform.position -= new Vector3 (0, Speed, 0);
			}

			if (y >= MaxY && x < MaxX) {
				gameObject.transform.position = new Vector3 (x, MaxY, 0); 
				gameObject.transform.position += new Vector3 (Speed, 0, 0);
			}

			if (y <= MinY && x > MinX) {
				gameObject.transform.position = new Vector3 (x, MinY, 0); 
				gameObject.transform.position -= new Vector3 (Speed, 0, 0);
			}
		} 

		if (Speed < 0){
			
			if (x <= MinX && y > MinY ) {
				gameObject.transform.position = new Vector3 (MinX, y, 0); 
				gameObject.transform.position += new Vector3 (0, Speed, 0);
			}	

			if (x >= MaxX && y < MaxY) {
				gameObject.transform.position = new Vector3 (MaxX, y, 0); 
				gameObject.transform.position -= new Vector3 (0, Speed, 0);
			}

			if (y >= MaxY && x > MinX) {
				gameObject.transform.position = new Vector3 (x, MaxY, 0); 
				gameObject.transform.position += new Vector3 (Speed, 0, 0);
			}

			if (y <= MinY && x < MaxX) {
				gameObject.transform.position = new Vector3 (x, MinY, 0); 
				gameObject.transform.position -= new Vector3 (Speed, 0, 0);
			}
		}
		gameObject.transform.rotation = new Quaternion ();


	}
}
