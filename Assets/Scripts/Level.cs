using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {
	
	private Transform roomPrefab;
	private List<Transform> rooms;

	void Start () {
		roomPrefab = (Resources.Load("Room") as GameObject).transform;
		rooms = new List<Transform>();
		addNextRoom ();
	}

	void Update () {
	
	}
	
	void addNextRoom() {
		Transform room = (Transform) Instantiate(roomPrefab);
		rooms.Add (room);
	}
}
