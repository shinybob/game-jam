using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	Vector3 position;

	void Start () {
		position = new Vector3 (0,0,0);
	}

	void Update () {
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.A)) {
				position.x -= 1;
			} else if (Input.GetKeyDown (KeyCode.W)) {
				position.z += 1;
			} else if (Input.GetKeyDown (KeyCode.S)) {
				position.z -= 1;
			} else if (Input.GetKeyDown (KeyCode.D)) {
				position.x += 1;
			}
			iTween.MoveTo(gameObject, iTween.Hash("z", position.z, "x", position.x, "time", 0.5f));
		}
	}
}
