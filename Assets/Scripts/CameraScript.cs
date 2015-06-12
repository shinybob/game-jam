using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	public Transform target;
	public float minDistance;
	public float maxDistance;
	public float angle;
	
	private float _currentDistance;

	void Start() {
		_currentDistance = 20;
	}
	
	void LateUpdate () {
		if (!target) return;
		
		float targetDistance = target.GetComponent<Rigidbody>().velocity.magnitude * 2;
		if(targetDistance < minDistance) targetDistance = minDistance;
		if(targetDistance > maxDistance) targetDistance = maxDistance;

		_currentDistance = Mathf.Lerp (_currentDistance, targetDistance, 0.8f * Time.deltaTime);

		float yPos = target.position.y - (target.GetComponent<Rigidbody>().velocity.y / 2) + angle;
		float xPos = target.position.x - (target.GetComponent<Rigidbody>().velocity.x / 2);

		
		var currentPosition = new Vector3(xPos, yPos, target.position.z);
		currentPosition -= Vector3.forward * _currentDistance;
		
		transform.position = currentPosition;
		transform.LookAt (target);
	}
}