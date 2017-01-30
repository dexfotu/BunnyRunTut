using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BunnyController : MonoBehaviour {

	private Rigidbody2D myRigidbody;
	private Animator myAnim;
	public float bunnyJumpForce = 500f;
	private float bunnyHurtTime = -1;
	private Collider2D myCollider;
	public Text scoreText;
	private float startTime;

	// Use this for initialization
	void Start () {
	
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		myCollider = GetComponent<Collider2D> ();

		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

		if (bunnyHurtTime == -1) {

			if (Input.GetButtonUp("Fire1")||Input.GetButtonUp ("Jump")) {
		
				myRigidbody.AddForce (transform.up * bunnyJumpForce);
			}

			myAnim.SetFloat ("vVelocity", myRigidbody.velocity.y);
			scoreText.text = (Time.time - startTime).ToString ("0.0");

		} else {
			if (Time.time > bunnyHurtTime + 2) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
	
		if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")){


			foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>()) {
				spawner.enabled = false;
			}

			foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>()) {
				moveLefter.enabled = false;
			}

			bunnyHurtTime = Time.time;
			myAnim.SetBool ("bunnyHurt", true);
			myRigidbody.velocity = Vector2.zero;
			myRigidbody.AddForce (transform.up * bunnyJumpForce);
			myCollider.enabled = false;
		}
	
	}
}
