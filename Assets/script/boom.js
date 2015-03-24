#pragma strict
var explosion : Transform = null;  
function Start () {

}

function Update () {

}

function OnCollisionEnter(theCollision : Collision){
	print(theCollision.gameObject.name);
	if(theCollision.gameObject.name == "Ground"){
 
	}else{
		Instantiate(explosion, gameObject.transform.position, transform.rotation); 
		Destroy(theCollision.gameObject);
		Destroy(gameObject);
	
	}
}
