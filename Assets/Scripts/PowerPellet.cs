using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PowerPellet : MonoBehaviour {
	public int value{ get; set;}

	// Use this for initialization
	void Start () {
		value = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		Player obj = GameObject.Find ("Player") as Player;

		if (col.gameObject.name == "Player") {
			// Destroy (this);
			obj.Points = obj.Points + value;
			System.Console.WriteLine (obj.Points);
		}
	}
}
