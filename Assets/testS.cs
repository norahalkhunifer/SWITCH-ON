using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testS : MonoBehaviour {
	private Vector3 startPos;
	private Vector3 endPos;
	private float dis = 1f;
	private float lerpt = 5;
	private float currentt=0;
	//private int[] randomNO = new int[]{5,4,3,-5,-4,-3};
	public GameObject obj;
	int i=0;
	Vector3 v;
	// Use this for initialization
	void Start () {
		
		startPos = obj.transform.position;
		print ("lerp");

		v = new Vector3 ((transform.position.x + 2), transform.position.y, transform.position.z);


		endPos = obj.transform.position + (v) * dis;
	}
	
	// Update is called once per frame
	void Update () {
		print ("update");

		currentt += Time.deltaTime;
		if (currentt > lerpt)
			currentt = lerpt;

		float t = currentt / lerpt;


			obj.transform.position = Vector3.Lerp (startPos, endPos, t);
	}
}
