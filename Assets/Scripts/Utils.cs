using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour
{
	public static bool isTouchControls() {
		bool touchControls = true;
		
		if(	Application.platform == RuntimePlatform.OSXEditor ||
		   	Application.platform == RuntimePlatform.OSXWebPlayer ||
		   	Application.platform == RuntimePlatform.OSXPlayer ||
		   	Application.platform == RuntimePlatform.OSXDashboardPlayer) {
			touchControls = false;
		}
		
		return touchControls;
	}
	
	public static void applyAttraction(Transform main, Transform target, float strength, float triggerDistance, bool useLineOfSight) {		
		float distance = Vector3.Distance(main.position, target.position);
		
		if(distance < triggerDistance) {
			if(!useLineOfSight || Utils.isLineOfSight(main, target)) {
				float strengthMultiplier = (triggerDistance - distance);
				float force = strength * strengthMultiplier;
				Vector3 difference = target.position - main.position;
				
				if(main.GetComponent<Rigidbody>() != null) main.GetComponent<Rigidbody>().AddForce(difference.normalized * force);
			}
		}	
	}
	
	public static void applyLookAt(Transform main, Transform target, float triggerDistance, bool useLineOfSight) {
		float distance = Vector3.Distance(main.position, target.position);
		
		bool apply = (!useLineOfSight || Utils.isLineOfSight(main, target));
		if(apply) apply = (triggerDistance == 0 || distance < triggerDistance);
		
		if(apply) {
			float angle = -Utils.getAngle(target.position, main.position);
			Quaternion targetAngle = Quaternion.Euler(new Vector3(0, 0, angle));
			if(main.GetComponent<Rigidbody>() != null) main.GetComponent<Rigidbody>().MoveRotation(targetAngle);
		}
	}
	
	public static bool isLineOfSight(Transform source, Transform target) {
		bool lineOfSight = false;
		RaycastHit hit;
		Vector3 rayDirection = target.position - source.position;
		
		if (Physics.Raycast (source.position, rayDirection, out hit))
		{
			lineOfSight = (hit.transform == target);
		}
		
		return lineOfSight;
	}
	
	public static RaycastHit rayHit(Vector3 position) {
		RaycastHit hit;
		Physics.Raycast (position, Vector3.forward, out hit);
		
		return hit;
	}
	
	public static float getAngle(Vector3 v1, Vector3 v2) {
		float dx = v1.x - v2.x;
		float dy = v1.y - v2.y;
		return radiansToDegrees(Mathf.Atan2(dx, dy));
	}
	
	public static float radiansToDegrees(float radians) {
		return radians * 180 / Mathf.PI;
	}
	
	public static void explodeTransform(Transform transform) {
		foreach (Transform t in transform) {
			t.gameObject.AddComponent<BoxCollider> ();
			t.gameObject.AddComponent<Rigidbody> ();
			t.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
			t.GetComponent<Rigidbody>().velocity = transform.GetComponent<Rigidbody>().velocity * 1;
		}	
		
		transform.DetachChildren();
		Destroy(transform.gameObject);
	}
}