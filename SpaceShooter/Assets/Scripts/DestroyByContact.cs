﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start() {
		GameObject controllerObj = GameObject.FindWithTag ("GameController");
		if (controllerObj != null) {
			gameController = controllerObj.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Boundary")) {
			return;
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.CompareTag ("Player")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		} else {
			gameController.AddScore (scoreValue);
		}
	}
}
