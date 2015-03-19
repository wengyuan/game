using UnityEngine;
using System.Collections;

public class mapCreator : MonoBehaviour {

	public GameObject obj;
	public float speed = 6;
	public float accTime = 0;

	void Start() {
		Spawn ();
	}

	void Spawn() {
		accTime += Time.deltaTime;
		if(accTime > 5) {
			accTime = 0;
			speed*=2;
		}
		Instantiate (obj, transform.position, Quaternion.identity);
		Invoke ("Spawn", ((10/speed))); //spawn
	}
}
