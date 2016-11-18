using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	[SerializeField]
	private float _speed = 10f;

	public Transform OrginalPos;

	void Update()
	{
		transform.position = new Vector3(0f, 6f, OrginalPos.position.z);
		//transform.position = Vector3.Lerp(transform.position, OrginalPos.position, _speed*Time.fixedDeltaTime);
	}
}
