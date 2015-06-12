using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
	private List<Transform> floorTilePrefabs;
	private List<Transform> wallTilePrefabs;
	private List<Transform> wallTiles;
	private List<Transform> floorTiles;

	void Start () {
		wallTiles = new List<Transform>();
		floorTiles = new List<Transform>();
		floorTilePrefabs = new List<Transform>();
		wallTilePrefabs = new List<Transform>();
		buildLevel ();
	}

	void Update () {
	
	}
	
	void buildLevel() {
		string mapData = getRoomAsString();
		string[] tiles = mapData.Split(':');
		
		for (int i = 0; i < tiles.Length; i++) {
			string tileData = tiles[i];
			if(tileData.Length > 0) {
				addLoadedTile(tiles[i]);
			}
		}
	}

	public string getRoomAsString() {
		string roomData = "";
		int roomSize = 5;
		
		for (int x = -roomSize; x < roomSize; x++) {
			for (int z = -roomSize; z < roomSize; z++) {
				roomData += ":0," + Random.Range(0,2) + "," + x + "," + z;
			}
		}
		
		for (int i = 0; i < 10; i++) {
			roomData += ":1," + (i % 2) + "," + Random.Range(-roomSize, roomSize) + "," + Random.Range(-roomSize, roomSize);
		}
		
		return roomData;
	}
	
	void setupTilePrefabs () {
		
		for (int i = 0; i < 2; i++) {
			floorTilePrefabs.Add((Resources.Load("floor/floor" + (i + 1)) as GameObject).transform);
		}
		
		for (int i = 0; i < 2; i++) {
			wallTilePrefabs.Add((Resources.Load("wall/wall" + (i + 1)) as GameObject).transform);
		}
	}
	
	void addLoadedTile(string tileAsString) {
		string[] tile = tileAsString.Split(',');
		int type = int.Parse(tile[0]);
		int id = int.Parse(tile[1]);
		int x = int.Parse(tile[2]);
		int z = int.Parse(tile[3]);
		
		if(type == 0) {
			addFloorTile(id, x, z);
		} else {
			addWallTile(id, x, z);
		}
	}
	
	void addFloorTile (int id, int x, int z) {
		Transform prefab = floorTilePrefabs[id];
		Transform tile = (Transform) Instantiate(prefab);
		tile.transform.parent = transform;
		tile.localPosition = new Vector3(x, 0, z);
		floorTiles.Add (tile);
	}
	
	void addWallTile (int id, int x, int z) {
		Transform prefab = wallTilePrefabs[id];
		Transform tile = (Transform) Instantiate(prefab);
		tile.transform.parent = transform;
		tile.localPosition = new Vector3(x, 1, z);
		wallTiles.Add (tile);
	}
}
