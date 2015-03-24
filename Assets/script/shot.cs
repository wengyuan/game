using UnityEngine;
using System.Collections;

public class shot : MonoBehaviour {

	public Rigidbody projectile;
	private GameObject currentPlayer;
	
	public float speed = 20;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentPlayer = GameObject.Find ("player(Clone)");
		if (Input.GetButtonDown("Fire1"))
		{
			Rigidbody instantiatedProjectile = Instantiate(projectile,
			                                               currentPlayer.transform.position,
			                                               currentPlayer.transform.rotation)
				as Rigidbody;
			
			instantiatedProjectile.AddForce(transform.forward*2800);
			
		}
	}
}
