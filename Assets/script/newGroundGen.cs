using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class newGroundGen : MonoBehaviour {

	private GameObject player;
	public GameObject playerInstance;

	public GameObject[] groundCollection;

	private Queue<GameObject> groundDestoryer = new Queue<GameObject>();
	private GameObject groundPos;
	private GameObject temp;
	private float groundWidth = 2.0f;
	private float startUpPosY;
	private int heightLevel = 0;
	private int groundSize = 0;

	private GameManager manager;

	// Use this for initialization
	void Start () {
		groundPos = GameObject.Find ("startGround");
		startUpPosY = groundPos.transform.position.y;
		manager = Camera.main.GetComponent<GameManager>();
		fillScene ();
	}
	// Update is called once per frame
	void FixedUpdate() {
		player = GameObject.Find ("player(Clone)");
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
		player = GameObject.Find ("player(Clone)");
		GUI.Label(new Rect(10, 10, 100, 100), "Health: " + player.GetComponent<Entity>().health.ToString());
		if (player.transform.position.y < groundPos.transform.position.y - 4 || player.GetComponent<Entity>().health <= 0) {
			player.GetComponent<PlayerController>().speed = 0;
			player.GetComponent<PlayerController>().jumpHeight = 0;
			player.renderer.enabled = false;
			GUI.Label(new Rect(Screen.width/2-40, 50, 80, 30), "Game Over");
			if(GUI.Button(new Rect(Screen.width/2-30, 100, 60, 30), "Retry?")) {
				Application.LoadLevel(0);
				manager.currentLevel = 0;
			}
		}
	}

	private void fillScene() {

		int groundCount = Random.Range(5, 15);
		int ran = Random.Range(5, 7);
		for (int i = 0; i < groundCount; i++) {
			groundSize++;
			temp = Instantiate (groundCollection[Random.Range(1, 3)], 
			                    new Vector2 (groundPos.transform.position.x+groundWidth, startUpPosY+(heightLevel*groundWidth)), 
			                    Quaternion.identity) as GameObject;
			groundDestoryer.Enqueue(temp);
			if(groundCount > 9 && i == ran) {
				Instantiate (groundCollection[4], 
				                    new Vector2 (groundPos.transform.position.x+groundWidth, startUpPosY+(1+heightLevel*groundWidth)), 
				                    Quaternion.Euler(0, 90, 0));
			}

			groundPos = temp;
		}

		int blankCount = Random.Range (1, 4);
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
