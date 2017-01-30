using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		Destroy (other.gameObject);
	}
}
