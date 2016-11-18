using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float _forwardSpeed = 10.0f;
	private float _horizontalSpeed = 8f;
	[SerializeField]
	private float _gravity = 1.5f;
	[SerializeField]
	private float _jumpPower = 0f;
	[SerializeField]
	private float _godModeTime = 0f; //if hit by object you dont get hit again

	private GameController _gameController;
    private int _shieldActive;
	private float _minJumpPower = -1f;
	private bool _canJump = false;
	private float _score = 0;

	// Use this for initialization
	void Start () {
		_gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		gameObject.tag = "Player";
		_shieldActive = 0;
	}
	
	// Update is called once per frame
	void Update () {
		AnimationHandler ();
		Movement ();
		Controls();

		_score += (_forwardSpeed / 10f)*Time.deltaTime;
		if(_godModeTime > 0f) {
			_godModeTime -= 1f * Time.fixedDeltaTime;
		}
	}

	private void AnimationHandler(){

	}

	private void Controls() {
		if (Input.GetAxis("Fire1") > 0) {
			
		}

		if ((Input.GetKeyDown(KeyCode.Space)) && _canJump) {
			_jumpPower = 0.5f;
			_canJump = false;
		}
		if (Input.touchCount > 0) {
			if (Input.GetTouch(0).phase == TouchPhase.Began && _canJump) {
				_jumpPower = 0.5f;
				_canJump = false;
			}
		}
	}

	private void Movement(){
		if(_jumpPower > _minJumpPower && !_canJump) _jumpPower -= _gravity*Time.fixedDeltaTime;
		Ray ray = new Ray(transform.position, -Vector3.up);
		if (Physics.Raycast(ray, 1f))
		{
			_jumpPower = 0f;
			_canJump = true;
		}

		//Movement for jumping/moving forward/left right
		transform.Translate((Input.GetAxis("Horizontal")* _horizontalSpeed) *Time.fixedDeltaTime, _jumpPower, _forwardSpeed*Time.fixedDeltaTime);
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "PowerUp") {
			coll.GetComponent<PowerUpScript>().Activate(this.gameObject);
		}

		if(coll.tag == "EndPart") {
			_gameController.CreateLevel();
			Destroy(coll.transform.parent.gameObject,1f);
			_forwardSpeed *= 1.05f;
		}

		if (coll.gameObject.tag == "Obstacle" && _godModeTime < 0.1f) {
			if (_shieldActive < 0) {
				//GameOver
				_gameController.GameOver(Mathf.RoundToInt(_score));
				Debug.Log("Game over!");
			} else {
				_godModeTime = 1f;
				_shieldActive -= 1;

				Debug.Log("hit obstacle");
			}
		}
	}

	public void SetSpeed(float i) {
		_forwardSpeed *= i;
		_horizontalSpeed *= i;
	}
}
