using UnityEngine;
using System.Collections;

public class EditorScript : MonoBehaviour {

	public Camera camera;

	Transform cursorPrefab;
	Transform tilePrefab;
	string mapData = "";
	
	void Start () {
		cursorPrefab = (Resources.Load("editor/Cursor") as GameObject).transform;
		tilePrefab = (Resources.Load("wall/wall1") as GameObject).transform;

		Transform cursor = (Transform) Instantiate(cursorPrefab);

		camera.GetComponent<CameraScript> ().target = cursor;

	}

	void Update () {
		
	}

	public void addTile (Vector3 position) {
		Transform tile = (Transform) Instantiate(tilePrefab);
		Destroy(tile.GetComponent<Rigidbody>());
		Destroy(tile.GetComponent<TileScript>());
		tile.position = position;

		mapData += ":1," + position.x + "," + position.y + "," + position.z;
	}
}