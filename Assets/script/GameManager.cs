using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject player;
	private GameObject currentPlayer;
	private GameCamera cam;
	private Vector3 checkpoint;

	public static int levelCount = 1;
	public int currentLevel = 0;
	
	void Start () {
		cam = GetComponent<GameCamera>();

		if (GameObject.FindGameObjectWithTag ("Spawn")) {
			checkpoint = GameObject.FindGameObjectWithTag("Spawn").transform.position;		
		}
		SpawnPlayer(checkpoint);
	}
	
	// Spawn player
	public void SpawnPlayer(Vector3 spawnPos) {
		currentPlayer = Instantiate(player, spawnPos,  Quaternion.identity) as GameObject	;
		cam.SetTarget(currentPlayer.transform);
	}

	private void Update() {
		if (!currentPlayer) {
			if (Input.GetButtonDown ("Respawn")) {
				SpawnPlayer (checkpoint);
			}
		}
	}

	public void SetCheckPoint(Vector3 cp) {
		checkpoint = cp;
	}

	public void EndLevel() {
		currentLevel++;
		if (currentLevel < levelCount) {
			Application.LoadLevel (currentLevel);
		} else {
			Debug.Log ("Mission Completed");			
		}
	}
}
