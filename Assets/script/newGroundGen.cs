using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class newGroundGen : MonoBehaviour {

	private GameObject player;

	public GameObject[] groundCollection;

	private Queue<GameObject> groundDestoryer = new Queue<GameObject>();
	private GameObject groundPos;
	private GameObject temp;
	private float groundWidth = 2.0f;
	private float startUpPosY;
	private int heightLevel = 0;
	private int groundSize = 0;


	// Use this for initialization
	void Start () {
		groundPos = GameObject.Find ("startGround");
		player = GameObject.Find ("player(Clone)");
		startUpPosY = groundPos.transform.position.y;
		fillScene ();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (player.transform.position.x > groundPos.transform.position.x - 15) {
			fillScene();
		}

		if (groundSize > 50) {
			for(int i = 0; i < 10; i++) {
				Destroy(groundDestoryer.Dequeue().gameObject);
			}
			groundSize -= 10;
		}


	}

	void OnGUI() {
		if (player.transform.position.y < groundPos.transform.position.y - 4) {
			GUI.Label(new Rect(Screen.width/2-40, 50, 80, 30), "Game Over");
			if(GUI.Button(new Rect(Screen.width/2-30, 100, 60, 30), "Retry?")) {
				Application.LoadLevel(0);
			}
		}
	}

	private void fillScene() {
		int groundCount = Random.Range(8, 20);
		for (int i = 0; i < groundCount; i++) {
			groundSize++;
			temp = Instantiate (groundCollection[Random.Range(1, 3)], 
			                    new Vector2 (groundPos.transform.position.x+groundWidth, startUpPosY+(heightLevel*groundWidth)), 
			                    Quaternion.identity) as GameObject;
			groundDestoryer.Enqueue(temp);

			groundPos = temp;
		}

		int blankCount = Random.Range (2, 4);
		for (int i = 0; i < blankCount; i++) {
			groundSize++;
			temp = Instantiate (groundCollection[0], 
			                    new Vector2 (groundPos.transform.position.x+groundWidth, startUpPosY+(heightLevel*groundWidth)), 
			                    Quaternion.identity) as GameObject;
			groundDestoryer.Enqueue(temp);
			
			groundPos = temp; 
		}

		changeHeight ();

	}


	private void changeHeight() {
		int newHeightLevel = (int)Random.Range (0, 4);
		if (newHeightLevel < heightLevel) {
			heightLevel--;
		} else if (newHeightLevel > heightLevel){
			heightLevel++;
		}
	}
}
