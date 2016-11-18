using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow))
			
			anim.Play ("RUN_Anim", -1, 0f);
	}
}
