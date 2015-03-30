using UnityEngine;
using System.Collections;

public class sawblade : MonoBehaviour {

	public float speed = 300;
	public Transform explosion;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			c.GetComponent<Entity>().TakeDamage(100);
			/*
			GameObject temp = Instantiate(Resources.Load("Prefabs/Soap Bubbles", typeof(GameObject)), c.transform.position, 
			                              Quaternion.identity) as GameObject;
			*/

		}
		if (c.tag == "bullet") {
			Instantiate(Resources.Load("Prefabs/explosion", typeof(GameObject)), c.transform.position, 
			            Quaternion.identity);
			Destroy(this.gameObject);
			Destroy(c.gameObject);
		}
	}
}
