using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileMapScript : MonoBehaviour {
	private List<Transform> floorTilePrefabs;
	private List<Transform> wallTilePrefabs;
	private List<Transform> wallTiles;
	private List<Transform> floorTiles;
	GameObject character;

	void Start () {
		wallTiles = new List<Transform>();
		floorTiles = new List<Transform>();
		character = GameObject.Find ("Character");

		setupTilePrefabs ();
		buildLevel ();
	}

	void buildLevel() {
		string mapData = getMapData();
		string[] tiles = mapData.Split(':');
		
		for (int i = 0; i < tiles.Length; i++) {
			string tileData = tiles[i];
			if(tileData.Length > 0) {
				addLoadedTile(tiles[i]);
			}
		}
	}
	
	string getMapData() {
		string mapData = "";
		
		for (int x = -10; x < 10; x++) {
			for (int z = -10; z < 10; z++) {
				mapData += ":0," + Random.Range(0,2) + "," + x + "," + z;
			}
		}
		
		for (int i = 0; i < 60; i++) {
			mapData += ":1," + (i % 2) + "," + Random.Range(-11, 11) + "," + Random.Range(-10, 10);
		}
		
		return mapData;
	}

	void setupTilePrefabs () {
		floorTilePrefabs = new List<Transform>();
		wallTilePrefabs = new List<Transform>();
		
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

	void Update () {
		updateWallTiles();
		updateFloorTiles();
	}
	
	void updateWallTiles () {
		foreach (Transform wallTile in wallTiles) {
			float distance = Vector3.Distance(wallTile.position, character.transform.position);
			if (distance < 5) {
				wallTile.GetComponent<TileScript>().show(5);
			} else {
				wallTile.GetComponent<TileScript>().hide();
			}
		}
	}
	
	void updateFloorTiles () {
		foreach (Transform floorTile in floorTiles) {
			float distance = Vector3.Distance(floorTile.position, character.transform.position);
			if (distance < 5) {
				floorTile.GetComponent<TileScript>().show(-2);
			} else {
				floorTile.GetComponent<TileScript>().hide();
			}
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
