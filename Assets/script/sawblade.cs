using UnityEngine;
using System.Collections;

public class sawblade : MonoBehaviour {

	public float speed = 300;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			c.GetComponent<Entity>().TakeDamage(100);
			GameObject temp = Instantiate(Resources.Load("Prefabs/Soap Bubbles", typeof(GameObject)), c.transform.position, 
			                              Quaternion.identity) as GameObject;

			GameObject parent = (GameObject.Find("t1(Clone)") as GameObject);
			Destroy(this.gameObject, 1);
			Destroy(parent, 1);
			Destroy(temp, 3);

		}
		if (c.tag == "bullet") {

			Debug.Log("explose");
		}
	}
}
