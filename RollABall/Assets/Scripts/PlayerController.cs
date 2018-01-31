using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate() {
		float motionHorizontal = Input.GetAxis ("Horizontal");
		float motionVertical = Input.GetAxis ("Vertical");

		Vector3 motion = new Vector3 (motionHorizontal, 0, motionVertical);

		rb.AddForce (motion * speed);
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			if (count >= 10) {
				winText.text = "You Win!";
			}
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString ();
	}
}
