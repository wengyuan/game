#pragma strict

function Start () {
	
}

var speed : int = 5;
var newObject : Transform;

function Update () {
	
	if (Input.GetKey(KeyCode.Z)){
		var bullet : Transform = Instantiate(newObject,transform.position,transform.rotation);
		var forward : Vector3 = transform.TransformDirection(Vector3.forward);
		bullet.rigidbody.AddForce(forward*2800);
	}

	
	
}