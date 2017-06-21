using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour {

	public GameObject player;
	//public GameObject itemPapel;
	//public GameObject itemVidro;
	//private List<Vector3> gridPositions = new List<Vector3> ();
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}

	/* PENSAR NESSA PARTE, PARA COLOCAR AUTOMATICO OS ITENS A COLETAR Parte 3 do documento de apoio.
	Vector3 RandomPosition(){
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject objectToPut, int minimum, int maximum){
		int objectCount = Random.Range (minimum, maximum + 1);
		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPosition = RandomPosition ();
			Instantiate (objectToPut, randomPosition, Quaternion.identity);
		}
	}

	void InitialiseList() {
		float posX = 0.0f;
		for (int x = 1; x <= 7; x++) {
			float posY = 0.0f;
			for (int y = 1; y <= 7; y++) {
				gridPositions.Add (new Vector3 (posX, posY, 0f));
				posY += 0.0f;
			}
			posX += 0.0f;
		}
	}

	void Awake() {
		InitialiseList ();
		LayoutObjectAtRandom (itemPapel, 5, 5);
		LayoutObjectAtRandom (itemVidro, 5, 5);
	}
	*/
}
