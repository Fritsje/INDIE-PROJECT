var forwardspeed : float = 0.022;
var right : float = -1;
var left : float = 1;


function Update () {

if(Input.GetKey("w")) {

	gameObject.transform.Translate(0,0,forwardspeed);

	}

	if (Input.GetKey("a")) {
	
		gameObject.transform.Rotate(0, right, 0);
	
	}
	
	if (Input.GetKey("d")) {
	
		gameObject.transform.Rotate(0, left, 0);
	
	}
}