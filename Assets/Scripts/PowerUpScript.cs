using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	[SerializeField]
	private float _speed = -1;



	// Use this for initialization
	void Start () {
		if(_speed == -1) Debug.LogError(gameObject.name + "has no power selected");
	}

	public void Activate(GameObject player) {
		player.GetComponent<PlayerController>().SetSpeed(_speed);
	}

}
