using UnityEngine;
using System.Collections;

public class saw : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider c) {
		if (c.tag == "bullet") {
			Destroy(this.gameObject);
		}
	}
}
