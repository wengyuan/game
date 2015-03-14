using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class groundGenerator : MonoBehaviour {

	private GameObject groundPos;
	private float startUpPosY;
	private const float groundWidth = 2.0f;
	private int heightLevel = 0;
	private GameObject tempGround;

	private GameObject collectedGround;
	private GameObject gameLayer;
	private GameObject bgLayer;

	private float gameSpeed = 2.0f;
	private float outofbounceX;
	private int blankCounter = 0;
	private int middleCounter = 0;
	private string lastGround = "large";

	void Start() {

		gameLayer = GameObject.Find ("gameLayer");
		bgLayer = GameObject.Find ("backgroundLayer");
		collectedGround = GameObject.Find ("groundType");

		for (int i = 0; i < 21; i++) {
			GameObject tmpg1 = (Instantiate(Resources.Load("Prefabs/smallGround", typeof(GameObject)))) as GameObject;
			tmpg1.transform.parent = collectedGround.transform.FindChild("small").transform;

			GameObject tmpg2 = (Instantiate(Resources.Load("Prefabs/midGround", typeof(GameObject)))) as GameObject;
			tmpg2.transform.parent = collectedGround.transform.FindChild("middle").transform;

			GameObject tmpg3 = (Instantiate(Resources.Load("Prefabs/largeGround", typeof(GameObject)))) as GameObject;
			tmpg3.transform.parent = collectedGround.transform.FindChild("large").transform;

			GameObject tmpg4 = (Instantiate(Resources.Load("Prefabs/blankGround", typeof(GameObject)))) as GameObject;
			tmpg4.transform.parent = collectedGround.transform.FindChild("blank").transform;

		}


		collectedGround.transform.position = new Vector2 (-200.0f, -100.0f);
		groundPos = GameObject.Find ("startGround");
		startUpPosY = groundPos.transform.position.y;

		outofbounceX = groundPos.transform.position.x - 5.0f;

		fillScene ();
	}

	void FixedUpdate() {
		gameLayer.transform.position = new Vector2 (gameLayer.transform.position.x - gameSpeed * Time.deltaTime, 0);
		bgLayer.transform.position = new Vector2 (bgLayer.transform.position.x - gameSpeed/4 * Time.deltaTime, 0);

		foreach(Transform child in gameLayer.transform) {
			if(child.position.x < outofbounceX) {
				switch (child.gameObject.name) {
				case "smallGround(Clone)":
					child.gameObject.transform.position = collectedGround.transform.FindChild("small").transform.position;
					child.gameObject.transform.parent = collectedGround.transform.FindChild("small").transform;
					break;
				case "midGround(Clone)":
					child.gameObject.transform.position = collectedGround.transform.FindChild("middle").transform.position;
					child.gameObject.transform.parent = collectedGround.transform.FindChild("middle").transform;
					break;
				case "largeGround(Clone)":
					child.gameObject.transform.position = collectedGround.transform.FindChild("large").transform.position;
					child.gameObject.transform.parent = collectedGround.transform.FindChild("large").transform;
					break;
				case "blankGround(Clone)":
					child.gameObject.transform.position = collectedGround.transform.FindChild("blank").transform.position;
					child.gameObject.transform.parent = collectedGround.transform.FindChild("blank").transform;
					break;
				default:
					Destroy(child.gameObject);
					break;
					
				}


			}
		}

		if (gameLayer.transform.childCount < 25)
						spawnGround ();
	
	}

	private void fillScene() {
		for (int i = 0; i < 15; i++) {
			setGround("middle");
		}
		setGround ("large");
	}


	public void setGround(string type) {
		switch (type) {
		case "small":
			tempGround = collectedGround.transform.FindChild("small").transform.GetChild(0).gameObject;
			break;
		case "middle":
			tempGround = collectedGround.transform.FindChild("middle").transform.GetChild(0).gameObject;
			break;
		case "large":
			tempGround = collectedGround.transform.FindChild("large").transform.GetChild(0).gameObject;
			break;
		case "blank":
			tempGround = collectedGround.transform.FindChild("blank").transform.GetChild(0).gameObject;
			break;

		}


		tempGround.transform.parent = gameLayer.transform;
		tempGround.transform.position = new Vector2 (groundPos.transform.position.x+groundWidth, 
		                                             startUpPosY+(heightLevel*groundWidth));

		groundPos = tempGround;    
		lastGround = type;
	}

	private void spawnGround() {

		if (blankCounter > 0) {
			setGround ("blank");
			blankCounter--;
			return;
		}
		if (middleCounter > 0) {
			setGround("middle");
			middleCounter--;
		}

		if (lastGround == "blank") {
			changeHeight ();
			setGround ("small");
			middleCounter = (int)Random.Range (1, 8);
		} else if (lastGround == "large") {
			blankCounter = (int)Random.Range (2, 4);
		} else if (lastGround == "middle") {
			setGround("large");
		}
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
