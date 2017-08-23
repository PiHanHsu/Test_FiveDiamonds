using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

	public float MovingX;
	public float MovingY;

	public float MaxX;
	public float MinX;
	public float MaxY;
	public float MinY;

	public bool bounce;
	public bool floatOut;

	// Use this for initialization
	void Start () {
		if (MaxX == 0 && MinX == 0) {
			MaxX = 9;
			MinX = -9;
		}

		if (MaxY == 0 && MinY == 0) {
			MaxY = 5;
			MinY = -5;
		}

	}

	// Update is called once per frame
	void Update () {

		if (floatOut) {
			if (this.gameObject.transform.position.y >= MaxY) {
				this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, MinY, 0);
			}
		}

		if (bounce) {
			if (this.gameObject.transform.position.x > MaxX) {
				this.gameObject.transform.position = new Vector3 (MaxX, this.gameObject.transform.position.y, 0);
				MovingX = Mathf.Abs (MovingX) * -1;
			}

			if (this.gameObject.transform.position.x < MinX) {
				this.gameObject.transform.position = new Vector3 (MinX, this.gameObject.transform.position.y, 0);
				MovingX = Mathf.Abs (MovingX);
			}

			if (this.gameObject.transform.position.y > MaxY) {
				this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, MaxY, 0);
				MovingY = Mathf.Abs (MovingY) * -1;
			}

			if (this.gameObject.transform.position.y < MinY) {
				this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, MinY, 0);
				MovingY = Mathf.Abs (MovingY);
			}

			this.gameObject.transform.position += new Vector3 (MovingX, MovingY, 0);

		} else {

			if (this.gameObject.transform.position.x > MaxX) {
				this.gameObject.transform.position = new Vector3 (MinX, this.gameObject.transform.position.y, 0);
			}

			if (this.gameObject.transform.position.x < MinX) {
				this.gameObject.transform.position = new Vector3 (MaxX, this.gameObject.transform.position.y, 0);
			}

			if (this.gameObject.transform.position.y > MaxY) {
				this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, MinY, 0);
			}

			if (this.gameObject.transform.position.y < MinY) {
				this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, MaxY, 0);
			}

			this.gameObject.transform.position += new Vector3 (MovingX, MovingY, 0);
		}
	}
}
