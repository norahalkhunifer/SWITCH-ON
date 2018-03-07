using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AccelerationControlScript : MonoBehaviour {
	public float keyDelay = 1f;
	private float timePassed = 0;
	private float timer = 0;

	int count = 0;
	string str = "grass";
	string temp;
	Vector3 accelerationDir;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//read the shake of phone
		accelerationDir = new Vector3(Input.acceleration.x,0,0);
		//this time betwwen two grass
		timePassed += Time.deltaTime; 
		timer+= Time.deltaTime; 

		//to make sure the shake is happend
		if (accelerationDir.sqrMagnitude >= 6f && timePassed >= keyDelay)
		{
			//here to change the game object from counter 
			temp = str + count;
			//here to make grass hide
			GameObject.Find(temp).GetComponent<Rigidbody2D> ().isKinematic = false;
			GameObject.Find(temp).SetActive (false);
			//reset the time passed to restart to another object 
			
			timePassed = 0;
			//here increes the counter to another object
			count++;

		}
	}
}
		
	

	// Public method to reset the scene by pressing Reset UI button
//	public void ResetScene()
//	{
//		SceneManager.LoadScene ("Scene01");
//	}
	
