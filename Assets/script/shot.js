#pragma strict

function Start () {
	
}

var speed : int = 5;
var newObject : Transform;

function Update () {

	
	if (Input.GetKeyDown(KeyCode.Z)){
		var bullet : Transform = Instantiate(newObject,transform.position,transform.rotation);
		var forward : Vector3 = transform.TransformDirection(Vector3.right);
		bullet.rigidbody.AddForce(forward*1500);
	}

	
	
}