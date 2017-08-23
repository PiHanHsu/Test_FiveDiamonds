using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloating : MonoBehaviour {

	public float speedX;
	public float speedY;

	public float MaxX;
	public float MinX;
	public float MaxY;
	public float MinY;

	private float time;
	private float period;
	private float movingX;
	private float movingY;

	// Use this for initialization
	void Start () {
		period = Random.Range (2, 4);
		movingX = speedX;
		movingY = speedY;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > period) {
			movingX *= -1;
			time = 0;
			period = Random.Range (2, 4);
		}

		this.gameObject.transform.position += new Vector3 (movingX, movingY, 0);
		if (this.gameObject.transform.position.x > MaxX || this.gameObject.transform.position.x < MinX) {
			movingX *= -1;
			time = 0;
		}

		if (this.gameObject.transform.position.y > MaxY || this.gameObject.transform.position.y < MinY) {
			movingY *= -1;
			time = 0;
		}
		
	}
}
