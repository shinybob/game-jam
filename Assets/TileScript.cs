using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	Color showColor;
	Color hideColor;
	Renderer renderer;
	float yPosition;

	void Start () {
		renderer = GetComponent<Renderer>();
		yPosition = transform.position.y;
		showColor = renderer.material.color;
		hideColor = new Color (0,0,0);
		renderer.enabled = false;
	}

	void Update () {
	}
	
	public void show(float yOffset) {
		if (renderer.enabled == false) {
			renderer.enabled = true;
			renderer.material.color = hideColor;
			transform.position = new Vector3 (transform.position.x, transform.position.y + yOffset, transform.position.z);
			iTween.MoveTo (gameObject, iTween.Hash ("y", yPosition, "easeType", "easeInQuad", "time", 0.75));
			iTween.ColorTo (gameObject, iTween.Hash ("color", showColor, "easeType", "easeInQuad", "time", 0.75));
		}
	}
	
	public void hide() {
//		renderer.material.color = hideColor;
//		renderer.enabled = false;
	}
}
