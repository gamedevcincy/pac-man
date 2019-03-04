using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Player{
public class PlayerController : MonoBehaviour {

	//public SphereCollider s = GetComponent<SphereCollider> ();
	private Player player; 


	public static Player GetPlayer(){
		return Player;
	}
	// Use this for initialization
	void Start () {
		player = new Player ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.Lives == 0) {
			Application.Quit();
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Steve") {
			player.Lives = player.Lives - 1;
		}
	}
}
}