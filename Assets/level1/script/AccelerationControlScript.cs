using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AccelerationControlScript : MonoBehaviour {
	public float keyDelay = 1f;
	private float timePassed = 0;
	public float timer;
	int count = 0;
	string str = "grass";
	public string temp;
	Vector3 accelerationDir;
	public int num=0;
	public GameObject thender0;
	public GameObject thender1;
	public GameObject thender2;
	public GameObject thender3;
	public GameObject thender4;
	public GameObject thender5;
	public GameObject thender6;
	public GameObject thender7;
	public GameObject thender8;
	public AccelerationControlScript script;
	public GameObject grass0,grass5,grass3,grass8,grass9,grass11,grass13,grass15,grass17;
	public AudioSource grass_removing;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//read the shake of phone
		accelerationDir = new Vector3 (Input.acceleration.x, 0, 0);
		//this time betwwen two grass
		timePassed += Time.deltaTime; 

		//to make sure the shake is happend
		if (accelerationDir.sqrMagnitude >= 6f && timePassed >= keyDelay) {			
			//here to change the game object from counter 
			temp = str + count;
			//here to make grass hide
			GameObject.Find (temp).GetComponent<Rigidbody2D> ().isKinematic = false;
			GameObject.Find (temp).SetActive (false);
			grass_removing.Play ();
			//reset the time passed to restart to another object 
			timePassed = 0;
			StartCoroutine(disable(num));

			Debug.Log (num);
			//here increes the counter to another object
			count++;
			Debug.Log (temp);

		}
	}
	IEnumerator disable(int num)
	{ 				yield return new WaitForSeconds(5f);

		if (num==0 && !grass0.activeInHierarchy) {
			thender0.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num = 1;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);
			//here 1
		}yield return new WaitForSeconds(5f);
		if (num==1&&!grass3.activeInHierarchy) {
			thender1.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num = 2;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);


		}yield return new WaitForSeconds(5f);
		if (num==2&&!grass5.activeInHierarchy) {
			thender2.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num =3 ;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);

		}yield return new WaitForSeconds(5f);
		if (num==3&&!grass8.activeInHierarchy) {
			thender3.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num =4 ;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);


		}yield return new WaitForSeconds(5f);
		if (num==4&&!grass9.activeInHierarchy) {
			thender4.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num =5 ;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);
		}yield return new WaitForSeconds(5f);
		if (num==5&&!grass11.activeInHierarchy) {
			thender5.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num =6 ;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);


		}//here another one
		yield return new WaitForSeconds(5f);
		if (num==6&&!grass13.activeInHierarchy) {
			thender6.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num =7 ;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);


		}
		yield return new WaitForSeconds(5f);
		if (num==7&&!grass15.activeInHierarchy) {
			thender7.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num =8;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);

		}
		yield return new WaitForSeconds(5f);
		if (num==8&&!grass17.activeInHierarchy) {
			thender8.SetActive (false);//to disable thinder
			Debug.Log (str + "dd");
			num =9;
			Debug.Log (timer);

			timer = 0f;
			Debug.Log (timer);


		}

	}

}


