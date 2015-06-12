    using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {
	
	Vector3 position;
	EditorScript editorScript;
	bool left;
	bool right;
	bool forward;
	bool back;
	bool up;
	bool down;
	
	void Start () {
		position = new Vector3 (0,0,0);
		editorScript = GameObject.Find ("Editor").GetComponent<EditorScript>();
	}
	
	void Update () {
//		if (Input.GetKeyDown (KeyCode.A)) {
//			left = true;
//		} else if (Input.GetKeyUp (KeyCode.A)) {
//			left = false;
//		}
//		
//		if (Input.GetKeyDown (KeyCode.D)) {
//			right = true;
//		} else if (Input.GetKeyUp (KeyCode.D)) {
//			right = false;
//		}
//		
//		if (Input.GetKeyDown (KeyCode.W)) {
//			forward = true;
//		} else if (Input.GetKeyUp (KeyCode.W)) {
//			forward = false;
//		}
//		
//		if (Input.GetKeyDown (KeyCode.S)) {
//			back = true;
//		} else if (Input.GetKeyUp (KeyCode.S)) {
//			back = false;
//		}
//		
//		if (Input.GetKeyDown (KeyCode.E)) {
//			up = true;
//		} else if (Input.GetKeyUp (KeyCode.E)) {
//			up = false;
//		}
//		
//		if (Input.GetKeyDown (KeyCode.Q)) {
//			down = true;
//		} else if (Input.GetKeyUp (KeyCode.Q)) {
//			down = false;
//		}
//		
//		if (left) {
//			position.x -= 1;
//		}
//		
//		if (right) {
//			position.x += 1;
//		}
//
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.A)) {
				position.x -= 1;
			} else if (Input.GetKeyDown (KeyCode.W)) {
				position.z += 1;
			} else if (Input.GetKeyDown (KeyCode.S)) {
				position.z -= 1;
			} else if (Input.GetKeyDown (KeyCode.D)) {
				position.x += 1;
			}else if (Input.GetKeyDown (KeyCode.Q)) {
				position.y -= 1;
			}else if (Input.GetKeyDown (KeyCode.E)) {
				position.y += 1;
			}
			iTween.MoveTo(gameObject, iTween.Hash("z", position.z, "y", position.y, "x", position.x, "time", 0.5f));
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			editorScript.addTile(position);
		}                                                                                                                                                                                                            
	}
}
