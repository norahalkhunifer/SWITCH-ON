using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenrator : MonoBehaviour {
	static	string[] names={ "The Limited 4","non" };//array of objects name 
	//public GameObject[] boxes;//boxes array
	static int  randomInt;
	///public Transform spawnPos;

	// Use this for initialization
	void Start () {
		//boxes = GameObject.FindGameObjectsWithTag("tresure_box");

	}
	public static void placeRandomobj() {
		//int randomInt = GetRandom(names.Length);
		//return names [randomInt];
		//Instantiate(names[randomInt], spawnPos.position//in mid of our chest object (from boxes array , spawnPos.rotation//same also we want to added it to object rooot +scale is fixed !);
	}
	int GetRandom(int count) {
		return Random.Range(0, count);
	}

}
